namespace WillisDocControl
{
    partial class frmDocControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocControl));
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSelectFolder = new System.Windows.Forms.Button();
            this.txtPolicyNo = new System.Windows.Forms.TextBox();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.dtScanDate = new System.Windows.Forms.DateTimePicker();
            this.dtEOAHDate = new System.Windows.Forms.DateTimePicker();
            this.cmbAH = new System.Windows.Forms.ComboBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.fldrBrowserSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.txtUID = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkNoLink = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.acroPDF = new AxAcroPDFLib.AxAcroPDF();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSettings = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acroPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSubmit.Location = new System.Drawing.Point(0, 0);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(80, 93);
            this.cmdSubmit.TabIndex = 0;
            this.cmdSubmit.Text = "&Save and Send";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // txtLink
            // 
            this.txtLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLink.Location = new System.Drawing.Point(0, 0);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(638, 20);
            this.txtLink.TabIndex = 0;
            this.txtLink.Text = "Link to the policy folder will appear here";
            this.txtLink.Enter += new System.EventHandler(this.txtLink_Enter);
            this.txtLink.Leave += new System.EventHandler(this.txtLink_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(111, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Doc Receive Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(293, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Doc Scan Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(460, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email to A/H Date";
            // 
            // cmdSelectFolder
            // 
            this.cmdSelectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdSelectFolder.Location = new System.Drawing.Point(0, 0);
            this.cmdSelectFolder.Name = "cmdSelectFolder";
            this.cmdSelectFolder.Size = new System.Drawing.Size(72, 119);
            this.cmdSelectFolder.TabIndex = 0;
            this.cmdSelectFolder.Text = "Select Policy Folder";
            this.cmdSelectFolder.UseVisualStyleBackColor = true;
            this.cmdSelectFolder.Click += new System.EventHandler(this.cmdSelectFolder_Click);
            // 
            // txtPolicyNo
            // 
            this.txtPolicyNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPolicyNo.Location = new System.Drawing.Point(84, 0);
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Size = new System.Drawing.Size(194, 20);
            this.txtPolicyNo.TabIndex = 1;
            this.txtPolicyNo.Text = "Policy & Endt #s";
            this.txtPolicyNo.Enter += new System.EventHandler(this.txtPolicyNo_Enter);
            this.txtPolicyNo.Leave += new System.EventHandler(this.txtPolicyNo_Leave);
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.Checked = false;
            this.dtReceiveDate.CustomFormat = "";
            this.dtReceiveDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtReceiveDate.Location = new System.Drawing.Point(207, 0);
            this.dtReceiveDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtReceiveDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(86, 20);
            this.dtReceiveDate.TabIndex = 3;
            // 
            // dtScanDate
            // 
            this.dtScanDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtScanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtScanDate.Location = new System.Drawing.Point(374, 0);
            this.dtScanDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtScanDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtScanDate.Name = "dtScanDate";
            this.dtScanDate.Size = new System.Drawing.Size(86, 20);
            this.dtScanDate.TabIndex = 5;
            // 
            // dtEOAHDate
            // 
            this.dtEOAHDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtEOAHDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEOAHDate.Location = new System.Drawing.Point(553, 0);
            this.dtEOAHDate.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtEOAHDate.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtEOAHDate.Name = "dtEOAHDate";
            this.dtEOAHDate.Size = new System.Drawing.Size(86, 20);
            this.dtEOAHDate.TabIndex = 7;
            // 
            // cmbAH
            // 
            this.cmbAH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAH.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbAH.FormattingEnabled = true;
            this.cmbAH.Location = new System.Drawing.Point(278, 0);
            this.cmbAH.Name = "cmbAH";
            this.cmbAH.Size = new System.Drawing.Size(177, 21);
            this.cmbAH.TabIndex = 2;
            this.cmbAH.Text = "Select Account Handler";
            this.cmbAH.Leave += new System.EventHandler(this.cmbAH_Leave);
            // 
            // txtSubject
            // 
            this.txtSubject.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSubject.Location = new System.Drawing.Point(0, 37);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(638, 20);
            this.txtSubject.TabIndex = 2;
            this.txtSubject.Text = "Subject line will be previewed here";
            // 
            // cmbDocType
            // 
            this.cmbDocType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDocType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Location = new System.Drawing.Point(0, 0);
            this.cmbDocType.Name = "cmbDocType";
            this.cmbDocType.Size = new System.Drawing.Size(84, 21);
            this.cmbDocType.TabIndex = 0;
            this.cmbDocType.Text = "Doc Type";
            this.cmbDocType.Leave += new System.EventHandler(this.cmbDocType_Leave);
            // 
            // txtUID
            // 
            this.txtUID.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtUID.Location = new System.Drawing.Point(36, 0);
            this.txtUID.Mask = "000000000";
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(75, 20);
            this.txtUID.TabIndex = 0;
            this.txtUID.Leave += new System.EventHandler(this.txtUID_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UID #";
            // 
            // chkNoLink
            // 
            this.chkNoLink.AutoSize = true;
            this.chkNoLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkNoLink.Location = new System.Drawing.Point(0, 20);
            this.chkNoLink.Name = "chkNoLink";
            this.chkNoLink.Size = new System.Drawing.Size(638, 17);
            this.chkNoLink.TabIndex = 1;
            this.chkNoLink.Text = "No Link Available";
            this.chkNoLink.UseVisualStyleBackColor = true;
            this.chkNoLink.CheckedChanged += new System.EventHandler(this.chkNoLink_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 119);
            this.panel1.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmbAH);
            this.panel6.Controls.Add(this.txtPolicyNo);
            this.panel6.Controls.Add(this.cmbDocType);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(72, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(638, 28);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtSubject);
            this.panel5.Controls.Add(this.chkNoLink);
            this.panel5.Controls.Add(this.txtLink);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(72, 54);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(638, 65);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmdSubmit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(710, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(80, 93);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmdSettings);
            this.panel3.Controls.Add(this.dtEOAHDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dtScanDate);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtReceiveDate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtUID);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(72, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 26);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdSelectFolder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 119);
            this.panel2.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.cmdCancel);
            this.panel7.Controls.Add(this.acroPDF);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(790, 253);
            this.panel7.TabIndex = 16;
            // 
            // acroPDF
            // 
            this.acroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acroPDF.Enabled = true;
            this.acroPDF.Location = new System.Drawing.Point(0, 0);
            this.acroPDF.Name = "acroPDF";
            this.acroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("acroPDF.OcxState")));
            this.acroPDF.Size = new System.Drawing.Size(786, 249);
            this.acroPDF.TabIndex = 3;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(637, 83);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Visible = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSettings
            // 
            this.cmdSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdSettings.Location = new System.Drawing.Point(643, 0);
            this.cmdSettings.Name = "cmdSettings";
            this.cmdSettings.Size = new System.Drawing.Size(75, 26);
            this.cmdSettings.TabIndex = 8;
            this.cmdSettings.Text = "Settings";
            this.cmdSettings.UseVisualStyleBackColor = true;
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // frmDocControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(790, 372);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Name = "frmDocControl";
            this.Text = "Willis Documents Control - Incoming";
            this.Activated += new System.EventHandler(this.frmDocControl_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocControl_FormClosing);
            this.Load += new System.EventHandler(this.frmDocControl_Load);
            this.Shown += new System.EventHandler(this.frmDocControl_Shown);
            this.VisibleChanged += new System.EventHandler(this.frmDocControl_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acroPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdSelectFolder;
        private System.Windows.Forms.TextBox txtPolicyNo;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.DateTimePicker dtScanDate;
        private System.Windows.Forms.DateTimePicker dtEOAHDate;
        private System.Windows.Forms.ComboBox cmbAH;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.FolderBrowserDialog fldrBrowserSelectFolder;
        private System.Windows.Forms.MaskedTextBox txtUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkNoLink;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private AxAcroPDFLib.AxAcroPDF acroPDF;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSettings;
    }
}