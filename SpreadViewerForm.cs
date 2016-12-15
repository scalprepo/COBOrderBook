using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading;
//using RBTrader.Views;
using DevExpress.XtraEditors;
using RBClients.SprdClient;
using RBtech.BlockingQueue;

namespace SpreadArbViewer
{
  public partial class SpreadViewerForm : DevExpress.XtraEditors.XtraForm
  {
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private enum BarFilters : byte
    {
        None = 0,
        Spread = 1,
        Stock = 2,
        Exchange = 4,
        Size = 8,
        Edge = 16,
        Type = 32,
        Lean = 64,
        LeanPct = 128
    }
        
    protected DateTime oldRecord, appStartTime;
    protected int rowHeight;
    protected int maxRows;
    private int spreadID = 0;
    volatile public bool bNotScreened = true;
    private DateTime dtExpires;
    protected int iTradeNo;
    protected bool bChkEdge;
    protected ArrayList xclExchanges = new ArrayList();

    // Button Filter Values 
    protected string strExchFilters;
    protected int iScreenSize;
    protected int iScreenLean;
    protected double dblScreenEdge;
    protected double dblScreenSprd;
    protected double dblScreenLnPct;
    protected string strScreenType;
    protected string strStock;
    private bool isSymbolFilter;

    protected string prevScreen;
    protected string[] filters;
    protected int filtered;

    private int countPurge = 0;
    public string customColumn;

    OptionsLayoutGrid layout = new OptionsLayoutGrid();
    public string[] visibleColumns;

    //protected SettingsStructure myStruct;
    protected bool bChkExpirys;
    protected ArrayList xclExpirys = new ArrayList();
    protected ArrayList xclOptions = new ArrayList();
    protected ArrayList xclUnderlyings = new ArrayList();
    protected BindingList<SpreadQuote> anytradeList = new BindingList<SpreadQuote>();
    protected BindingList<SpreadQuote> _spreadList;
    private Thread SpreadQuoteProcessorThread;
    private volatile bool runThread = true;
    private BlockingQueue<SpreadQuote> SpreadQuoteQueue;

    protected int iWindNum;
    //protected MainPanelForm mMain;
    protected static object listlock = new object();
    protected bool shown = false;
    //protected ViewerType vType;

    public int threadNo;
    public int _threadID;
    public bool previousFilterState;
    //protected MktSrvcAPI.RBClient _client;        

    protected bool bClosing = false;
    protected bool doUpdate = true;
    protected string fileName = ".\\config\\SpreadViewerGrid";
    protected string setFileName = ".\\config\\SpreadViewer";
    protected bool bUndLnk;
    protected bool bOptLnk;
    protected int iChoosing;
    protected int iTimeLimit;
    DateTime cutOffTime;
    protected Dictionary<string, GridColumn> mCalcColumns = new Dictionary<string, GridColumn>();
    protected System.Windows.Forms.Timer gridTimer;

    private volatile bool showComma = false;
    //private SpreadClient _spreadClient;
    private SpreadClientUdp _spreadClientUdp;

    private GridHitInfo hitInfoGrid1;
    private int xPointGrid1 { get; set; }
    private int yPointGrid1 { get; set; }
    private string rowClickedOptionGrid1 { get; set; }

    private GridHitInfo hitInfoGrid2;
    private int xPointGrid2 { get; set; }
    private int yPointGrid2 { get; set; }
    private string rowClickedOptionGrid2 { get; set; }
    private int rowClickedIDxGrid2 { get; set; }
    //private GridViewCustom _gridViewCustom;        

    public SpreadViewerForm()
    {
      //appStartTime = DateTime.Now;
      //_gridViewCustom = new GridViewCustom();

      InitializeTimer();
      InitializeComponent();


      //iWindNum = windowNum;
      //mMain = main;
      //vType = ViewerType.Trades;       

      SpreadQuoteQueue = new BlockingQueue<SpreadQuote>();
      _spreadClientUdp = new SpreadClientUdp("224.224.4.1", 34000);
      _spreadClientUdp.OnSpreadQuoteUpdate += _spreadClientUdp_OnSpreadUpdate;

      this.Name = "SpreadView";
      this.Text = "COB Order Scanner";
      this.Text = this.Text + " - Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
      //Text = Text + " (" + (iWindNum + 1).ToString() + ")";

      iTradeNo = (int)(iScreenSize = iScreenLean = 0);
      dblScreenEdge = dblScreenLnPct = dblScreenSprd = 0;
      iTimeLimit = 5;
      StartThreads();
      //mMain.pushAllColumn += addCustomColumn;
      //mMain.pushTradesColumn += addCustomColumn;            
    }

    private void StartThreads()
    {
        runThread = true;
        try
        {
            SpreadQuoteProcessorThread = new Thread(UpdateQuoteTable);
            SpreadQuoteProcessorThread.IsBackground = true;
            SpreadQuoteProcessorThread.Name = "SpreadTradeProcessorThread";
            SpreadQuoteProcessorThread.Start();
        }
        catch (Exception ex)
        {
            log.Error("StartProcessing - " + ex.ToString());
        }
    }
    private void _spreadClientUdp_OnSpreadUpdate(SpreadQuote e)
    {
        SpreadQuoteQueue.Enqueue(e);
    }

