using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Excel = Microsoft.Office.Interop.Excel;

namespace WillisDocControl
{
    public partial class frmDocControl : Form
    {

        static string uidtxt = "";
        static string clientnametxt = "";
        static string policytypetxt = "";
        static string policynotxt = "";
        static string docPathPDED, docPathFD, docPathCRN, docPath, docTypeLong;
        static string ahName, ahTeam, ahEmail;
        static string subjecttxt;
        string[,] olMsgArray = new string[5, 8];
        //to be set in settings;
        static string mSignature = "";

        public frmDocControl()
        {
            InitializeComponent();
            
            // initializing the array to empty strings so that we can push and pop elements
            int i;
            for (i = 0; i < olMsgArray.GetUpperBound(0)+1; i++)
            {
                int x;
                for (x = 0; x < olMsgArray.GetUpperBound(1)+1; x++)
                {
                    olMsgArray[i, x] = "";
                }
            }

            //populating cmbDocType
            cmbDocType.Items.Add("PD");
            cmbDocType.Items.Add("ED");
            cmbDocType.Items.Add("C");
            cmbDocType.Items.Add("FD");
            cmbDocType.Items.Add("RN");

            //populating AHs
            cmbAH.Items.Add("Sameer,NM2,anthonyebin@gmail.com");
        }

        // creating a variable m_item that will receive the current mail item object from the ribbon
        // when the getMailItem function is called
        private static Outlook.MailItem m_Item;
        private static Outlook.Attachment m_Att;
        public static void getMailItem(Outlook.MailItem currEmail)
        {
            m_Item = currEmail;
            
        }

        // setting public variables
        Excel.Application xlApp;
        Excel.Workbook wkbk;
        string docLogXL = "C:\\Claims\\Document Log.xlsx";
        string docLogNameOnly = "Document Log.xlsx";
        int countEntries;
        Excel.Worksheet sheetOne;

        // function to initialize excel doc log
        private void setExcelApp()
        {
            xlApp = null;
            try
            {
                xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                xlApp = new Excel.Application();
                xlApp.Visible = true;
            }

            // if the claims file is already open then it will be pulled into wkbk, otherwise it will be opened
            wkbk = null;
            foreach (Excel.Workbook WB in xlApp.Workbooks)
            {
                // all this stuff is to isolate the file name of the currently running workbooks.
                string strWB = WB.FullName.ToString();
                int slashPos = strWB.LastIndexOf("\\");
                strWB = strWB.Substring(slashPos + 1);
                if (strWB == docLogNameOnly)
                {
                    wkbk = WB;
                    //MessageBox.Show("Test success");
                }
            }
            if (wkbk == null)
            {
                // in case file is not already open
                wkbk = xlApp.Workbooks.Open(docLogXL);
                // attempting to refresh the excel sheet
                try
                {
                    wkbk.RefreshAll();
                    wkbk.Save();
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("Program was unable to refresh the excel sheet, please do so manually");
                }
            }

            // activating the workbook for use
            // below code is extended from wkbk.activate due to ambiguity
            ((Excel._Workbook)wkbk).Activate();

            // assigning the worksheet for use
            sheetOne = wkbk.Worksheets[1];

            // counting number of rows for use in another part of program
            countEntries = sheetOne.UsedRange.Rows.Count;
            // for testing purpose: MessageBox.Show(countClaims.ToString());
        }

        // on load of the form, the pdf has to be loaded
        private void frmDocControl_Load(object sender, EventArgs e)
        {
            
        }

        // method to print out the subject line with available inputs. By default everthing is blank
        private void PrintSubject(string uid, string client, string policytype, string policyno)
        {
            // if any one of the text boxes is not blank then append the subjecttxt
            if ((uidtxt != "") || (clientnametxt != "") || (policytypetxt != "") || (policynotxt != ""))
            {
                subjecttxt = uidtxt + " " + clientnametxt + " " + policytypetxt + " " + policynotxt;
            }
            else
            {
                subjecttxt = "Subject line will be previewed here";
            }

            txtSubject.Text = subjecttxt;
        }

        private void cmdSelectFolder_Click(object sender, EventArgs e)
        {
            fldrBrowserSelectFolder.SelectedPath = @"C:\";
            fldrBrowserSelectFolder.ShowDialog();
            txtLink.Text = fldrBrowserSelectFolder.SelectedPath;
        }

