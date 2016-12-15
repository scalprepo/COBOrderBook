using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Logger.config", Watch = true)]

namespace SpreadArbViewer
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        static private DateTime TrialEnds = new DateTime(2016, 12, 30);
        //static private Thread formThreads;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main()
        {
            CreateDirectory();
            log.Info("Starting Main --------------------------------------------------------------------------------");
            try
            {
                log.Info("Running Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                TimeSpan DaysLeft = TrialEnds.Subtract(DateTime.Now);
                if (DaysLeft.Days > 0)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                    BonusSkins.Register();
                    SkinManager.EnableFormSkins();
                    UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                    //Application.Run(new SpreadArbViewerForm());
                    Application.Run(new SpreadViewerForm());

                }
                else
                {
                    MessageBox.Show("Please contact support.");
                }
            }
            catch (Exception ex)
            {
                log.Error("Main1 - " + ex.ToString());
            }
        }

        static void CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory("Logs");
                Directory.CreateDirectory("config");
            }
            catch (Exception ex)
            {
                log.Error("CreateDirectory - " + ex.ToString());
            }

        }
    }
}