    private void UpdateQuoteTable()
    {
        while (runThread)
        {
            try
            {
                SpreadQuote sq = SpreadQuoteQueue.Dequeue();
                if (sq != null)
                {
                    if (!String.IsNullOrEmpty(sq.SymID))
                    {
                        SpreadQuote tempDR = new SpreadQuote();
                        tempDR.SymID = sq.SymID;

                        int index = -1;

                        lock (_spreadList)
                        {
                            try
                            {
                                    
                                foreach (SpreadQuote trd in _spreadList)
                                {
                                    if (trd.SymID == sq.SymID)
                                    {
                                        tempDR = trd;
                                        index = _spreadList.IndexOf(tempDR);
                                        break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("UpdateQuoteTable - " + ex.ToString());
                            }

                            if (index > -1) // Found Row
                            {
                                try
                                {
                                    // If Bidsize and AskSize = 0 
                                    // No orders open for that spread
                                    if (sq.updateType < 2)
                                    {
                                        if (sq.Size > 0)
                                        {
                                            if (sq.updateType == 0)
                                            {
                                                _spreadList[index].CobSide = "Buy";
                                            }
                                            else
                                                _spreadList[index].CobSide = "Sell";

                                            _spreadList[index].Price = (float)Math.Round(sq.Price, 2);
                                            _spreadList[index].Size = sq.Size;
                                            _spreadList[index].CustSize = sq.CustSize;
                                            _spreadList[index].ProSize = sq.ProSize;
                                        }
                                        else
                                        {
                                            _spreadList.RemoveAt(index);
                                        }
                                    }
                                    //else if (sq.updateType == 2)
                                    //{
                                    //    if (sq.CobBidSz > 0)
                                    //    {
                                    //        _spreadList[index].Price = (float)Math.Round(sq.CobBidPrc, 2);
                                    //        _spreadList[index].Size = sq.CobBidSz;
                                    //        _spreadList[index].CustSize = sq.CobBidCustSz;
                                    //        _spreadList[index].ProSize = sq.CobBidProSz;
                                    //    }
                                    //    if (sq.CobAskSz > 0)
                                    //    {
                                    //        _spreadList[index].Price = (float)Math.Round(sq.CobAskPrc, 2);
                                    //        _spreadList[index].Size = sq.CobAskSz;
                                    //        _spreadList[index].CustSize = sq.CobAskCustSz;
                                    //        _spreadList[index].ProSize = sq.CobAskProSz;
                                    //    }
                                    //}
                                }                                    
                                catch (Exception ex)
                                {
                                    log.Error("SpreadMsg_OnSpreadUpdate1 - " + ex.ToString());
                                }
                            }
                            else // New Row
                            {
                                try
                                {
                                        
                                    if (sq.updateType < 2)
                                    {
                                        tempDR.Under = sq.Under;
                                        tempDR.Exch = sq.Exch;

                                        if (sq.updateType == 0)
                                        {
                                            if (sq.Size > 0)
                                            {
                                                tempDR.CobSide = "Buy";
                                                tempDR.Price = sq.Price;
                                                tempDR.Size = sq.Size;
                                                tempDR.CustSize = sq.CustSize;
                                                tempDR.ProSize = sq.ProSize;
                                            }
                                        }
                                        else if (sq.updateType == 1)
                                        {
                                            if (sq.Size > 0)
                                            {
                                                tempDR.CobSide = "Sell";
                                                tempDR.Price = sq.Price;
                                                tempDR.Size = sq.Size;
                                                tempDR.CustSize = sq.CustSize;
                                                tempDR.ProSize = sq.ProSize;
                                            }
                                        }

                                        tempDR.LegCnt = sq.LegCnt;
                                        tempDR.SeqID = spreadID++;

                                        _spreadList.Add(tempDR);
                                    }
                                    //else if (sq.updateType == 2)
                                    //{
                                    //    if (sq.CobBidSz > 0)
                                    //    {
                                    //        SpreadQuote tempBid = new SpreadQuote();
                                    //        tempBid.SymID = sq.SymID; 
                                    //        tempBid.CobSide = "Buy";
                                    //        tempBid.Price = sq.CobBidPrc;
                                    //        tempBid.Size = sq.CobBidSz;
                                    //        tempBid.CustSize = sq.CobBidCustSz;
                                    //        tempBid.ProSize = sq.CobBidProSz;
                                    //        tempBid.LegCnt = sq.LegCnt;
                                    //        tempBid.SeqID = spreadID++;

                                    //        _spreadList.Add(tempBid);
                                    //    }
                                    //    if (sq.CobAskSz > 0)
                                    //    {
                                    //        SpreadQuote tempAsk = new SpreadQuote();
                                    //        tempAsk.SymID = sq.SymID;
                                    //        tempAsk.CobSide = "Sell";
                                    //        tempAsk.Price = sq.Price;
                                    //        tempAsk.Size = sq.Size;
                                    //        tempAsk.CustSize = sq.CustSize;
                                    //        tempAsk.ProSize = sq.ProSize;
                                    //        tempAsk.LegCnt = sq.LegCnt;
                                    //        tempAsk.SeqID = spreadID++;

                                    //        _spreadList.Add(tempAsk);
                                    //    } 
                                    //}                                        
                                }
                                catch (Exception ex)
                                {
                                    log.Error("SpreadMsg_OnSpreadUpdate3 - " + ex.ToString());
                                }
                            }
                            Monitor.PulseAll(_spreadList);
                        }
                    }
                    else
                    {
                        log.Error("SymID Error - " + sq.SymID);
                    }
                }                    
            }
            catch (Exception ex)
            {
                log.Error("SpreadMsg_OnSpreadUpdate4 - " + ex.ToString());
            }
        }
    }

    #region Timer

    private void InitializeTimer()
    {
        gridTimer = new System.Windows.Forms.Timer();
        this.gridTimer.Interval = 500;
        this.gridTimer.Enabled = true;                     
        this.gridTimer.Tick += new System.EventHandler(Refresh_Tick);
    }

    private void Refresh_Tick(object sender, EventArgs e)
    {
        if (!doUpdate)
            return;

        // Refresh Data Grid
        UpdateDataGrid();
    }

    #endregion


    #region Grid Methods

    public void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
            
    }
       
    private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
    {
            
    }

    private void barClearGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        doUpdate = false;
        try
        {
            lock (_spreadList)
            {
                _spreadList.Clear();
            }
            UpdateDataGrid();
        }
        catch (Exception ex)
        {
            log.Error("barClearGrid_ItemClick - " + ex.ToString());                
        }
        doUpdate = true;            
    }
        
