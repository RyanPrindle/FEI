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
        public PartRequestForm()
        {
            InitializeComponent();
        }

        private void RequestForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadPartsComboBox()
        {

        }
        private void LoadContactsComboBox()
        {
            ////Add default and addContact to contact email List
            //DataTable cTable = new DataTable();
            //cTable = dBTables[3];
            //DataRow copy = cTable.NewRow();
            //for (int i = 0; i < cTable.Rows.Count; i++)
            //{
            //    if (cTable.Rows[i].Field<int>("ContactId") == contactId)
            //    {
            //        //move to first index
            //        copy.ItemArray = cTable.Rows[i].ItemArray;
            //        cTable.Rows.Remove(cTable.Rows[i]);
            //        cTable.Rows.InsertAt(copy, 0);
            //    }
            //}
            ////Create last row add for contact e-mail List
            //DataRow promptAddContactRow = cTable.NewRow();
            //promptAddContactRow["Email"] = ADDCONTACT;
            //promptAddContactRow["ContactId"] = -1;
            //cTable.Rows.Add(promptAddContactRow);
            //listOfContactsTable.Add(cTable.Copy());
        }       
    }
}
