using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaning_Scheduler_Interface
{
    public partial class PartRequestForm : Form
    {
        private static String ADDCONTACT = "Add new contact...";
        private static String OPTIONAL = "Optional...";
        private PartRequest mPartRequest;
        private DataTable mPartTable;
        private DataTable mRequestsTable;
        private DataTable mContactTable;
        private int mContactID;
        ProgressBarForm mProgress;

        public PartRequestForm()
        {
            InitializeComponent();
            mContactID = 0;
        }

        private void PartRequestForm_Load(object sender, EventArgs e)
        {
            GetDataTables();
        }

        private void GetDataTables()
        {
            mProgress = new ProgressBarForm();
            bGWorkerGetData = new BackgroundWorker();
            bGWorkerGetData.DoWork += new DoWorkEventHandler(bGWorkerGetData_DoWork);
            bGWorkerGetData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerGetData_RunWorkerCompleted);
            bGWorkerGetData.RunWorkerAsync();
            mProgress.ShowDialog();
        }

        private void AddContact(String email)
        {
            mProgress = new ProgressBarForm();
            bGWorkerAddContact = new BackgroundWorker();
            bGWorkerAddContact.DoWork += new DoWorkEventHandler(bGWorkerAddContact_DoWork);
            bGWorkerAddContact.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerAddContact_RunWorkerCompleted);
            bGWorkerAddContact.RunWorkerAsync(email);
            mProgress.ShowDialog();
        }

        private void AddPart(PartRequest req)
        {
            mProgress = new ProgressBarForm();
            bGWorkerAddPart = new BackgroundWorker();
            bGWorkerAddPart.DoWork += new DoWorkEventHandler(bGWorkerAddPart_DoWork);
            bGWorkerAddPart.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerAddPart_RunWorkerCompleted);
            bGWorkerAddPart.RunWorkerAsync(req);
            mProgress.ShowDialog();
        }

        #region BackGround Workers

        private void bGWorkerGetData_DoWork(object sender, DoWorkEventArgs e)
        {

            PartsDB partsDB = new PartsDB();
            RequestsDB requestDB = new RequestsDB();
            List<DataTable> tables = new List<DataTable>();
            tables.Add(partsDB.GetCleanTable());
            tables.Add(requestDB.GetRequestsTable());
            tables.Add(requestDB.GetContactTable());
            e.Result = tables;
        }
        private void bGWorkerGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DataTable> tables = (List<DataTable>)e.Result;
            mPartTable = tables[0];
            mRequestsTable = tables[1];
            mContactTable = tables[2];
            mPartTable.Columns[@"P/N"].ColumnName = "Part";
            LoadPartsComboBox();
            LoadContactsComboBox();

            mProgress.Close();
        }

        private void bGWorkerAddContact_DoWork(object sender, DoWorkEventArgs e)
        {
            String email = (String)e.Argument;
            RequestsDB requestsDB = new RequestsDB();
            int contactID = requestsDB.AddIfNewContact(email);
            Tuple<String, int> result = new Tuple<string, int>(email, contactID);
            e.Result = result;

        }
        private void bGWorkerAddContact_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tuple<String, int> result = (Tuple<String, int>)e.Result;
            String eMail = result.Item1;
            mContactID = result.Item2;
            mProgress.Close();
            GetDataTables();
        }

        private void bGWorkerAddPart_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB requestsDB = new RequestsDB();
            e.Result = requestsDB.AddPartRequest((PartRequest)e.Argument);
        }

        private void bGWorkerAddPart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int result = (int)e.Result;
            mProgress.Close();
            if (result == 0)
            {
                MessageBox.Show("Request not created.");
                this.DialogResult = DialogResult.Abort;
            }
            else
                this.DialogResult = DialogResult.OK;
        }

        #endregion

        private void LoadPartsComboBox()
        {
            comboBoxPart.DataSource = mPartTable;
            comboBoxPart.DisplayMember = "Part";
            comboBoxPart.ValueMember = "Part";
            comboBoxPart.SelectedIndex = -1;
            lblPartDescription.Text = mPartTable.Rows[0]["Description"].ToString();
            if (lblPartDescription.Text == "")
                lblPartDescription.Text = "No Description Found";
        }

        private void LoadContactsComboBox()
        {
            mContactTable.Rows[0].Delete();
            DataRow promptContactRow = mContactTable.NewRow();
            promptContactRow["Email"] = OPTIONAL;
            promptContactRow["ContactId"] = 1;
            mContactTable.Rows.InsertAt(promptContactRow, 0);
            DataRow promptAddContactRow = mContactTable.NewRow();
            promptAddContactRow["Email"] = ADDCONTACT;
            promptAddContactRow["ContactId"] = -1;
            mContactTable.Rows.Add(promptAddContactRow);
            comboBoxContact.ValueMember = "ContactId";
            comboBoxContact.DisplayMember = "Email";
            comboBoxContact.DataSource = mContactTable;
            if (mContactID > 1)
            {
                DataRow[] rows = mContactTable.Select("ContactId = '" + mContactID + "'");
                if (rows.Length > 0)
                {
                    comboBoxContact.SelectedIndex = mContactTable.Rows.IndexOf(rows[0]) - 1;
                }
            }
        }

        private void ComboBoxContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxContact.SelectedValue.Equals(-1))
            {
                //Open new window to add new contact email.                    
                ContactBoxValidation validation = delegate(string val)
                {
                    if (val == "")
                        return "Email cannot be empty.";
                    if (!(new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch(val))
                        return "Email address is not valid.";
                    return "";
                };

                string eMail = "@FEI.com";
                if (ContactInputBox.Show("Enter email address to notify when complete.", "Email address:", ref eMail, validation) == DialogResult.OK)
                {
                    AddContact(eMail);
                }
                else
                {
                    comboBoxContact.SelectedIndex = 0;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPartCleanRequest_Click(object sender, EventArgs e)
        {
            errorProviderPartRequestForm.Clear();
            mPartRequest = new PartRequest();
            bool submittable = true;

            // Requestor Empty
            if (textBoxRequestor.Text.Trim() == "" || textBoxRequestor.Text == null)
            {
                errorProviderPartRequestForm.SetError(textBoxRequestor, "Enter Your Name");
                textBoxRequestor.Text = "";
                submittable = false;
            }
            // Requestor Not empty
            else
            {
                mPartRequest.mRequestor = textBoxRequestor.Text.Trim().ToString();
            }
            // Standard
            if (rBtnStandard.Checked)
            {
                //No Part Selected
                if (comboBoxPart.SelectedIndex == -1)
                {
                    errorProviderPartRequestForm.SetError(comboBoxPart, "Enter Part Number");
                    submittable = false;
                }
                //Part Selected
                else
                {
                    int index = comboBoxPart.FindString(comboBoxPart.Text);
                    if (index < 0)
                    {
                        errorProviderPartRequestForm.SetError(comboBoxPart, "Part Number Not Found");
                        submittable = false;
                    }
                    else
                    {
                        mPartRequest.mPart = comboBoxPart.SelectedValue.ToString();
                        foreach (DataRow row in mPartTable.Rows)
                        {
                            if (mPartRequest.mPart == row["Part"].ToString())
                            {
                                if (!(row["Description"].ToString() == "" | row["Description"].Equals(null)))
                                    mPartRequest.mDescription = row["Description"].ToString();
                                else
                                    mPartRequest.mDescription = "";
                            }
                        }
                    }
                }
            }
            //Non Standard
            else
            {
                if (!(textBoxDescription.Text.Trim() == "" || textBoxDescription.Text == null))
                {
                    mPartRequest.mPart = "Non - Standard";
                    mPartRequest.mDescription = textBoxDescription.Text.Trim();
                }
                else
                {
                    errorProviderPartRequestForm.SetError(textBoxDescription, "Enter Description for Non Standard Part");
                    submittable = false;
                }
            }

            if (!(textBoxInstructions.Text.Trim() == "" || textBoxInstructions.Text.ToString() == null))
            {
                mPartRequest.mInstructions = textBoxInstructions.Text.Trim().ToString();
            }
            else
            {
                if (rBtnNonStandard.Checked)
                {
                    errorProviderPartRequestForm.SetError(textBoxInstructions, "Instructions required for Non-Standard Part");
                    submittable = false;
                }
                else
                    mPartRequest.mInstructions = "";
            }

            if (comboBoxContact.SelectedIndex == 0)
            {
                mPartRequest.mContactId = 1;
            }
            else
            {
                mPartRequest.mContactId = int.Parse(comboBoxContact.SelectedValue.ToString());
            }

            if (!(textBoxPO.Text.ToString() == "" || textBoxPO.Text.ToString() == null))
            {
                mPartRequest.mPO = textBoxPO.Text.Trim().ToString();
            }
            else
            {
                mPartRequest.mPO = "";
            }
            if (!(textBoxSerialNumber.Text.Trim().ToString() == "" || textBoxSerialNumber.Text.Trim().ToString() == null))
            {
                mPartRequest.mSerial = textBoxSerialNumber.Text.Trim().ToString();
            }
            else
            {
                mPartRequest.mSerial = "";
            }

            mPartRequest.mQty = (int)numericUpDownQty.Value;

            if (checkBoxHot.Checked)
            {
                mPartRequest.mHot = true;
            }
            else
            {
                mPartRequest.mHot = false;
            }

            if (radioButtonCRYes.Checked == true || radioButtonCRNo.Checked == true)
            {
                if (radioButtonCRYes.Checked == true)
                {
                    mPartRequest.mCleanroomReady = true;
                    if (radioButtonCage.Checked == true || radioButtonBulk.Checked == true)
                    {
                        if (radioButtonCage.Checked == true)
                        {
                            mPartRequest.mCage = true;
                        }
                        else
                        {
                            mPartRequest.mBulk = true;
                        }
                    }
                    else
                    {
                        errorProviderPartRequestForm.SetError(gBoxStockLocation, "Cage or Bulk");
                        submittable = false;
                    }
                }
                else
                {
                    mPartRequest.mCleanroomReady = false;                   
                }
            }
            else
            {
                errorProviderPartRequestForm.SetError(radioButtonCRNo, "Cleanroom Ready, Yes or No");
                submittable = false;
            }

            if (submittable)
            {
                AddPart(mPartRequest);
            }
        }

        private void radioButtonCRYes_Click(object sender, EventArgs e)
        {
            gBoxStockLocation.Focus();
            gBoxStockLocation.ForeColor = Color.Maroon;
        }

        private void radioButtonCRNo_Click(object sender, EventArgs e)
        {
            gBoxStockLocation.ForeColor = Color.Black;
        }

        private void comboBoxPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxPart.SelectedIndex;
            if (index >= 0)
            {
                lblPartDescription.Text = mPartTable.Rows[comboBoxPart.SelectedIndex]["Description"].ToString();
                errorProviderPartRequestForm.SetError(comboBoxPart, "");
            }
            else
                lblPartDescription.Text = "";
        }

        private void rBtnStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnStandard.Checked)
            {
                pnlStandard.Visible = true;
                panelNonStandard.Visible = false;
                labelInstructions.ForeColor = Color.Black;
            }
            else
            {
                pnlStandard.Visible = false;
                panelNonStandard.Visible = true;
                labelInstructions.ForeColor = Color.Maroon;
            }
        }

        private void textBoxRequestor_MouseEnter(object sender, EventArgs e)
        {
            toolTipPartRequest.Show("Enter Your Name", textBoxRequestor);
        }

        private void textBoxRequestor_MouseLeave(object sender, EventArgs e)
        {
            toolTipPartRequest.Hide(textBoxRequestor);
        }

        private void comboBoxPart_MouseEnter(object sender, EventArgs e)
        {
            toolTipPartRequest.Show("Enter Part Number", comboBoxPart);
        }

        private void comboBoxPart_MouseLeave(object sender, EventArgs e)
        {
            toolTipPartRequest.Hide(comboBoxPart);
        }

        private void textBoxInstructions_MouseEnter(object sender, EventArgs e)
        {
            toolTipPartRequest.Show("Enter Instructions or Comments", textBoxInstructions);                    
        }

        private void textBoxInstructions_MouseLeave(object sender, EventArgs e)
        {
            toolTipPartRequest.Hide(textBoxInstructions);
        }


        private void comboBoxContact_MouseEnter(object sender, EventArgs e)
        {
            toolTipPartRequest.Show("Click to Select/Add Email to Contact When Complete", comboBoxContact);
        
        }

        private void comboBoxContact_MouseLeave(object sender, EventArgs e)
        {
            toolTipPartRequest.Hide(comboBoxContact);
        }

        private void textBoxRequestor_TextChanged(object sender, EventArgs e)
        {
            errorProviderPartRequestForm.SetError(textBoxRequestor, "");
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            errorProviderPartRequestForm.SetError(textBoxDescription, "");
        }

        private void radioButtonCR_CheckedChanged(object sender, EventArgs e)
        {
            errorProviderPartRequestForm.SetError(radioButtonCRNo, "");
        }

        
    }
}
