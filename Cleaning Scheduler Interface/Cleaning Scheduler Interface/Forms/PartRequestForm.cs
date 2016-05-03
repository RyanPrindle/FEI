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
            comboBoxSite.SelectedIndex = 0;
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
            }
            this.Close();
        }

        #endregion

        private void LoadPartsComboBox()
        {
            comboBoxPart.DataSource = mPartTable;
            comboBoxPart.DisplayMember = "Part";
            comboBoxPart.ValueMember = "Part";
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

            if (textBoxRequestor.Text == "" || textBoxRequestor.Text == null)
            {
                errorProviderPartRequestForm.SetError(textBoxRequestor, "Enter Your Name");
                textBoxRequestor.Focus();
                submittable = false;
            }
            else
            {
                mPartRequest.mRequestor = textBoxRequestor.Text.Trim().ToString();
            }

            if (comboBoxPart.SelectedIndex == 0)
            {
                errorProviderPartRequestForm.SetError(comboBoxPart, "Enter Part Number");
                submittable = false;
            }
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

            if (!(textBoxComment.Text.ToString() == "" || textBoxComment.Text.ToString() == null))
            {
                mPartRequest.mInstructions = textBoxComment.Text.Trim().ToString();
            }
            else
            {
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

            mPartRequest.mSite = comboBoxSite.SelectedItem.ToString();

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
                        errorProviderPartRequestForm.SetError(groupBoxSL, "Cage or Bulk");
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
                errorProviderPartRequestForm.SetError(groupBoxCR, "Yes or No");
                submittable = false;
            }

            if (submittable)
            {
                AddPart(mPartRequest);
            }
        }

        private void radioButtonCRYes_Click(object sender, EventArgs e)
        {
            groupBoxSL.Enabled = true;
            groupBoxSL.Focus();
        }

        private void radioButtonCRNo_Click(object sender, EventArgs e)
        {
            groupBoxSL.Enabled = false;
            MessageBox.Show("Please put cleaning requirements in the comment section.");
            textBoxComment.Focus();
        }

        private void comboBoxPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPartDescription.Text = mPartTable.Rows[comboBoxPart.SelectedIndex]["Description"].ToString();
        }

        private void lblPartDescription_TextChanged(object sender, EventArgs e)
        {
            if (lblPartDescription.Text == "")
                lblPartDescription.Text = "No Description Found";
        }
    }
}
