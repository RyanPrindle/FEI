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
        private DataSet CleaningDataSet = new DataSet;
        public PartRequestForm(DataSet CleaningDS)
        {
            InitializeComponent();
            CleaningDataSet = CleaningDS;
        }
        private void RequestForm_Load(object sender, EventArgs e)
        {
        }

        private void LoadPartsComboBox(DataTable partTable)
        {
            comboBoxPart.DataSource = partTable;
            comboBoxPart.DisplayMember = @"P/N";
            comboBoxPart.ValueMember = @"P/N";
        }
        private void LoadContactsComboBox(DataTable contactTable)
        {
            //Add addContact to contact email List
            contactTable = new DataTable();            
            //Create last row add for contact e-mail List
            DataRow promptAddContactRow = contactTable.NewRow();
            promptAddContactRow["Email"] = ADDCONTACT;
            promptAddContactRow["ContactID"] = -1;
            contactTable.Rows.Add(promptAddContactRow);
            comboBoxContact.DataSource = contactTable;
            comboBoxContact.DisplayMember = "Email";
            comboBoxContact.ValueMember = "ContactID";
            
        }
        private void ComboBoxContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            //ComboBox comboBox = (ComboBox)sender;
            if (comboBoxContact.SelectedValue.ToString() == "-1")
            {
                index = comboBoxContact.SelectedIndex;
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
                    int conId = 0;
                    // Add new contact to DB
                    conId = cleaningRequestsDB.IsContact(eMail);
                    if (conId == 0)
                    {
                        conId = outgasDB.AddIfNewContact(eMail);
                        // Add email to each contactTable 
                        foreach (DataTable contactTable in listOfContactsTable)
                        {
                            DataRow row = contactTable.NewRow();
                            row["Email"] = eMail;
                            row["ContactId"] = conId;
                            //TODO Add row to list of contactstable tables
                            contactTable.Rows.InsertAt(row, contactTable.Rows.Count - 1);
                        }
                        comboBoxContact.SelectedIndex = index;
                        MessageBox.Show("Contact Email Saved");
                    }
                    else
                    {
                        DataRow[] rowArray = comboBoxContact.Select("ContactId = '" + conId + "'");
                        if (rowArray.Length > 0)
                        {
                            listOfContactsComboBox[i].SelectedIndex = listOfContactsTable[i].Rows.IndexOf(rowArray[0]);
                        }
                    }
                }
            }
        }
    }
}
