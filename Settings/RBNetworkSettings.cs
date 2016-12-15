using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Collections;

namespace RBTrader
{
    public partial class RBNetworkSettings : DevExpress.XtraEditors.XtraForm
    {
        private string previousMCIntf;


        public RBNetworkSettings()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtRBDBAddress_EditValueChanged(object sender, EventArgs e)
        {
            var test = 1;
        }
    }
}