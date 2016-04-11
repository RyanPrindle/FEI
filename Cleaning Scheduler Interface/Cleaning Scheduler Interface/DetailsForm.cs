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
    public partial class DetailsForm : Form
    {
        private int requestID;
        private RequestsDB requestsDB;
        private DataTable requestTable;
        public DetailsForm(int reqId)
        {
            InitializeComponent();
            requestID = reqId;
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            requestsDB = new RequestsDB();
            requestTable = requestsDB.GetRequest(requestID);
            labelRequestor.Text = requestTable.Rows[0]["Requestor"].ToString();
        }
    }
}
