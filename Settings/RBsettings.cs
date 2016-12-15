using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTrader
{
    public class RBAppSettings
    {
        public const string setFileName = ".\\config\\RBtrader.ini";

        public const int MAX_FORMS = 10;
        public int SetMaxForms { get; set; }
        public int tradeOrdSequence { get; set; }
        
        public int trFormCount { get; set; }        
        public int mpFormCount { get; set; }        

        public double dSizeRCheck { get; set; }        
        
        public string SkinName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public bool mbRounding { get; set; }
        public bool bAutoConnect { get; set; }
        public bool bRBMulticast { get; set; }
        public bool connected { get; set; }
        public bool sessionLogin { get; set; }
        public List<WinInfo> winInfo { get; set; }

        // Networking Settings        
        public string rbAddress { get; set; }
        public int rbPort { get; set; }
        public string rbMultiCastAddress { get; set; }
        public int rbMcPort { get; set; }
        public string rbMcInterface { get; set; }
        public string rbDBAddress { get; set; }
        public int rbDBPort { get; set; }

        public RBAppSettings()
        {
            rbDBAddress = "10.0.7.150";
            rbDBPort = 3306;
        }
        
    }
    public struct WinInfo
    {
        public short vType;
        public byte winNum;
    }
}
