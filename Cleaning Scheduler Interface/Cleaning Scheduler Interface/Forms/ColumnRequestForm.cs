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
    public partial class ColumnRequestForm : Form
    {
        private static String ADDCONTACT = "Add new contact..";
        private static String OPTIONAL = "Optional...";
        private DataTable mColumnTable;
        private DataTable mRequestsTable;
        private DataTable mContactTable;
        private int mContactID;
        ProgressBarForm mProgress;
        private ColumnRequest mColumnRequest; 

        public ColumnRequestForm()
        {
            InitializeComponent();
            mContactID = 0;
        }

        private void ColumnRequestForm_Load(object sender, EventArgs e)
        {
            GetDataTables();
           
        }

        #region BackGround Workers

        private void GetDataTables()
        {
            mProgress = new ProgressBarForm();
            bGWorkerGetData = new BackgroundWorker();
            bGWorkerGetData.DoWork += new DoWorkEventHandler(bGWorkerGetData_DoWork);
            bGWorkerGetData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerGetData_RunWorkerCompleted);
            bGWorkerGetData.RunWorkerAsync();
            mProgress.ShowDialog();
        }
        private void bGWorkerGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB requestDB = new RequestsDB();
            List<DataTable> tables = new List<DataTable>();
            tables.Add(requestDB.GetColumnsTable());
            tables.Add(requestDB.GetRequestsTable());
            tables.Add(requestDB.GetContactTable());
            e.Result = tables;
        }
        private void bGWorkerGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DataTable> tables = (List<DataTable>)e.Result;
            mColumnTable = tables[0];
            mRequestsTable = tables[1];
            mContactTable = tables[2];
            LoadColumnsComboBox();
            LoadContactsComboBox();
            
            mProgress.Close();
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
        private void bGWorkerAddContact_DoWork(object sender, DoWorkEventArgs e)
        {
            String email = (String)e.Argument;
            RequestsDB requestsDB = new RequestsDB();
            int contactID = requestsDB.AddIfNewContact(email);
            Tuple<String,int> result = new Tuple<string,int>(email,contactID);
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

        private void AddColumn(ColumnRequest req)
        {
            mProgress = new ProgressBarForm();            
            bGWorkerAddColumn = new BackgroundWorker();
            bGWorkerAddColumn.DoWork += new DoWorkEventHandler(bGWorkerAddColumn_DoWork);
            bGWorkerAddColumn.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerAddColumn_RunWorkerCompleted);
            bGWorkerAddColumn.RunWorkerAsync(req);
            mProgress.ShowDialog();
        }
        private void bGWorkerAddColumn_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB requestsDB = new RequestsDB();
            e.Result = requestsDB.AddColumnRequest((ColumnRequest)e.Argument);
        }
        private void bGWorkerAddColumn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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


        private void LoadColumnsComboBox()
        {
            comboBoxColumn.DataSource = mColumnTable;
            comboBoxColumn.DisplayMember ="Type";
            comboBoxColumn.ValueMember = "Type";
        }

        private void LoadContactsComboBox()
        {            
            mContactTable.Rows[0].Delete();
            DataRow promptContactRow = mContactTable.NewRow();
            promptContactRow["Email"] = OPTIONAL;
            promptContactRow["ContactId"] = 1;
            mContactTable.Rows.InsertAt(promptContactRow,0);       
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

        private void btnColumnCleanRequest_Click(object sender, EventArgs e)
        {
            errorProviderColumnRequestForm.Clear();
            mColumnRequest = new ColumnRequest();
            bool submittable = true;
            if (textBoxRequestor.Text == "" || textBoxRequestor.Text == null)
            {
                errorProviderColumnRequestForm.SetError(textBoxRequestor, "Enter Your Name");
                submittable = false;
            }
            else
            {
                mColumnRequest.mRequestor = textBoxRequestor.Text.Trim().ToString();
            }

            if (comboBoxContact.SelectedIndex == 0)
            {
                mColumnRequest.mContactId = 1;
            }
            else
            {
                mColumnRequest.mContactId = int.Parse(comboBoxContact.SelectedValue.ToString());                 
            }

            if (!(textBoxComment.Text.ToString() == "" || textBoxComment.Text.ToString() == null))
            {
                mColumnRequest.mComment = textBoxComment.Text.Trim().ToString();
            }
            else
            {
                mColumnRequest.mComment = "";
            }

            if (!(textBoxColumnSerial.Text.Trim().ToString() == "" || textBoxColumnSerial.Text.Trim().ToString() == null))
            {
                mColumnRequest.mSerial = textBoxColumnSerial.Text.Trim().ToString();
            }
            else
            {
                mColumnRequest.mSerial = "";
            }

            if (checkBoxColumnHot.Checked)
            {
                mColumnRequest.mHot = true;
            }
            else
            {
                mColumnRequest.mHot = false;
            }

            mColumnRequest.mType = comboBoxColumn.SelectedValue.ToString();

            if (submittable)
            {
                //save request
                AddColumn(mColumnRequest);
            }
        }
    }
}
