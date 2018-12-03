using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace WillisDocControl
{
    public partial class rbnDocControl
    {
        Outlook.Inspector m_Inspector;
        static Outlook.MailItem m_Item;

        private void rbnDocControl_Load(object sender, RibbonUIEventArgs e)
        {
            
            
        }

        private void cmdDocControl_Click(object sender, RibbonControlEventArgs e)
        {
            m_Inspector = (Outlook.Inspector)this.Context;
            m_Item = m_Inspector.CurrentItem as Outlook.MailItem;
            // pass the current email item to the form
            frmDocControl.getMailItem(m_Item);
            DocCont.Show();
            
        }

        /*
         * The Singleton Pattern
         * 
         * Below lines of code will first create a variable _claims
         * Then we will create a property that will reference a new instance of frmClaims
         * or a previously existing one, this instance will be assigned to the variable _claims
         * We do this because if we use the following code in cmdClaims_click, 
         * then we will get multiple instances of the same form
         *      //frmClaims c = new frmClaims();
         *      c.ShowDialog();//
         * 
         * We should also be able to create a function for the below so that we don't have to copy
         * past the same code for different forms
         * 
         * For some reason, the same form is kept in memory even if we press the close button 
         * instead of the hide button
         */
        private static frmDocControl _dc;
        public static frmDocControl DocCont
        {
            get
            {
                if (_dc == null)
                {
                    // create new instance of the form since it is currently null
                    _dc = new frmDocControl();
                }

                // return the form to the caller
                return _dc;
            }
        }

    }
}
