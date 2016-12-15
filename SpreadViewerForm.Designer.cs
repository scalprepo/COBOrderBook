using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadArbViewer
{
    public partial class SpreadViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        
        
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
      DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
      this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
      this.bar1 = new DevExpress.XtraBars.Bar();
      this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
      this.barPurgeTime = new DevExpress.XtraBars.BarEditItem();
      this.repoPurgeTime = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
      this.barReset = new DevExpress.XtraBars.BarButtonItem();
      this.barGridFont = new DevExpress.XtraBars.BarButtonItem();
      this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
      this.barSterStock = new DevExpress.XtraBars.BarEditItem();
      this.repoStStock = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
      this.barSterOpt = new DevExpress.XtraBars.BarEditItem();
      this.repoSterOption = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
      this.barCheckItemGridLines = new DevExpress.XtraBars.BarCheckItem();
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.barSymFilters = new DevExpress.XtraBars.BarCheckItem();
      this.barSpread = new DevExpress.XtraBars.BarCheckItem();
      this.barChkSym = new DevExpress.XtraBars.BarCheckItem();
      this.barChkExch = new DevExpress.XtraBars.BarCheckItem();
      this.barChkTrdSize = new DevExpress.XtraBars.BarCheckItem();
      this.barChkEdge = new DevExpress.XtraBars.BarCheckItem();
      this.barChkTrdType = new DevExpress.XtraBars.BarCheckItem();
      this.barChkLnPct = new DevExpress.XtraBars.BarCheckItem();
      this.barAddCol = new DevExpress.XtraBars.BarButtonItem();
      this.barChkLngBull = new DevExpress.XtraBars.BarCheckItem();
      this.barChkShtBull = new DevExpress.XtraBars.BarCheckItem();
      this.barChkLngBear = new DevExpress.XtraBars.BarCheckItem();
      this.barChkShtBear = new DevExpress.XtraBars.BarCheckItem();
      this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
      this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
      this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
      this.barDelCol = new DevExpress.XtraBars.BarButtonItem();
      this.barLean = new DevExpress.XtraBars.BarCheckItem();
      this.barUndLink = new DevExpress.XtraBars.BarButtonItem();
      this.barOptLink = new DevExpress.XtraBars.BarButtonItem();
      this.barLinkNo = new DevExpress.XtraBars.BarEditItem();
      this.repoLinkNo = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
      this.repoGridFont = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
      this.gridControl2 = new DevExpress.XtraGrid.GridControl();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoPurgeTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoStStock)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoSterOption)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoLinkNo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoGridFont)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
      this.splitContainerControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
      this.SuspendLayout();
      // 
      // barManager1
      // 
      this.barManager1.AllowCustomization = false;
      this.barManager1.AllowMoveBarOnToolbar = false;
      this.barManager1.AllowQuickCustomization = false;
      this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
      this.barManager1.DockControls.Add(this.barDockControlTop);
      this.barManager1.DockControls.Add(this.barDockControlBottom);
      this.barManager1.DockControls.Add(this.barDockControlLeft);
      this.barManager1.DockControls.Add(this.barDockControlRight);
      this.barManager1.Form = this;
      this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barPurgeTime,
            this.barStaticItem1,
            this.barSymFilters,
            this.barSpread,
            this.barChkSym,
            this.barChkExch,
            this.barChkTrdSize,
            this.barChkEdge,
            this.barChkTrdType,
            this.barChkLnPct,
            this.barAddCol,
            this.barChkLngBull,
            this.barChkShtBull,
            this.barChkLngBear,
            this.barChkShtBear,
            this.barStaticItem3,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barDelCol,
            this.barLean,
            this.barUndLink,
            this.barOptLink,
            this.barReset,
            this.barLinkNo,
            this.barGridFont,
            this.barSterStock,
            this.barSterOpt,
            this.barStaticItem2,
            this.barCheckItemGridLines});
      this.barManager1.MaxItemId = 26;
      this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoPurgeTime,
            this.repoLinkNo,
            this.repoGridFont,
            this.repoStStock,
            this.repoSterOption});
      // 
      // bar1
      // 
      this.bar1.BarItemVertIndent = 5;
      this.bar1.BarName = "Tools";
      this.bar1.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)((DevExpress.XtraBars.BarCanDockStyle.Left | DevExpress.XtraBars.BarCanDockStyle.Top)));
      this.bar1.DockCol = 0;
      this.bar1.DockRow = 0;
      this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
      this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.Caption | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.barPurgeTime, "PurgeTime:", false, true, true, 50),
            new DevExpress.XtraBars.LinkPersistInfo(this.barReset),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.barGridFont, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "", ""),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem2),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barSterStock, "", false, true, true, 44),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barSterOpt, "", false, true, true, 44),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemGridLines)});
      this.bar1.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
      this.bar1.OptionsBar.DisableClose = true;
      this.bar1.OptionsBar.UseWholeRow = true;
      this.bar1.Text = "Tools";
      // 
      // barStaticItem1
      // 
      this.barStaticItem1.Caption = "Minutes:";
      this.barStaticItem1.Id = 2;
      this.barStaticItem1.Name = "barStaticItem1";
      this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
      // 
      // barPurgeTime
      // 
      this.barPurgeTime.Caption = "PurgeTime:";
      this.barPurgeTime.Description = "Max Time Trades in Window";
      this.barPurgeTime.Edit = this.repoPurgeTime;
      this.barPurgeTime.EditValue = "5";
      this.barPurgeTime.Enabled = false;
      this.barPurgeTime.Hint = "Max Time trades are kept";
      this.barPurgeTime.Id = 1;
      this.barPurgeTime.Name = "barPurgeTime";
      this.barPurgeTime.EditValueChanged += new System.EventHandler(this.barPurgeTime_EditValueChanged);
      // 
      // repoPurgeTime
      // 
      this.repoPurgeTime.AutoHeight = false;
      this.repoPurgeTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.repoPurgeTime.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.repoPurgeTime.IsFloatValue = false;
      this.repoPurgeTime.Mask.EditMask = "N00";
      this.repoPurgeTime.MaxValue = new decimal(new int[] {
            390,
            0,
            0,
            0});
      this.repoPurgeTime.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.repoPurgeTime.Name = "repoPurgeTime";
      // 
      // barReset
      // 
      this.barReset.Caption = "Clear";
      this.barReset.Hint = "Clear Data Grid";
      this.barReset.Id = 6;
      this.barReset.Name = "barReset";
      this.barReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClearGrid_ItemClick);
      // 
      // barGridFont
      // 
      this.barGridFont.Caption = "Font";
      this.barGridFont.Description = "Set Grids Font";
      this.barGridFont.Hint = "Sets Grids Font";
      this.barGridFont.Id = 9;
      this.barGridFont.Name = "barGridFont";
      this.barGridFont.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barGridFont_ItemClick);
      // 
      // barStaticItem2
      // 
      this.barStaticItem2.Caption = "Sterling:";
      this.barStaticItem2.Id = 12;
      this.barStaticItem2.Name = "barStaticItem2";
      this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
      // 
      // barSterStock
      // 
      this.barSterStock.Caption = "SterStock";
      this.barSterStock.Edit = this.repoStStock;
      this.barSterStock.EditValue = "1";
      this.barSterStock.Enabled = false;
      this.barSterStock.Hint = "StLink StockGroup";
      this.barSterStock.Id = 10;
      this.barSterStock.Name = "barSterStock";
      // 
      // repoStStock
      // 
      this.repoStStock.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
      this.repoStStock.AutoHeight = false;
      this.repoStStock.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.repoStStock.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.repoStStock.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.repoStStock.IsFloatValue = false;
      this.repoStStock.Mask.EditMask = "N00";
      this.repoStStock.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.repoStStock.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.repoStStock.Name = "repoStStock";
      this.repoStStock.NullText = "1";
      // 
      // barSterOpt
      // 
      this.barSterOpt.Caption = "SterOption";
      this.barSterOpt.Edit = this.repoSterOption;
      this.barSterOpt.EditValue = "2";
      this.barSterOpt.Enabled = false;
      this.barSterOpt.Hint = "StLink OptGroup";
      this.barSterOpt.Id = 11;
      this.barSterOpt.Name = "barSterOpt";
      // 
      // repoSterOption
      // 
      this.repoSterOption.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
      this.repoSterOption.AutoHeight = false;
      this.repoSterOption.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.repoSterOption.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.repoSterOption.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.repoSterOption.IsFloatValue = false;
      this.repoSterOption.Mask.EditMask = "N00";
      this.repoSterOption.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.repoSterOption.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.repoSterOption.Name = "repoSterOption";
      this.repoSterOption.NullText = "2";
      // 
      // barCheckItemGridLines
      // 
      this.barCheckItemGridLines.Caption = "GridLines";
      this.barCheckItemGridLines.Id = 15;
      this.barCheckItemGridLines.Name = "barCheckItemGridLines";
      this.barCheckItemGridLines.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItemGridLines_CheckedChanged);
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Size = new System.Drawing.Size(1423, 33);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 675);
      this.barDockControlBottom.Size = new System.Drawing.Size(1423, 0);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 642);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(1423, 33);
      this.barDockControlRight.Size = new System.Drawing.Size(0, 642);
      // 
      // barSymFilters
      // 
      this.barSymFilters.Caption = "SymbolFilter";
      this.barSymFilters.Hint = "Turn On/Off Symbol Filter";
      this.barSymFilters.Id = 3;
      this.barSymFilters.ItemAppearance.Normal.BackColor = System.Drawing.Color.LightCoral;
      this.barSymFilters.ItemAppearance.Normal.Options.UseBackColor = true;
      this.barSymFilters.ItemAppearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.barSymFilters.ItemAppearance.Pressed.Options.UseBackColor = true;
      this.barSymFilters.Name = "barSymFilters";
      this.barSymFilters.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barSymFilters_CheckedChanged);
      // 
      // barSpread
      // 
      this.barSpread.Id = 16;
      this.barSpread.Name = "barSpread";
      // 
      // barChkSym
      // 
      this.barChkSym.Id = 17;
      this.barChkSym.Name = "barChkSym";
      // 
      // barChkExch
      // 
      this.barChkExch.Id = 18;
      this.barChkExch.Name = "barChkExch";
      // 
      // barChkTrdSize
      // 
      this.barChkTrdSize.Id = 19;
      this.barChkTrdSize.Name = "barChkTrdSize";
      // 
      // barChkEdge
      // 
      this.barChkEdge.Id = 20;
      this.barChkEdge.Name = "barChkEdge";
      // 
      // barChkTrdType
      // 
      this.barChkTrdType.Id = 21;
      this.barChkTrdType.Name = "barChkTrdType";
      // 
      // barChkLnPct
      // 
      this.barChkLnPct.Id = 22;
      this.barChkLnPct.Name = "barChkLnPct";
      // 
      // barAddCol
      // 
      this.barAddCol.Caption = "AddCol";
      this.barAddCol.CausesValidation = true;
      this.barAddCol.Enabled = false;
      this.barAddCol.Hint = "Add New Col";
      this.barAddCol.Id = 20;
      this.barAddCol.Name = "barAddCol";
      this.barAddCol.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAddCol_ItemClick);
      // 
      // barChkLngBull
      // 
      this.barChkLngBull.Caption = "LB";
      this.barChkLngBull.Hint = "LongBull";
      this.barChkLngBull.Id = 24;
      this.barChkLngBull.Name = "barChkLngBull";
      // 
      // barChkShtBull
      // 
      this.barChkShtBull.Caption = "SB";
      this.barChkShtBull.Id = 25;
      this.barChkShtBull.Name = "barChkShtBull";
      // 
      // barChkLngBear
      // 
      this.barChkLngBear.Caption = "LR";
      this.barChkLngBear.Id = 27;
      this.barChkLngBear.Name = "barChkLngBear";
      // 
      // barChkShtBear
      // 
      this.barChkShtBear.Caption = "SR";
      this.barChkShtBear.Id = 28;
      this.barChkShtBear.Name = "barChkShtBear";
      // 
      // barStaticItem3
      // 
      this.barStaticItem3.Caption = "RealTick:";
      this.barStaticItem3.Id = 29;
      this.barStaticItem3.Name = "barStaticItem3";
      this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
      // 
      // barButtonItem1
      // 
      this.barButtonItem1.Id = 13;
      this.barButtonItem1.Name = "barButtonItem1";
      // 
      // barButtonItem2
      // 
      this.barButtonItem2.Id = 14;
      this.barButtonItem2.Name = "barButtonItem2";
      // 
      // barDelCol
      // 
      this.barDelCol.Caption = "DelCol";
      this.barDelCol.Enabled = false;
      this.barDelCol.Hint = "Remove Col";
      this.barDelCol.Id = 34;
      this.barDelCol.Name = "barDelCol";
      this.barDelCol.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDelCol_ItemClick);
      // 
      // barLean
      // 
      this.barLean.Id = 23;
      this.barLean.Name = "barLean";
      // 
      // barUndLink
      // 
      this.barUndLink.Id = 24;
      this.barUndLink.Name = "barUndLink";
      // 
      // barOptLink
      // 
      this.barOptLink.Id = 25;
      this.barOptLink.Name = "barOptLink";
      // 
      // barLinkNo
      // 
      this.barLinkNo.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
      this.barLinkNo.Caption = "Link Num";
      this.barLinkNo.Description = "Linkage Number";
      this.barLinkNo.Edit = this.repoLinkNo;
      this.barLinkNo.EditValue = "0";
      this.barLinkNo.Hint = "Trading Linkage Number";
      this.barLinkNo.Id = 7;
      this.barLinkNo.Name = "barLinkNo";
      // 
      // repoLinkNo
      // 
      this.repoLinkNo.AutoHeight = false;
      this.repoLinkNo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.repoLinkNo.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.repoLinkNo.IsFloatValue = false;
      this.repoLinkNo.Mask.EditMask = "N00";
      this.repoLinkNo.MaxValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
      this.repoLinkNo.Name = "repoLinkNo";
      this.repoLinkNo.NullText = "0";
      // 
      // repoGridFont
      // 
      this.repoGridFont.AutoHeight = false;
      this.repoGridFont.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repoGridFont.Name = "repoGridFont";
      // 
      // gridControl1
      // 
      this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl1.Location = new System.Drawing.Point(0, 0);
      this.gridControl1.LookAndFeel.SkinName = "Black";
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(703, 638);
      this.gridControl1.TabIndex = 4;
      this.gridControl1.TabStop = false;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // gridView1
      // 
      this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
      this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
      this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
      this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
      this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
      this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
      this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
      this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
      this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
      this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.White;
      this.gridView1.Appearance.Empty.Options.UseBackColor = true;
      this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
      this.gridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
      this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
      this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
      this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
      this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
      this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
      this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.DimGray;
      this.gridView1.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
      this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
      this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
      this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
      this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
      this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
      this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
      this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
      this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
      this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.White;
      this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
      this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
      this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
      this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
      this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.Gray;
      this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.White;
      this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.DimGray;
      this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
      this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
      this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
      this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
      this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
      this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
      this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
      this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
      this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Yellow;
      this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
      this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.White;
      this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.Purple;
      this.gridView1.Appearance.Preview.Options.UseBackColor = true;
      this.gridView1.Appearance.Preview.Options.UseForeColor = true;
      this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.Black;
      this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.White;
      this.gridView1.Appearance.Row.Options.UseBackColor = true;
      this.gridView1.Appearance.Row.Options.UseForeColor = true;
      this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
      this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
      this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
      this.gridView1.Appearance.TopNewRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.gridView1.Appearance.TopNewRow.Options.UseForeColor = true;
      this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Yellow;
      this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
      this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsBehavior.KeepFocusedRowOnUpdate = false;
      this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
      this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
      this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
      this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.OptionsView.ShowIndicator = false;
      this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
      this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
      this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
      this.gridView1.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridView1_CalcRowHeight);
      this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
      this.gridView1.CustomRowFilter += new DevExpress.XtraGrid.Views.Base.RowFilterEventHandler(this.gridView1_CustomRowFilter);
      this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
      this.gridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseUp);
      this.gridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseMove);
      this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
      this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
      // 
      // splitContainerControl1
      // 
      this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
      this.splitContainerControl1.Location = new System.Drawing.Point(0, 33);
      this.splitContainerControl1.Name = "splitContainerControl1";
      this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
      this.splitContainerControl1.Panel1.Text = "Buy Orders";
      this.splitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.splitContainerControl1.Panel2.Controls.Add(this.gridControl2);
      this.splitContainerControl1.Panel2.Text = "Sell Orders";
      this.splitContainerControl1.Size = new System.Drawing.Size(1423, 642);
      this.splitContainerControl1.SplitterPosition = 707;
      this.splitContainerControl1.TabIndex = 9;
      this.splitContainerControl1.Text = "splitContainerControl1";
      // 
      // gridControl2
      // 
      this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl2.Location = new System.Drawing.Point(0, 0);
      this.gridControl2.LookAndFeel.SkinName = "Black";
      this.gridControl2.MainView = this.gridView2;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.Size = new System.Drawing.Size(707, 638);
      this.gridControl2.TabIndex = 5;
      this.gridControl2.TabStop = false;
      this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
      // 
      // gridView2
      // 
      this.gridView2.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.gridView2.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Gray;
      this.gridView2.Appearance.ColumnFilterButton.Options.UseBackColor = true;
      this.gridView2.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
      this.gridView2.Appearance.ColumnFilterButton.Options.UseForeColor = true;
      this.gridView2.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.gridView2.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
      this.gridView2.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.gridView2.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Blue;
      this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
      this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
      this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
      this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.White;
      this.gridView2.Appearance.Empty.Options.UseBackColor = true;
      this.gridView2.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
      this.gridView2.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
      this.gridView2.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
      this.gridView2.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.gridView2.Appearance.FilterCloseButton.Options.UseBackColor = true;
      this.gridView2.Appearance.FilterCloseButton.Options.UseBorderColor = true;
      this.gridView2.Appearance.FilterCloseButton.Options.UseForeColor = true;
      this.gridView2.Appearance.FilterPanel.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
      this.gridView2.Appearance.FilterPanel.ForeColor = System.Drawing.Color.DimGray;
      this.gridView2.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
      this.gridView2.Appearance.FilterPanel.Options.UseBackColor = true;
      this.gridView2.Appearance.FilterPanel.Options.UseForeColor = true;
      this.gridView2.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
      this.gridView2.Appearance.FixedLine.Options.UseBackColor = true;
      this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
      this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
      this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
      this.gridView2.Appearance.FooterPanel.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.FooterPanel.BorderColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
      this.gridView2.Appearance.FooterPanel.Options.UseBackColor = true;
      this.gridView2.Appearance.FooterPanel.Options.UseBorderColor = true;
      this.gridView2.Appearance.FooterPanel.Options.UseForeColor = true;
      this.gridView2.Appearance.GroupButton.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.GroupButton.BorderColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
      this.gridView2.Appearance.GroupButton.Options.UseBackColor = true;
      this.gridView2.Appearance.GroupButton.Options.UseBorderColor = true;
      this.gridView2.Appearance.GroupButton.Options.UseForeColor = true;
      this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
      this.gridView2.Appearance.GroupFooter.ForeColor = System.Drawing.Color.White;
      this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
      this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
      this.gridView2.Appearance.GroupFooter.Options.UseForeColor = true;
      this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
      this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridView2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
      this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
      this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
      this.gridView2.Appearance.GroupPanel.Options.UseForeColor = true;
      this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.Gray;
      this.gridView2.Appearance.GroupRow.BorderColor = System.Drawing.Color.White;
      this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.DimGray;
      this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
      this.gridView2.Appearance.GroupRow.Options.UseBorderColor = true;
      this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
      this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
      this.gridView2.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.DimGray;
      this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
      this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
      this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
      this.gridView2.Appearance.HeaderPanel.Options.UseForeColor = true;
      this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Yellow;
      this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
      this.gridView2.Appearance.Preview.BackColor = System.Drawing.Color.White;
      this.gridView2.Appearance.Preview.ForeColor = System.Drawing.Color.Purple;
      this.gridView2.Appearance.Preview.Options.UseBackColor = true;
      this.gridView2.Appearance.Preview.Options.UseForeColor = true;
      this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.Black;
      this.gridView2.Appearance.Row.ForeColor = System.Drawing.Color.White;
      this.gridView2.Appearance.Row.Options.UseBackColor = true;
      this.gridView2.Appearance.Row.Options.UseForeColor = true;
      this.gridView2.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
      this.gridView2.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
      this.gridView2.Appearance.RowSeparator.Options.UseBackColor = true;
      this.gridView2.Appearance.TopNewRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.gridView2.Appearance.TopNewRow.Options.UseForeColor = true;
      this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Yellow;
      this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
      this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
      this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
      this.gridView2.GridControl = this.gridControl2;
      this.gridView2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsBehavior.Editable = false;
      this.gridView2.OptionsBehavior.KeepFocusedRowOnUpdate = false;
      this.gridView2.OptionsMenu.EnableGroupPanelMenu = false;
      this.gridView2.OptionsNavigation.AutoMoveRowFocus = false;
      this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.gridView2.OptionsSelection.EnableAppearanceHideSelection = false;
      this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      this.gridView2.OptionsView.ShowIndicator = false;
      this.gridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
      // 
      // SpreadViewerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1423, 675);
      this.Controls.Add(this.splitContainerControl1);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.Name = "SpreadViewerForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TradesView_FormClosing);
      this.Load += new System.EventHandler(this.OptionView_Load);
      this.Shown += new System.EventHandler(this.TradesView_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoPurgeTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoStStock)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoSterOption)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoLinkNo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repoGridFont)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
      this.splitContainerControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }
        #endregion

        protected DevExpress.XtraGrid.GridControl gridControl1;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraBars.Bar bar1;
        protected DevExpress.XtraBars.BarEditItem barLinkNo;
        protected DevExpress.XtraBars.BarEditItem barSterStock;
        protected DevExpress.XtraBars.BarEditItem barSterOpt;        
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarButtonItem barUndLink;
        protected DevExpress.XtraBars.BarButtonItem barOptLink;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repoLinkNo;
        protected DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repoGridFont;
        protected DevExpress.XtraBars.BarButtonItem barGridFont;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repoStStock;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repoSterOption;
        protected DevExpress.XtraBars.BarStaticItem barStaticItem2;
        protected DevExpress.XtraBars.BarButtonItem barReset;
        protected DevExpress.XtraBars.BarEditItem barPurgeTime;
        protected DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repoPurgeTime;
        protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        protected DevExpress.XtraBars.BarCheckItem barSymFilters;
        protected DevExpress.XtraBars.BarCheckItem barSpread;
        protected DevExpress.XtraBars.BarCheckItem barChkSym;
        protected DevExpress.XtraBars.BarCheckItem barChkExch;
        protected DevExpress.XtraBars.BarCheckItem barChkTrdSize;
        protected DevExpress.XtraBars.BarCheckItem barChkEdge;
        protected DevExpress.XtraBars.BarCheckItem barChkTrdType;
        protected DevExpress.XtraBars.BarCheckItem barChkLnPct;
        protected DevExpress.XtraBars.BarButtonItem barAddCol;        
        
        
        protected DevExpress.XtraBars.BarCheckItem barChkLngBull;
        protected DevExpress.XtraBars.BarCheckItem barChkShtBull;
        protected DevExpress.XtraBars.BarCheckItem barChkLngBear;
        protected DevExpress.XtraBars.BarCheckItem barChkShtBear;
        protected DevExpress.XtraBars.BarStaticItem barStaticItem3;        

        protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        protected DevExpress.XtraBars.BarButtonItem barDelCol;


        protected DevExpress.XtraBars.BarCheckItem barLean;
        private DevExpress.XtraBars.BarCheckItem barCheckItemGridLines;
    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    protected DevExpress.XtraGrid.GridControl gridControl2;
    protected DevExpress.XtraGrid.Views.Grid.GridView gridView2;
  }
}