    private void _spreadList_ListChanged(object sender, ListChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void UpdateDataGrid()
    {
      if (!doUpdate)
          return;

      gridControl1.BeginInvoke(new MethodInvoker(delegate ()
      {
          try
          {
              gridControl1.BeginUpdate();
              gridView1.BeginUpdate();
              gridView1.BeginDataUpdate();
              gridView1.RefreshData();
          }
          catch (Exception ex)
          {
              log.Error("UpdateDataGrid - " + ex.ToString());
          }
          finally
          {
              gridView1.EndDataUpdate();
              gridView1.EndUpdate();
              gridControl1.EndUpdate();
          }
      }));

      gridControl2.BeginInvoke(new MethodInvoker(delegate ()
      {
        try
        {
          gridControl2.BeginUpdate();
          gridView2.BeginUpdate();
          gridView2.BeginDataUpdate();
          gridView2.RefreshData();
        }
        catch (Exception ex)
        {
          log.Error("UpdateDataGrid - " + ex.ToString());
        }
        finally
        {
          gridView2.EndDataUpdate();
          gridView2.EndUpdate();
          gridControl2.EndUpdate();
        }
      }));
    }

    private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
    {
            
    }

    private void gridView1_CalcRowHeight(object sender, RowHeightEventArgs e)
    {
            
    }

    #endregion

    #region Data Feed Handlers

    private void RegisterHandlers()
    {
        Thread connection = new Thread(() =>
        {
            _spreadClientUdp.StartConnection();
                
        });
        connection.Start();
    }

    private void DeregisterHandlers()
    {
        _spreadClientUdp.StopConnection();
    }

    #endregion

    #region Grid View Settings 



    #endregion

    #region Mouse Events               

    private void gridView1_MouseDown(object sender, MouseEventArgs e)
    {
        // Stop updating gridview
        doUpdate = false;
        try
        {
            gridView1.BeginUpdate();
            gridView1.BeginDataUpdate();
            hitInfoGrid1 = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            gridView1.EndDataUpdate();
            gridView1.EndUpdate();
            xPointGrid1 = e.X;
            yPointGrid1 = e.Y;

            if (hitInfoGrid1.InDataRow)
            {                    
                rowClickedOptionGrid1 = gridView1.GetRowCellDisplayText(hitInfoGrid1.RowHandle, "SymID");
            }
        }
        catch (Exception ex)
        {
            log.Error("gridView1_MouseDown - " + ex.ToString());
        }            
    }

    private void gridView1_MouseUp(object sender, MouseEventArgs e)
    {            
        // restart updating the grid
        doUpdate = true;
    }

    private void gridView1_Click(object sender, EventArgs e)
    {
        try
        {
                
        }
        catch (Exception ex)
        {
            log.Error("gridView1_Click - " + ex.ToString());
        }
    }

    private void gridView1_DoubleClick(object sender, EventArgs e)
    {
            
    }

    private void gridView1_MouseMove(object sender, MouseEventArgs e)
    {
        //if (hitInfo != null)
        //{
        //    Rectangle dragRect = new Rectangle(new Point(
        //    hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
        //    hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);

        //    if (!dragRect.Contains(new Point(e.X, e.Y)))
        //    {
        //        gridControl1.DoDragDrop(rowClickedOption, DragDropEffects.Copy | DragDropEffects. Move);
        //        //hitInfo = null;
        //    }            
        //}
        if (e.Button == MouseButtons.None && doUpdate == false)
        {
            doUpdate = true;
        }
    }

    #endregion

    #region Form Events

    private void OptionView_Load(object sender, EventArgs e)
    {
        try
        {
            _spreadList = new BindingList<SpreadQuote>();
            _spreadList.ListChanged += _spreadList_ListChanged;
            _spreadList.RaiseListChangedEvents = false;

            gridControl1.DataSource = _spreadList;
                

            try
            {
                // Restore the previously saved layout                    
                layout.StoreAppearance = false;
                if (new FileInfo(fileName).Exists)
                {
                    gridControl1.MainView.RestoreLayoutFromXml(fileName);
                }
            }
            catch (Exception ex)
            {
                log.Error("OptionView_Load1 - " + ex.ToString());
            }


            gridView1.OptionsView.ShowColumnHeaders = true;
            gridView1.OptionsView.ColumnAutoWidth = true;
            //gridView1.Columns["TimeStampDT"].DisplayFormat.FormatType = FormatType.DateTime;
            //gridView1.Columns["TimeStampDT"].DisplayFormat.FormatString = "HH:mm:ss.fff";
            //gridView1.Columns["SeqID"].OptionsFilter.FilterPopupMode = FilterPopupMode.
            //gridView1.Columns["TimeStampDT"].OptionsFilter.AllowFilter = false;
            //gridView1.Columns["Under"].OptionsFilter.AllowFilter = false;
            //this.gridView1.Columns["SeqID"].DisplayFormat.FormatType = FormatType.Numeric;
            this.gridView1.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
            {
                new GridColumnSortInfo(this.gridView1.Columns["SeqID"], ColumnSortOrder.Descending)
            });
        }
        catch (Exception ex)
        {
            log.Error("OptionView_Load2 - " + ex.ToString());
        }
    }

    protected void TradesView_Shown(object sender, EventArgs e)
    {
        try
        {
            RegisterHandlers();
            gridTimer.Start();
        }
        catch (Exception ex)
        {
            log.Error("TradesView_Shown - " + ex.ToString());
        }
    }

    private void TradesView_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            log.Info("TradesView " + iWindNum.ToString() + " is closing.");
            bClosing = true;

            DeregisterHandlers();

