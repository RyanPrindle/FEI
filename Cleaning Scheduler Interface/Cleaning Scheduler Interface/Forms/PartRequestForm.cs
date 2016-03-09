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
        private static String ADDCONTACT = @"Add new contact..";
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
            LoadPartsComboBox();
            LoadContactsComboBox();
            if (mContactID > 0)
            {
                DataRow[] rows = mContactTable.Select("ContactId = '" + mContactID + "'");
                if (rows.Length > 0)
                {
                    comboBoxContact.SelectedIndex = mContactTable.Rows.IndexOf(rows[0]);
                }
            }
            mProgress.Close();
        }


        private void AddContact(String email)
        {
            bGWorkerAddContact = new BackgroundWorker();
            bGWorkerAddContact.DoWork += new DoWorkEventHandler(bGWorkerAddContact_DoWork);
            bGWorkerAddContact.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerAddContact_RunWorkerCompleted);
            bGWorkerAddContact.RunWorkerAsync(email);
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
            DataRow[] rows = mContactTable.Select("ContactId = '" + mContactID + "'");
            if (rows.Length > 0)
            {
                comboBoxContact.SelectedIndex = mContactTable.Rows.IndexOf(rows[0]);
            }
            else
            {
                GetDataTables();
            }
        }
    
        #endregion


        private void LoadPartsComboBox()
        {
            DataRow rowPheonix = mPartTable.NewRow();
            rowPheonix[@"P/N"] = "Ion Pheonix Column";
            DataRow rowTHawk = mPartTable.NewRow();
            rowTHawk[@"P/N"] = "Ion Tomahawk Column";
            DataRow rowSideWinder = mPartTable.NewRow();
            rowSideWinder[@"P/N"] = "Ion SideWinder Column";
            DataRow rowMagnum = mPartTable.NewRow();
            rowMagnum[@"P/N"] = "Ion Magnum Column";
            DataRow rowLegacy = mPartTable.NewRow();
            rowLegacy[@"P/N"] = "Ion Legacy Column";
            mPartTable.Rows.InsertAt(rowLegacy, 0);
            mPartTable.Rows.InsertAt(rowMagnum, 0);
            mPartTable.Rows.InsertAt(rowSideWinder, 0);
            mPartTable.Rows.InsertAt(rowTHawk, 0);
            mPartTable.Rows.InsertAt(rowPheonix, 0);
            comboBoxPart.DataSource = mPartTable;
            comboBoxPart.DisplayMember = @"P/N";
            comboBoxPart.ValueMember = @"P/N";
        }

        private void LoadContactsComboBox()
        {
            //Add addContact to contact email List    
            //Create last row add for contact e-mail List
            DataRow promptContactRow = mContactTable.NewRow();
            promptContactRow["Email"] = "Optional...";
            mContactTable.Rows.InsertAt(promptContactRow,0);       
            DataRow promptAddContactRow = mContactTable.NewRow();
            promptAddContactRow["Email"] = ADDCONTACT;
            mContactTable.Rows.Add(promptAddContactRow);            
            comboBoxContact.ValueMember = "Email";
            comboBoxContact.DisplayMember = "Email";
            comboBoxContact.DataSource = mContactTable;
        }



        private void ComboBoxContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxContact.SelectedValue.ToString() == ADDCONTACT)
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

        private void comboBoxPart_Leave(object sender, EventArgs e)
        {
            int index = comboBoxPart.FindString(comboBoxPart.Text);
            if (index < 0)
            {
                MessageBox.Show("Part Number not in system.");
                comboBoxPart.Focus();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
