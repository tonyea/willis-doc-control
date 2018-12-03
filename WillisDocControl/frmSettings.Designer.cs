namespace WillisDocControl
{
    partial class frmSettings
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
            this.cmdSaveSettings = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocLogLoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTempPDFLoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.Location = new System.Drawing.Point(250, 139);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(115, 23);
            this.cmdSaveSettings.TabIndex = 0;
            this.cmdSaveSettings.Text = "Save Settings";
            this.cmdSaveSettings.UseVisualStyleBackColor = true;
            this.cmdSaveSettings.Click += new System.EventHandler(this.cmdSaveSettings_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(129, 139);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(115, 23);
            this.cmdReset.TabIndex = 0;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location of document log";
            // 
            // txtDocLogLoc
            // 
            this.txtDocLogLoc.Location = new System.Drawing.Point(156, 9);
            this.txtDocLogLoc.Name = "txtDocLogLoc";
            this.txtDocLogLoc.Size = new System.Drawing.Size(209, 20);
            this.txtDocLogLoc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location of temporary PDFs";
            // 
            // txtTempPDFLoc
            // 
            this.txtTempPDFLoc.Location = new System.Drawing.Point(156, 31);
            this.txtTempPDFLoc.Name = "txtTempPDFLoc";
            this.txtTempPDFLoc.Size = new System.Drawing.Size(209, 20);
            this.txtTempPDFLoc.TabIndex = 2;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 174);
            this.Controls.Add(this.txtTempPDFLoc);
            this.Controls.Add(this.txtDocLogLoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdSaveSettings);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSaveSettings;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocLogLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTempPDFLoc;
    }
}