            //  Save Layout
            try
            {
                layout.StoreAppearance = false;
                gridControl1.MainView.SaveLayoutToXml(fileName);
            }
            catch (Exception ex)
            {
                log.Error("TradesView_FormClosing1 - " + ex.ToString());
            }

            SaveFormSettings();                

            //myStruct = null;
            xclExpirys = null;
            xclOptions = null;
            xclUnderlyings = null;
            anytradeList = null;
            //UpdateOptionTable = null;
            mCalcColumns = null;

            GC.Collect();
            Application.ExitThread();
        }
        catch (Exception ex)
        {
            log.Error("TradesView_FormClosing2 - " + ex.ToString());
        }
    }

    #endregion

    #region Button Event Clicks

    private void barGridFont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        FontDialog fontDialog1 = new FontDialog();

        fontDialog1.ShowColor = false;
        fontDialog1.Font = gridControl1.Font;

        if (fontDialog1.ShowDialog() != DialogResult.Cancel)
        {
            gridControl1.Font = fontDialog1.Font;
            foreach (AppearanceObject app in gridView1.Appearance)
            {
                app.Font = fontDialog1.Font;
            }
            foreach (StyleFormatCondition style in gridView1.FormatConditions)
                style.Appearance.Font = fontDialog1.Font;
        }
    }

    private void barSymFilters_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        isSymbolFilter = barSymFilters.Checked;
    }

    private void barCheckItemGridLines_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        gridControl1.BeginInvoke(new MethodInvoker(delegate ()
        {
            try
            {
                //CommaStyleCondition();
                DefaultBoolean bValue = this.gridView1.OptionsView.ShowHorizontalLines == DefaultBoolean.True ? DefaultBoolean.False : DefaultBoolean.True;
                this.gridView1.OptionsView.ShowHorizontalLines = bValue;
                this.gridView1.OptionsView.ShowVerticalLines = bValue;
            }
            catch (Exception ex)
            {
                log.Error("barCheckItemGridLines_CheckedChanged - " + ex.ToString());
            }
        }));
    }

    #endregion

    protected void barPurgeTime_EditValueChanged(object sender, EventArgs e)
    {
        try
        {
            iTimeLimit = Convert.ToInt32(barPurgeTime.EditValue);
            //DateTime optCutOff = DateTime.Now - new TimeSpan(0, iTimeLimit, 0);
            //cutOffTime = optCutOff < cutOffTime ? optCutOff : cutOffTime;
        }
        catch(Exception ex)
        {

        }
    }

    #region Custom Columns Methods

    public void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
    {
        //GridView viewer = sender as GridView;
        //string under = (string)viewer.GetListSourceRowCellValue(e.ListSourceRowIndex, "Under");
        //string option = (string)viewer.GetListSourceRowCellValue(e.ListSourceRowIndex, "Option");
        ////string sd = "";
        //object sd;

        ////foreach (KeyValuePair<string, Dictionary<string, string>> kv in MainFormPanel.customDictionary)
        //foreach (KeyValuePair<string, object> kv in MainPanelForm.customDictionary)
        //{
        //    if (kv.Key == e.Column.Name)
        //    {
        //        Dictionary<string, object> localDict = (Dictionary<string, object>)kv.Value;
        //        //  Use index to find optionobject and use under/option to look up in dictionary
        //        if (localDict.TryGetValue(under, out sd)) ;
        //        else localDict.TryGetValue(option, out sd);

        //        e.Value = sd;
        //    }
        //}
    }

    protected void LoadUsersUnboundColumns()
    {
        //try
        //{
        //    using (StreamReader sr = new StreamReader(setFileName + "UnbCols.txt"))
        //    {
        //        string line;
        //        // Read and get information from our text file
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            string[] colVals = line.Split(new char[] { ';' });
        //            if (colVals.Length >= 3)
        //            {
        //                GridColumn newColumn = new GridColumn();
        //                newColumn.FieldName = colVals[0];
        //                newColumn.Caption = colVals[0];
        //                if (colVals[1] == "String")
        //                    newColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
        //                else if (colVals[1] == "Integer")
        //                    newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        //                else if (colVals[1] == "Decimal")
        //                    newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        //                else
        //                    newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
        //                if (3 == colVals.Length)
        //                    newColumn.UnboundExpression = colVals[2];
        //                else
        //                {
        //                    StringBuilder value = new StringBuilder();
        //                    for (int x = 2; x < colVals.Length; x++)
        //                    {
        //                        if (x > 2)
        //                            value.Append(";");
        //                        value.Append(colVals[x]);
        //                    }
        //                    newColumn.UnboundExpression = value.ToString();
        //                }
        //                mCalcColumns.Add(newColumn.Caption, newColumn);
        //                gridView1.Columns.Add(newColumn);
        //                newColumn.VisibleIndex = gridView1.Columns.Count - 1;
        //                newColumn.ShowUnboundExpressionMenu = true;
        //            }
        //        }
        //    }
        //}
        //catch { }
    }

    protected void SaveUsersUnboundColumns()
    {
        // only first window can add/save columns....
        //if (iWindNum > 0)
        //    return;

        //try
        //{
        //    using (StreamWriter sw = new StreamWriter(setFileName + "UnbCols.txt"))
        //    {
        //        for (int y1 = 0; y1 < gridView1.Columns.Count; y1++)
        //        {
        //            if (gridView1.Columns[y1].Visible && gridView1.Columns[y1].UnboundExpression.Length > 0)
        //            {
        //                System.Diagnostics.Debug.WriteLine("==================");
        //                System.Diagnostics.Debug.WriteLine(gridView1.Columns[y1].Caption);
        //                System.Diagnostics.Debug.WriteLine(gridView1.Columns[y1].UnboundType.ToString());
        //                System.Diagnostics.Debug.WriteLine(gridView1.Columns[y1].UnboundExpression);
        //                System.Diagnostics.Debug.WriteLine("==================");
        //                sw.Write(gridView1.Columns[y1].Caption);
        //                sw.Write(";" + gridView1.Columns[y1].UnboundType.ToString());
        //                sw.WriteLine(";" + gridView1.Columns[y1].UnboundExpression);
        //            }
        //        }
        //    }
        //}
        //catch(Exception ex)
        //{
        //    log.Error("SaveUsersUnboundColumns - " + ex.ToString());
        //}
    }
    protected void barDelCol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        //try
        //{
        //    string colName;
        //    // column name
        //    InputBoxDialog MyBox = new InputBoxDialog();
        //    MyBox.FormCaption = "Enter Column Name to Delete";
        //    MyBox.FormPrompt = "Column:";
        //    MyBox.DefaultValue = "";
        //    MyBox.ShowDialog();

        //    string inpSymbol = MyBox.InputResponse;
        //    // anything?
        //    if (inpSymbol.Length == 0)
        //    {
        //        return;
        //    }
        //    colName = inpSymbol;

        //    // now add our field to the grid...
        //    if (!mCalcColumns.ContainsKey(colName))
        //    {
        //        log.Error("Column " + colName + " does not EXIST!");                    
        //        return;
        //    }
        //    if (mCalcColumns.ContainsKey(colName))
        //    {
        //        mCalcColumns.Remove(colName);
        //        gridView1.Columns.Remove(gridView1.Columns[colName]);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    log.Error("barDelCol_ItemClick - " + ex.ToString());
        //}
    }

    protected void barAddCol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        //try
        //{
        //    string colName, fieldType, calcValueString;
        //    // column name
        //    InputBoxDialog MyBox = new InputBoxDialog();
        //    MyBox.FormCaption = "Enter New Column Name";
        //    MyBox.FormPrompt = "Column Name:";
        //    MyBox.DefaultValue = "";
        //    MyBox.ShowDialog();

        //    string inpSymbol = MyBox.InputResponse;

        //    // anything?
        //    if (inpSymbol.Length == 0)
        //    {
        //        return;
        //    }
        //    colName = inpSymbol;

        //    // type of value here...
        //    MyBox = new InputBoxDialog();
        //    MyBox.FormCaption = "Enter Type of Fields";
        //    MyBox.FormPrompt = "Field Type:(s-String, i-integer, d-decimal, b-T/F)";
        //    MyBox.DefaultValue = "";
        //    MyBox.ShowDialog();

        //    inpSymbol = MyBox.InputResponse.ToUpper();
        //    string colType = MyBox.Controls["txtInput"].Text.ToUpper();

        //    // anything?
        //    if (inpSymbol.Length == 0)
        //    {
        //        return;
        //    }
        //    fieldType = inpSymbol.ToUpper();
        //    if (fieldType == "S")
        //        calcValueString = "[Symbol]";
        //    else if (fieldType == "I")
        //        calcValueString = "[CntNum]";
        //    else if (fieldType == "D")
        //        calcValueString = "[Bid]";
        //    else
        //        calcValueString = "[Create filter condition]";

        //    // now add our field to the grid...
        //    if (mCalcColumns.ContainsKey(colName))
        //    {
        //        log.Error("Column " + colName + " already EXISTS!");                    
        //        return;
        //    }
        //    GridColumn newColumn = new GridColumn();
        //    newColumn.FieldName = colName;
        //    newColumn.Caption = colName;

        //    if (colType == "S")
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
        //    else if (colType == "I")
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        //    else if (colType == "D")
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        //    else if (colType == "B")
        //    {
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
        //        newColumn.ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
        //    }
        //    else
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Object;

        //    newColumn.UnboundExpression = calcValueString;
        //    newColumn.ShowUnboundExpressionMenu = true;
        //    mCalcColumns.Add(colName, newColumn);
        //    gridView1.Columns.Add(newColumn);
        //    newColumn.VisibleIndex = gridView1.Columns.Count - 1;
        //}
        //catch (Exception ex)
        //{
        //    log.Error("barAddCol_ItemClick - " + ex.ToString());
        //}
    }

    public void addCustomColumn(string columnName, Type columnType)
    {
        //if (gridView1.Columns[columnName] == null)
        //{
        //    customColumn = columnName;
        //    GridColumn newColumn = new GridColumn();
        //    newColumn.FieldName = columnName;
        //    newColumn.Name = columnName;
        //    newColumn.Caption = columnName;

        //    if (columnType == typeof(Double))
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        //    if (columnType == typeof(Boolean))
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
        //    else
        //        newColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;

        //    newColumn.ShowUnboundExpressionMenu = true;
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(new MethodInvoker(() =>
        //        {
        //            gridView1.Columns.Add(newColumn);
        //        }));
        //    }
        //    newColumn.VisibleIndex = gridView1.Columns.Count - 1;
        //}
    }

    #endregion
                
    public bool IsClosing
    {
        get { return bClosing; }
    }        

    #region Load Form Layout
               
    //private void LoadSettings()
    //{
    //    try
    //    {
    //        string sValue;
    //        // read settings file if it exists...
    //        myStruct = SettingsStructure.ReadIni(mMain.GetWindowFileName(true, iWindNum, setFileName));
    //        if (myStruct != null)
    //        {
    //            // basic info settings
    //            sValue = myStruct.GetValue("Settings", "Top");
    //            // anything there???
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                int compare = 0;
    //                //this.Top = (compare = MiscUtils.IntParse(sValue)) >= 0 ? compare : 0;
    //                //this.Left = (compare = MiscUtils.IntParse(myStruct.GetValue("Settings", "Left"))) >= 0 ? compare : 0;
    //                this.Top = MiscUtils.IntParse(sValue);
    //                this.Left = MiscUtils.IntParse(myStruct.GetValue("Settings", "Left"));
    //                this.Width = (compare = MiscUtils.IntParse(myStruct.GetValue("Settings", "Width"))) > 500 ? compare : 500;
    //                this.Height = (compare = MiscUtils.IntParse(myStruct.GetValue("Settings", "Height"))) > 125 ? compare : 125;
    //            }
    //            sValue = myStruct.GetValue("Settings", "FontName");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                double fontSize = 8;
    //                FontStyle fontStyle = FontStyle.Regular;
    //                try
    //                {
    //                    string FontSize = myStruct.GetValue("Settings", "FontSize");
    //                    fontSize = Convert.ToDouble(FontSize);
    //                }
    //                catch { }
    //                try
    //                {
    //                    string MyFontStyle = myStruct.GetValue("Settings", "FontStyle");
    //                    if (MyFontStyle == "Bold")
    //                        fontStyle = FontStyle.Bold;
    //                    else if (MyFontStyle == "Italic")
    //                        fontStyle = FontStyle.Bold;
    //                    else if (MyFontStyle == "Strikeout")
    //                        fontStyle = FontStyle.Strikeout;
    //                    else if (MyFontStyle == "Underline")
    //                        fontStyle = FontStyle.Underline;
    //                }
    //                catch
    //                {
    //                    fontStyle = FontStyle.Regular;
    //                }
    //                gridControl1.Font = new Font(sValue, (float)fontSize, fontStyle);
    //                foreach (AppearanceObject app in gridView1.Appearance)
    //                {
    //                    app.Font = gridControl1.Font;
    //                }
    //                foreach (StyleFormatCondition style in gridView1.FormatConditions)
    //                    style.Appearance.Font = gridControl1.Font;
    //            }
    //            sValue = myStruct.GetValue("Settings", "StLinkUnd");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                barSterStock.EditValue = sValue;
    //            }
    //            sValue = myStruct.GetValue("Settings", "StLinkOpt");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                barSterOpt.EditValue = sValue;
    //            }
    //            sValue = myStruct.GetValue("Settings", "TimeLimit");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                iTimeLimit = MiscUtils.IntParse(sValue);
    //                if (iTimeLimit > 0)
    //                    barPurgeTime.EditValue = iTimeLimit;
    //            }
    //            //var size = this.Size;
    //            //var bounds = this.DesktopBounds.;
    //            // now read filter settings...
    //            //sValue = myStruct.GetValue("Filters", "FilterString");
    //            //if (sValue != null && sValue.Length > 0)
    //            //    gridView1.ActiveFilterString = sValue;
    //            //sValue = myStruct.GetValue("Filters", "IsExpirys");
    //            //if (MiscUtils.BoolParse(sValue))
    //            //    bChkExpirys = true;
    //            //sValue = myStruct.GetValue("Filters", "Expirys");
    //            //string[] myList = sValue.Split(new Char[] { ',' });
    //            //foreach (string item in myList)
    //            //{
    //            //    if (item.Length > 0)
    //            //        xclExpirys.Add(item);
    //            //}
    //            //sValue = myStruct.GetValue("Filters", "Options");
    //            //myList = sValue.Split(new Char[] { ',' });
    //            //foreach (string item in myList)
    //            //{
    //            //    if (item.Length > 0)
    //            //        xclOptions.Add(item);
    //            //}
    //            //sValue = myStruct.GetValue("Filters", "Underlyings");
    //            //myList = sValue.Split(new Char[] { ',' });
    //            //foreach (string item in myList)
    //            //{
    //            //    if (item.Length > 0)
    //            //        xclUnderlyings.Add(item);
    //            //}
    //        }                
    //    }
    //    catch (Exception ex)
    //    {
    //        log.Error("LoadSettings - " + ex.ToString());
    //    }

    //    LoadBarFilterSettings();
    //}

    //private void LoadBarFilterSettings()
    //{
    //    try
    //    {
    //        string sValue;
    //        // read settings file if it exists...
    //        myStruct = SettingsStructure.ReadIni(mMain.GetWindowFileName(true, iWindNum, setFileName));
    //        if (myStruct != null)
    //        {
    //            //sValue = myStruct.GetValue("Settings", "Filtered");
    //            //barFilters.Checked = false;
    //            //barFilters.Caption = "Yes";
    //            //if (sValue != null && sValue.Length > 0)
    //            //{
    //            //    if (sValue.Length > 0 && sValue == "No")
    //            //    {
    //            //        barFilters.Checked = true;
    //            //        barFilters.Caption = "No";
    //            //    }
    //            //}
    //            sValue = myStruct.GetValue("Filters", "ScreenSize");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                iScreenSize = MiscUtils.IntParse(sValue);
    //                if (iScreenSize > 0)
    //                {
    //                    barChkTrdSize.Caption = sValue;
    //                    barChkTrdSize.Checked = true;
    //                }
    //            }
    //            sValue = myStruct.GetValue("Filters", "ScreenLean");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                iScreenLean = MiscUtils.IntParse(sValue);
    //                if (iScreenLean > 0)
    //                {
    //                    barLean.Checked = true;
    //                }
    //            }
    //            sValue = myStruct.GetValue("Filters", "ScreenTradeType");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                strScreenType = sValue;
    //                this.barChkTrdType.Checked = true;
    //            }
    //            sValue = myStruct.GetValue("Filters", "SpreadAmount");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                dblScreenSprd = MiscUtils.DoubleParse(sValue);
    //                if (dblScreenSprd >= 0.01)
    //                {
    //                    barSpread.Caption = sValue;
    //                    barSpread.Checked = true;
    //                }
    //            }
    //            sValue = myStruct.GetValue("Filters", "EdgeAmount");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                dblScreenEdge = MiscUtils.DoubleParse(sValue);
    //                if (dblScreenEdge >= 0.01)
    //                {
    //                    barChkEdge.Caption = sValue;
    //                    barChkEdge.Checked = true;
    //                }
    //            }
    //            sValue = myStruct.GetValue("Filters", "LeanPercent");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                dblScreenLnPct = MiscUtils.DoubleParse(sValue);
    //                if (dblScreenLnPct >= 0.01)
    //                {
    //                    barChkLnPct.Caption = sValue;
    //                    barChkLnPct.Checked = true;
    //                }
    //            }

    //            sValue = myStruct.GetValue("Filters", "ExchangeFilters");
    //            if (sValue != null && sValue.Length > 0)
    //            {
    //                strExchFilters = sValue;
    //                this.barChkExch.Checked = true;
    //                this.barChkExch.Caption = strExchFilters;
    //            }
    //            sValue = myStruct.GetValue("Filters", "IsLeanMax");
    //            if (MiscUtils.BoolParse(sValue))
    //                bChkLeanMax = true;
    //            sValue = myStruct.GetValue("Filters", "LeanMax");
    //            if (sValue != null)
    //                iLeanMax = MiscUtils.IntParse(sValue);
    //            sValue = myStruct.GetValue("Filters", "IsLeanMin");
    //            if (sValue != null && MiscUtils.BoolParse(sValue))
    //                bChkLeanMin = true;
    //            sValue = myStruct.GetValue("Filters", "LeanMin");
    //            if (sValue != null)
    //                iLeanMax = MiscUtils.IntParse(sValue);
    //            sValue = myStruct.GetValue("Filters", "IsTradeEdge");
    //            if (sValue != null && MiscUtils.BoolParse(sValue))
    //                bChkEdge = true;
    //            sValue = myStruct.GetValue("Filters", "TradeEdge");
    //            if (sValue != null)
    //                iEdge = MiscUtils.IntParse(sValue);
    //            //sValue = myStruct.GetValue("Filters", "Exchanges");
    //            //if (sValue != null)
    //            //{
    //            //    string[] myList = sValue.Split(new Char[] { ',' });
    //            //    foreach (string item in myList)
    //            //    {
    //            //        if (item.Length > 0)
    //            //            xclExchanges.Add(item);
    //            //    }
    //            //}

    //            // Bears and Bulls
    //            sValue = myStruct.GetValue("Filters", "LongBear");
    //            if (sValue != null && MiscUtils.BoolParse(sValue))
    //                barChkLngBear.Checked = true;
    //            else
    //                barChkLngBear.Checked = false;
    //            sValue = myStruct.GetValue("Filters", "ShortBear");
    //            if (sValue != null && MiscUtils.BoolParse(sValue))
    //                barChkShtBear.Checked = true;
    //            else
    //                barChkShtBear.Checked = false;
    //            sValue = myStruct.GetValue("Filters", "LongBull");
    //            if (sValue != null && MiscUtils.BoolParse(sValue))
    //                barChkLngBull.Checked = true;
    //            else
    //                barChkLngBull.Checked = false;
    //            sValue = myStruct.GetValue("Filters", "ShortBull");
    //            if (sValue != null && MiscUtils.BoolParse(sValue))
    //                barChkShtBull.Checked = true;
    //            else
    //                barChkShtBull.Checked = false;

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        log.Error("LoadBarFilterSettings - " + ex.ToString());
    //    }
    //}

    #endregion

    #region Save Form Layout

    public void SaveFormLayout()
    {
        //doUpdate = false;

        //try
        //{
        //    layout.StoreAppearance = false;
        //    gridControl1.MainView.SaveLayoutToXml(mMain.GetWindowFileName(false, iWindNum, fileName));
        //}
        //catch (Exception ex)
        //{
        //    log.Error("SaveFormLayout - " + ex.ToString());                
        //}

        //SaveFormSettings();
        //SaveBarFilterSettings();
        //SaveUsersUnboundColumns();

        //doUpdate = true;
    }

    private void SaveBarFilterSettings()
    {
        //try
        //{
        //    if (myStruct == null)
        //        myStruct = new SettingsStructure();

        //    myStruct.AddCategory("Filters");

        //    if (!myStruct.ModifyValue("Filters", "ScreenTradeType", strScreenType))
        //        myStruct.AddValue("Filters", "ScreenTradeType", strScreenType);

        //    if (!myStruct.ModifyValue("Filters", "ScreenSize", iScreenSize.ToString()))
        //        myStruct.AddValue("Filters", "ScreenSize", iScreenSize.ToString());

        //    if (!myStruct.ModifyValue("Filters", "ScreenLean", iScreenLean.ToString()))
        //        myStruct.AddValue("Filters", "ScreenLean", iScreenLean.ToString());

        //    if (!myStruct.ModifyValue("Filters", "SpreadAmount", dblScreenSprd.ToString()))
        //        myStruct.AddValue("Filters", "SpreadAmount", dblScreenSprd.ToString());

        //    if (!myStruct.ModifyValue("Filters", "EdgeAmount", dblScreenEdge.ToString()))
        //        myStruct.AddValue("Filters", "EdgeAmount", dblScreenEdge.ToString());

        //    if (!myStruct.ModifyValue("Filters", "LeanPercent", dblScreenLnPct.ToString()))
        //        myStruct.AddValue("Filters", "LeanPercent", dblScreenLnPct.ToString());

        //    // Bears and Bulls
        //    if (!myStruct.ModifyValue("Filters", "LongBear", barChkLngBear.Checked.ToString()))
        //        myStruct.AddValue("Filters", "LongBear", barChkLngBear.Checked.ToString());
        //    if (!myStruct.ModifyValue("Filters", "ShortBear", barChkShtBear.Checked.ToString()))
        //        myStruct.AddValue("Filters", "ShortBear", barChkShtBear.Checked.ToString());
        //    if (!myStruct.ModifyValue("Filters", "LongBull", barChkLngBull.Checked.ToString()))
        //        myStruct.AddValue("Filters", "LongBull", barChkLngBull.Checked.ToString());
        //    if (!myStruct.ModifyValue("Filters", "ShortBull", barChkShtBull.Checked.ToString()))
        //        myStruct.AddValue("Filters", "ShortBull", barChkShtBull.Checked.ToString());

        //    // Button Exchange Filter
        //    if (!myStruct.ModifyValue("Filters", "IsExchangeFilters", barChkExch.Checked.ToString()))
        //        myStruct.AddValue("Filters", "IsExchangeFilters", barChkExch.Checked.ToString());
        //    if (!myStruct.ModifyValue("Filters", "ExchangeFilters", strExchFilters))
        //        myStruct.AddValue("Filters", "ExchangeFilters", strExchFilters);

        //    // Button Exchange Filter
        //    if (!myStruct.ModifyValue("Filters", "IsLeanMax", bChkLeanMax.ToString()))
        //        myStruct.AddValue("Filters", "IsLeanMax", bChkLeanMax.ToString());
        //    if (!myStruct.ModifyValue("Filters", "LeanMax", iLeanMax.ToString()))
        //        myStruct.AddValue("Filters", "LeanMax", iLeanMax.ToString());

        //    if (!myStruct.ModifyValue("Filters", "IsLeanMin", bChkLeanMin.ToString()))
        //        myStruct.AddValue("Filters", "IsLeanMin", bChkLeanMin.ToString());
        //    if (!myStruct.ModifyValue("Filters", "LeanMin", iLeanMin.ToString()))
        //        myStruct.AddValue("Filters", "LeanMin", iLeanMin.ToString());

        //    if (!myStruct.ModifyValue("Filters", "IsTradeEdge", bChkEdge.ToString()))
        //        myStruct.AddValue("Filters", "IsTradeEdge", bChkEdge.ToString());
        //    if (!myStruct.ModifyValue("Filters", "TradeEdge", iEdge.ToString()))
        //        myStruct.AddValue("Filters", "TradeEdge", iEdge.ToString());
                
        //    SettingsStructure.WriteIni(myStruct, mMain.GetWindowFileName(true, iWindNum, setFileName));
        //}
        //catch (Exception ex)
        //{
        //    log.Error("SaveBarFilterSettings - " + ex.ToString());               
        //}
    }

    private void SaveFormSettings()
    {
        //try
        //{
        //    if (myStruct == null)
        //        myStruct = new SettingsStructure();
                                
        //    myStruct.AddCategory("Settings");

        //    if (!myStruct.ModifyValue("Settings", "Top", Top.ToString()))
        //        myStruct.AddValue("Settings", "Top", Top.ToString());
        //    if (!myStruct.ModifyValue("Settings", "Left", Left.ToString()))
        //        myStruct.AddValue("Settings", "Left", Left.ToString());
        //    if (!myStruct.ModifyValue("Settings", "Width", Width.ToString()))
        //        myStruct.AddValue("Settings", "Width", Width.ToString());
        //    if (!myStruct.ModifyValue("Settings", "Height", Height.ToString()))
        //        myStruct.AddValue("Settings", "Height", Height.ToString());
        //    //if (!myStruct.ModifyValue("Settings", "LinkNum", barLinkNo.EditValue.ToString()))
        //    //    myStruct.AddValue("Settings", "LinkNum", barLinkNo.EditValue.ToString());
        //    if (!myStruct.ModifyValue("Settings", "StLinkUnd", barSterStock.EditValue.ToString()))
        //        myStruct.AddValue("Settings", "StLinkUnd", barSterStock.EditValue.ToString());
        //    if (!myStruct.ModifyValue("Settings", "StLinkOpt", barSterOpt.EditValue.ToString()))
        //        myStruct.AddValue("Settings", "StLinkOpt", barSterOpt.EditValue.ToString());
        //    if (!myStruct.ModifyValue("Settings", "FontName", gridControl1.Font.Name))
        //        myStruct.AddValue("Settings", "FontName", gridControl1.Font.Name);
        //    if (!myStruct.ModifyValue("Settings", "FontSize", gridControl1.Font.Size.ToString()))
        //        myStruct.AddValue("Settings", "FontSize", gridControl1.Font.Size.ToString());
        //    if (!myStruct.ModifyValue("Settings", "FontStyle", gridControl1.Font.Style.ToString()))
        //        myStruct.AddValue("Settings", "FontStyle", gridControl1.Font.Style.ToString());
        //    if (!myStruct.ModifyValue("Settings", "TimeLimit", barPurgeTime.EditValue.ToString()))
        //        myStruct.AddValue("Settings", "TimeLimit", barPurgeTime.EditValue.ToString());                
                
        //    SettingsStructure.WriteIni(myStruct, mMain.GetWindowFileName(true, iWindNum, setFileName));
        //}
        //catch (Exception ex)
        //{
        //    log.Error("SaveFormSettings - " + ex.ToString());                
        //}
    }

    #endregion        

    public void MainLookAndFeelStyleChanged(string name)
    {
        try
        {
            this.LookAndFeel.ActiveLookAndFeel.SkinName = name;
            //  Forces Refresh
            this.FormBorderStyle = this.FormBorderStyle;
        }
        catch (Exception ex)
        {
            log.Error("MainLookAndFeelStyleChanged - " + ex.ToString());
        }
    }
        

    public void Reload_Column(object sender, EventArgs e)
    {
        DevExpress.Utils.Menu.DXMenuCheckItem item = sender as DevExpress.Utils.Menu.DXMenuCheckItem;
        string[] getColumnName = item.Caption.Split();
        string colName = getColumnName[1];
        //mMain.UpdateFileColumn(colName, MainPanelForm.customColFilePath[colName], gridView1.Columns[colName].ColumnType);
    }
  }
}
