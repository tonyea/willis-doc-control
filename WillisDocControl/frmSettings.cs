using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WillisDocControl.Properties;

namespace WillisDocControl
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void cmdSaveSettings_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtDocLogLoc.Text))
            {
                Settings.Default["DocLogLoc"] = txtDocLogLoc.Text;
            }
            if (System.IO.Directory.Exists(txtTempPDFLoc.Text))
            {
                Settings.Default["TempPdfLoc"] = txtTempPDFLoc.Text;
            }
            else
            {
                MessageBox.Show("Link provided doesn't exist");
                txtTempPDFLoc.Text = Settings.Default["TempPdfLoc"].ToString();
                txtTempPDFLoc.Focus();
            }

            Settings.Default.Save();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtDocLogLoc.Text = Settings.Default["DocLogLoc"].ToString();
            txtTempPDFLoc.Text = Settings.Default["TempPdfLoc"].ToString();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
        }
    }
}