        private void txtLink_Leave(object sender, EventArgs e)
        {
            txtLinkLeaveFunction();
        }

        private void txtLinkLeaveFunction() 
        {
            if (txtLink.Text == "")
            {
                txtLink.Text = "Link to the policy folder will appear here";
                return;
            }
            // below text will validate that the link exists
            // it will also make sure that if the user leaves it blank he can still do other things on the form, another
            // validation will have to occur on submit to prevent blank link submission
            if ((!System.IO.Directory.Exists(txtLink.Text)) && txtLink.Text != "")
            {
                MessageBox.Show("Link does not exist");
                txtLink.Text = "";
                txtLink.Focus();
                return;
            }
            else
            {
                string strLink = txtLink.Text;
                int count = strLink.Split('\\').Length - 1;


                /*
                 * This is a very complicated way to do it but it gets the job done
                 * I am trying to print out the subject line based on inputted fields
                 */
                if (count < 6)
                {
                    // we will pass empty strings to the print subject method incase the number of slashes is less than 6, 
                    // i.e. if the number of subfolders are less than 6. This would be an indication that we are not in the
                    // client database folder or that the folders are not saved in the correct format
                    MessageBox.Show("Insufficient number subfolders to extract client and policy names");
                    clientnametxt = "Unknown";
                    policytypetxt = "Unknown";
                }
                else if (count >= 6)
                {
                    // there need to be at least 6 folders in order to extract the client name and the policy type
                    int offset = strLink.IndexOf(@"\");
                    offset = strLink.IndexOf(@"\", offset + 1);
                    int clientSlashPos = strLink.IndexOf(@"\", offset + 1);
                    offset = strLink.IndexOf(@"\", clientSlashPos + 1);
                    clientnametxt = strLink.Substring(clientSlashPos + 1, offset - clientSlashPos - 1);
                    offset = strLink.IndexOf(@"\", offset + 1);
                    offset = strLink.IndexOf(@"\", offset + 1);
                    policytypetxt = strLink.Substring(offset + 1);
                }
                PrintSubject(uidtxt, clientnametxt, policytypetxt, policynotxt);

            }
        }

        private void txtUID_Leave(object sender, EventArgs e)
        {
            uidtxt = txtUID.Text.ToString();
            PrintSubject(uidtxt, clientnametxt, policytypetxt, policynotxt);
        }

        private void cmbDocType_Leave(object sender, EventArgs e)
        {
            // if anything other than available items are typed the validation will not occur
            if (!(cmbDocType.SelectedIndex > -1))
            {
                cmbDocType.Text = "Doc Type";
            }
        }

        private void txtPolicyNo_Leave(object sender, EventArgs e)
        {
            if (txtPolicyNo.Text == "")
            {
                txtPolicyNo.Text = "Policy & Endt #s";
            }
            else
            {
                policynotxt = txtPolicyNo.Text;
                PrintSubject(uidtxt, clientnametxt, policytypetxt, policynotxt);
            }
        }

        private void txtPolicyNo_Enter(object sender, EventArgs e)
        {
            if (txtPolicyNo.Text == "Policy & Endt #s")
            {
                txtPolicyNo.Text = "";
            } 
        }

        private void txtLink_Enter(object sender, EventArgs e)
        {
            if (txtLink.Text == "Link to the policy folder will appear here")
            {
                txtLink.Text = "";
            }
        }

        private void cmbAH_Leave(object sender, EventArgs e)
        {
            // if anything other than available items are typed the validation will not occur
            if (!(cmbAH.SelectedIndex > -1))
            {
                cmbAH.Text = "Select Account Handler";
            }
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateAll()) return;

            setExcelApp();

            // efile attachment in correct format and exit function if user says don't create folders
            // add links only if links exist
            if (System.IO.Directory.Exists(txtLink.Text))
            {
                docPathPDED = txtLink.Text + @"\5. Policy Documentation & Servicing\";
                docPathFD = txtLink.Text + @"\6. CST\Docs Control\Docs\";
                docPathCRN = txtLink.Text + @"\5. Policy Documentation & Servicing\Certificates\";

                // here we will save the email attachments if either the folder exists or if 
                // the user allows the program to create a new folder or we will exit the function if the user doesn't allow us to
                // create the folders
                switch (cmbDocType.Text)
                {
                        //also initializing docPath and docTypeLong variable to be later used in emailerFunction
                    case "PD": 
                        if (createFoldersAndSave(docPathPDED) == false) return;
                        docPath = docPathPDED;
                        docTypeLong ="Policy";
                        break;
                    case "ED":
                        if (createFoldersAndSave(docPathPDED) == false) return;
                        docPath = docPathPDED;
                        docTypeLong ="Endorsement/s";
                        break;
                    case "FD":
                        if (createFoldersAndSave(docPathFD) == false) return;
                        docPath = docPathFD;
                        docTypeLong = "Financial Document/s";
                        break;
                    case "C":
                        if (createFoldersAndSave(docPathCRN) == false) return;
                        docPath = docPathCRN;
                        docTypeLong = "Certificate/s";
                        break;
                    case "RN":
                        if (createFoldersAndSave(docPathCRN) == false) return;
                        docPath = docPathCRN;
                        docTypeLong = "Renewal Notice/s";
                        break;
                }
            }
            else
            {
                // attach files to email
            }

            
            string[] arrayAH = cmbAH.Text.Split(',');
            ahName = arrayAH[0].ToString();
            ahTeam = arrayAH[1].ToString();
            ahEmail = arrayAH[2].ToString();

            // updating the doc log
            int tempRow = countEntries + 1;
            sheetOne.Cells[tempRow, 2].Value = txtUID.Text;
            sheetOne.Cells[tempRow, 3].Value = clientnametxt;
            sheetOne.Cells[tempRow, 4].Value = cmbDocType.Text;
            sheetOne.Cells[tempRow, 5].Value = ahName;
            sheetOne.Cells[tempRow, 6].Value = ahTeam;
            sheetOne.Cells[tempRow, 7].Value = dtReceiveDate.Value.Date;
            sheetOne.Cells[tempRow, 8].Value = dtScanDate.Value.Date;
            sheetOne.Cells[tempRow, 9].Value = dtEOAHDate.Value.Date;
            if (System.IO.Directory.Exists(txtLink.Text)) sheetOne.Cells[tempRow, 18].Value = txtLink.Text;

            // send email or save email in array
            emailArrayFunction();

            
            // clear all input boxes so that duplicates are not allowed
            ClearAll();

            this.Hide();

        }

        //this function will accept a string path and save the email attachment in that path with a specified format
        private bool createFoldersAndSave(string path)
        {

            if (!System.IO.Directory.Exists(path))
            {
                DialogResult msgResult = MessageBox.Show("Do you want to create the following directory: " + path, "Folder doesn't exist", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (msgResult == DialogResult.OK)
                {
                    System.IO.Directory.CreateDirectory(path);
                    m_Att.SaveAsFile(path + txtUID.Text + " " + cmbDocType.Text + ".pdf");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                m_Att.SaveAsFile(path + txtUID.Text + " " + cmbDocType.Text + ".pdf");
                return true;
            }
        }

        private void emailArrayFunction()
        {
            //creating a function to send the email if all 6 elements are filled
            // if the UID of the 6th element is filled
            if (olMsgArray[olMsgArray.GetUpperBound(0),olMsgArray.GetUpperBound(1)] != "")
            {
                // send the first line and move all subsequent lines one line above
                emailerFunction(0);

            }

            string omSubject = txtSubject.Text;
            string omBodyHeader, omBodyLinks, omBodyFooter;

            omBodyHeader = "<HTML><HEAD></HEAD><BODY>Dear " + ahName + "<p>We have received and saved the following document/s in the hyperlinked locations:</p>"
                            + "<p><ul>";
            //no hyperlinks if chkNoLink is checked
            if (chkNoLink.Checked == true)
            {
                omBodyLinks = "<li>" + docTypeLong + "</li>";
            }
            else
            {
                omBodyLinks = "<li><a href='" + docPath + "'>" + docTypeLong + "</a></li>";
            }
            
            omBodyFooter = "</ul></p><p>Please advise us on how you would like to proceed with the above documents</p><p>" + mSignature + "</p></BODY></HTML>";
            
            // we can't directly pass the chkNoLink.checked value to emailerFunction as it is accessing previous elemnents of an array
            string noLinkChecked;
            if (chkNoLink.Checked ==true)
            {
                noLinkChecked = "true";
            }
            else noLinkChecked = "false";

            // creating a for loop that will modify the the omBodyLinks if the same UID is found or it will append a new line 
            // to the array. in order to do this, we must make sure that no empty strings should precede filled strings in the
            // array.
            int i;
            for (i = 0; i < olMsgArray.GetUpperBound(0)+1; i++)
            {
                if (txtUID.Text == olMsgArray[i, olMsgArray.GetUpperBound(1)])
                {           
                    olMsgArray[i, 0] = omSubject;
                    olMsgArray[i, 1] = omBodyHeader;
                    olMsgArray[i, 2] += omBodyLinks;
                    olMsgArray[i, 3] = omBodyFooter;
                    olMsgArray[i, 4] = ahEmail;
                    olMsgArray[i, 5] = noLinkChecked;
                    olMsgArray[i, 6] = txtLink.Text;
                    break;
                }
                else if (olMsgArray[i, olMsgArray.GetUpperBound(1)] == "")
                {
                    olMsgArray[i, 0] = omSubject;
                    olMsgArray[i, 1] = omBodyHeader;
                    olMsgArray[i, 2] += omBodyLinks;
                    olMsgArray[i, 3] = omBodyFooter;
                    olMsgArray[i, 4] = ahEmail;
                    olMsgArray[i, 5] = noLinkChecked;
                    olMsgArray[i, 6] = txtLink.Text;
                    olMsgArray[i, 7] = txtUID.Text;

                    // once the empty line of the array is found, it is filled and the program is ordered to exit the for loop
                    break;
                }
            }
        }

        private void emailerFunction(int lineNum)
        {
            int i;
            for (i = 0; i < lineNum + 1; i++)
            {
                Outlook.MailItem oMsg = m_Item.Application.CreateItem(Outlook.OlItemType.olMailItem);
                oMsg.Subject = olMsgArray[i, 0];
                Outlook.Recipients oRecips = oMsg.Recipients;
                Outlook.Recipient oRecipTo = oRecips.Add(olMsgArray[i, 4]);
                oRecipTo.Type = (int)Outlook.OlMailRecipientType.olTo;
                oRecipTo.Resolve();

                // saving email in client folder, doing this on send is more complicated
                string corrsDir = olMsgArray[i, 6] + @"\6. CST\Docs Control\Corrs\";
                if (!System.IO.Directory.Exists(corrsDir))
                {
                    System.IO.Directory.CreateDirectory(corrsDir);
                }
                DateTime stdDT = DateTime.Now;
                string dtFormat = "yyMMdd HHmm";
                oMsg.SaveAs(corrsDir + olMsgArray[i, 7] + " " + stdDT.ToString(dtFormat) + " EOAH,msg");

                if (olMsgArray[i, 5] == "false")
                {
                    oMsg.HTMLBody = olMsgArray[i, 1] + olMsgArray[i, 2] + olMsgArray[i, 3] + mSignature;
                    
                    // to resolve ambiguity between method 'Microsoft.Office.Interop.Outlook._MailItem.Send()' 
                    // and non-method 'Microsoft.Office.Interop.Outlook.ItemEvents_10_Event.Send'. Using method group.
                    ((Outlook._MailItem)oMsg).Send();
                }
                // if the chkNoLink check box is checked then we are opening a compose email form so that the user can custom add the attachments
                // its too complicated to programmatically attach the attachments
                else if (olMsgArray[i, 5] == "true")
                {
                    oMsg.HTMLBody = "<HTML><HEAD></HEAD><BODY>Dear " + ahName + "<p>We have received the following document/s (Copies attached for your ready reference):</p>"
                                    + "<p><ul>" + olMsgArray[i, 2] + olMsgArray[i, 3] + mSignature;
                    oMsg.Display(false);
                }

                
                    // code below to add CCs
                    //Outlook.Recipient oRecipCC = oRecips.Add("add CC email here");
                    //oRecipCC.Type = (int)Outlook.OlMailRecipientType.olCC;
                    //oRecipCC.Resolve();
                    //oMsg.Display(false);
                    // to resolve ambiguity between method 'Microsoft.Office.Interop.Outlook._MailItem.Send()' 
                    // and non-method 'Microsoft.Office.Interop.Outlook.ItemEvents_10_Event.Send'. Using method group.
                    //((Outlook._MailItem)oMsg).Send();

                oMsg = null;
                oRecipTo = null;
                oRecips = null;
                //oRecipCC = null;
            }

            // below code will delete the elements from the array that have already been used to send an email and also
            // move all other elements up one line;
            for (i = 0; i < olMsgArray.GetUpperBound(0) + 1; i++)
            {
                int x;
                for (x=0; x < olMsgArray.GetUpperBound(1)+1; x++)
                {
                    try
                    {
                        olMsgArray[i, x] = olMsgArray[i + 1, x];
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            // make sure to put empty strings in the element lines that have been moved up
            for (i = 0; i < lineNum + 1; i++)
            {
                int x;
                for (x = 0; x < olMsgArray.GetUpperBound(1) + 1; x++)
                {
                    // if numlines is 0 then only the last line would be empty
                    //MessageBox.Show(olMsgArray[olMsgArray.GetUpperBound(0) - i, x]);
                    olMsgArray[olMsgArray.GetUpperBound(0) - i, x] = "";
                }
            }
        }

        private void ClearAll() 
        {
            //txtUID.Text = "";
            //txtLink.Text = "Link to the policy folder will appear here";
            txtSubject.Text = "Subject line will be previewed here";
            //txtPolicyNo.Text = "Policy & Endt #s";
            //cmbAH.Text = "Select Account Handler";
            cmbDocType.Text = "Doc Type";
            chkNoLink.Checked = false;
            txtUID.Focus();
        }

        private bool ValidateAll()
        {
            if (txtUID.Text.Length < 9)
            {
                MessageBox.Show("Please enter a UID that is 9 digits long");
                txtUID.Focus();
                return false;
            }
            if (cmbDocType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a valid doc type");
                cmbDocType.Focus();
                return false;
            }
            if ((txtPolicyNo.Text =="") || (txtPolicyNo.Text == "Policy & Endt #s"))
            {
                MessageBox.Show("Please enter a valid policy #");
                txtPolicyNo.Focus();
                return false;
            }
            if (cmbAH.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a valid AH");
                cmbAH.Focus();
                return false;
            }
            if ((chkNoLink.Checked == false) && (!System.IO.Directory.Exists(txtLink.Text)))
            {
                MessageBox.Show("Please enter a valid link to the policy folder");
                txtLink.Focus();
                return false;
            }
            if (txtSubject.Text == "")
            {
                MessageBox.Show("Please enter a non-empty subject");
                txtSubject.Focus();
                return false;
            }
            return true;
        }

        private void chkNoLink_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoLink.Checked == true)
            {
                txtLink.Enabled = false;
                cmdSelectFolder.Enabled = false;
                clientnametxt = "CLIENT";
                policytypetxt = "POLICY";
                PrintSubject(uidtxt, clientnametxt, policytypetxt, policynotxt);
            }
            else
            {
                txtLink.Enabled = true;
                cmdSelectFolder.Enabled = true;
                txtLinkLeaveFunction();
            }
        }

        private void frmDocControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmDocControl_Activated(object sender, EventArgs e)
        {

        }

        private void frmDocControl_Shown(object sender, EventArgs e)
        {
            
        }

        private void frmDocControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                txtUID.Focus();
                // below code will preview the attachment in the form
                if (m_Item.Attachments.Count > 0)
                {
                    m_Att = m_Item.Attachments[1];
                    string m_Att_Name = m_Att.FileName;

                    // only pdf files allowed
                    if (m_Att_Name.IndexOf(".pdf") > 0)
                    {
                        // first save onto local system and then pull into browser: easier and no legal consequences of dealing with TP components such as acroPDF
                        string tempAttPath = @"C:\Users\Public\temp.pdf";
                        acroPDF.ResetText();
                        //pdfPreviewer.Navigate("about:blank");
                        if (System.IO.File.Exists(tempAttPath))
                        {
                            System.IO.File.Delete(tempAttPath);
                        }
                        m_Att.SaveAsFile(tempAttPath);

                        acroPDF.src = tempAttPath;
                        //pdfPreviewer.Navigate(tempAttPath);
                    }
                    else
                    {
                        // if file is not a pdf the form will not be closed but cancelled, hidden
                        MessageBox.Show("Not a PDF");
                        this.Close();
                    }
                }
                else
                {
                    // if mail does not have any attachments the form will not be closed but cancelled, hidden
                    MessageBox.Show("No attachments");
                    this.Close();
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {
            Settings.ShowDialog();
        }

        private static frmSettings _setngs;
        public static frmSettings Settings
        {
            get
            {
                if (_setngs == null)
                {
                    // create new instance of the form since it is currently null
                    _setngs = new frmSettings();
                }

                // return the form to the caller
                return _setngs;
            }
        }
    }
}
