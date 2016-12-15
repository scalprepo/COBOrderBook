namespace RBTrader
{
    partial class RBNetworkSettings
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
            this.cmdOK = new DevExpress.XtraEditors.SimpleButton();
            this.cmdCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkAuto = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtRBAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtRBPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMCAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMCPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtRBMCIntf = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chkMC = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.textEditRBDBPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControlRBDBPort = new DevExpress.XtraEditors.LabelControl();
            this.textEditRBDBAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControlRBDBAddress = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRBAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRBPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMCAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMCPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRBMCIntf.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRBDBPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRBDBAddress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(234, 21);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(71, 23);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(234, 47);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(71, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Auto Connect:";
            // 
            // chkAuto
            // 
            this.chkAuto.Location = new System.Drawing.Point(100, 19);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Properties.Caption = "";
            this.chkAuto.Size = new System.Drawing.Size(75, 19);
            this.chkAuto.TabIndex = 4;
            this.chkAuto.ToolTip = "Auto Connect at Startup";
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "RB Address:";
            // 
            // txtRBAddress
            // 
            this.txtRBAddress.Location = new System.Drawing.Point(102, 44);
            this.txtRBAddress.Name = "txtRBAddress";
            this.txtRBAddress.Properties.ReadOnly = true;
            this.txtRBAddress.Size = new System.Drawing.Size(100, 20);
            this.txtRBAddress.TabIndex = 6;
            this.txtRBAddress.ToolTip = "Address of Server";
            // 
            // txtRBPort
            // 
            this.txtRBPort.Location = new System.Drawing.Point(102, 70);
            this.txtRBPort.Name = "txtRBPort";
            this.txtRBPort.Properties.ReadOnly = true;
            this.txtRBPort.Size = new System.Drawing.Size(100, 20);
            this.txtRBPort.TabIndex = 8;
            this.txtRBPort.ToolTip = "Port of Server";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "RB Port:";
            // 
            // txtMCAddress
            // 
            this.txtMCAddress.Location = new System.Drawing.Point(102, 124);
            this.txtMCAddress.Name = "txtMCAddress";
            this.txtMCAddress.Properties.ReadOnly = true;
            this.txtMCAddress.Size = new System.Drawing.Size(100, 20);
            this.txtMCAddress.TabIndex = 10;
            this.txtMCAddress.ToolTip = "Multicast Address";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 128);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "RB MCAddress:";
            // 
            // txtMCPort
            // 
            this.txtMCPort.Location = new System.Drawing.Point(102, 150);
            this.txtMCPort.Name = "txtMCPort";
            this.txtMCPort.Properties.ReadOnly = true;
            this.txtMCPort.Size = new System.Drawing.Size(100, 20);
            this.txtMCPort.TabIndex = 12;
            this.txtMCPort.ToolTip = "Multicast Port";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 154);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "RB MCPort:";
            // 
            // txtRBMCIntf
            // 
            this.txtRBMCIntf.Location = new System.Drawing.Point(102, 176);
            this.txtRBMCIntf.Name = "txtRBMCIntf";
            this.txtRBMCIntf.Properties.ReadOnly = true;
            this.txtRBMCIntf.Size = new System.Drawing.Size(100, 20);
            this.txtRBMCIntf.TabIndex = 14;
            this.txtRBMCIntf.ToolTip = "Multicast Interface";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 180);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(80, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "RB MCInterface:";
            // 
            // chkMC
            // 
            this.chkMC.Location = new System.Drawing.Point(100, 98);
            this.chkMC.Name = "chkMC";
            this.chkMC.Properties.Caption = "";
            this.chkMC.Size = new System.Drawing.Size(75, 19);
            this.chkMC.TabIndex = 16;
            this.chkMC.ToolTip = "Using Multicast";
            this.chkMC.CheckedChanged += new System.EventHandler(this.chkMC_CheckedChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 100);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(46, 13);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Multicast:";
            // 
            // textEditRBDBPort
            // 
            this.textEditRBDBPort.Location = new System.Drawing.Point(102, 233);
            this.textEditRBDBPort.Name = "textEditRBDBPort";
            this.textEditRBDBPort.Size = new System.Drawing.Size(100, 20);
            this.textEditRBDBPort.TabIndex = 24;
            this.textEditRBDBPort.ToolTip = "Port of  RB DataBase";
            // 
            // labelControlRBDBPort
            // 
            this.labelControlRBDBPort.Location = new System.Drawing.Point(12, 237);
            this.labelControlRBDBPort.Name = "labelControlRBDBPort";
            this.labelControlRBDBPort.Size = new System.Drawing.Size(53, 13);
            this.labelControlRBDBPort.TabIndex = 23;
            this.labelControlRBDBPort.Text = "RBDB Port:";
            // 
            // textEditRBDBAddress
            // 
            this.textEditRBDBAddress.Location = new System.Drawing.Point(102, 207);
            this.textEditRBDBAddress.Name = "textEditRBDBAddress";
            this.textEditRBDBAddress.Size = new System.Drawing.Size(100, 20);
            this.textEditRBDBAddress.TabIndex = 22;
            this.textEditRBDBAddress.ToolTip = "Address of RB DataBase";
            // 
            // labelControlRBDBAddress
            // 
            this.labelControlRBDBAddress.Location = new System.Drawing.Point(12, 211);
            this.labelControlRBDBAddress.Name = "labelControlRBDBAddress";
            this.labelControlRBDBAddress.Size = new System.Drawing.Size(72, 13);
            this.labelControlRBDBAddress.TabIndex = 21;
            this.labelControlRBDBAddress.Text = "RBDB Address:";
            // 
            // RBNetworkSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 277);
            this.Controls.Add(this.textEditRBDBPort);
            this.Controls.Add(this.labelControlRBDBPort);
            this.Controls.Add(this.textEditRBDBAddress);
            this.Controls.Add(this.labelControlRBDBAddress);
            this.Controls.Add(this.chkMC);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtRBMCIntf);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtMCPort);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtMCAddress);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtRBPort);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtRBAddress);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RBNetworkSettings";
            this.Text = "RBTrader Settings";
            ((System.ComponentModel.ISupportInitialize)(this.chkAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRBAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRBPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMCAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMCPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRBMCIntf.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRBDBPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRBDBAddress.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdOK;
        private DevExpress.XtraEditors.SimpleButton cmdCancel;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.CheckEdit chkAuto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtRBAddress;
        public DevExpress.XtraEditors.TextEdit txtRBPort;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtMCAddress;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtMCPort;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtRBMCIntf;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.CheckEdit chkMC;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit textEditRBDBPort;
        public DevExpress.XtraEditors.LabelControl labelControlRBDBPort;
        public DevExpress.XtraEditors.TextEdit textEditRBDBAddress;
        public DevExpress.XtraEditors.LabelControl labelControlRBDBAddress;
    }
}