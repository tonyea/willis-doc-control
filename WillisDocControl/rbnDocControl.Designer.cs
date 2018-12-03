namespace WillisDocControl
{
    partial class rbnDocControl : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public rbnDocControl()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rbnDocControl));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpDocControl = this.Factory.CreateRibbonGroup();
            this.cmdDocControl = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpDocControl.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpDocControl);
            this.tab1.Label = "Documents Control";
            this.tab1.Name = "tab1";
            // 
            // grpDocControl
            // 
            this.grpDocControl.Items.Add(this.cmdDocControl);
            this.grpDocControl.Label = "Documents Control";
            this.grpDocControl.Name = "grpDocControl";
            // 
            // cmdDocControl
            // 
            this.cmdDocControl.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.cmdDocControl.Image = ((System.Drawing.Image)(resources.GetObject("cmdDocControl.Image")));
            this.cmdDocControl.Label = "Doc Control";
            this.cmdDocControl.Name = "cmdDocControl";
            this.cmdDocControl.ShowImage = true;
            this.cmdDocControl.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.cmdDocControl_Click);
            // 
            // rbnDocControl
            // 
            this.Name = "rbnDocControl";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.rbnDocControl_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpDocControl.ResumeLayout(false);
            this.grpDocControl.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpDocControl;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdDocControl;
    }

    partial class ThisRibbonCollection
    {
        internal rbnDocControl Ribbon1
        {
            get { return this.GetRibbon<rbnDocControl>(); }
        }
    }
}
