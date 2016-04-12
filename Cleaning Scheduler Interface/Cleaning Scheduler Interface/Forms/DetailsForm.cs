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
            labelPart.Text = requestTable.Rows[0]["PartNumber"].ToString();
            labelDescription.Text = requestTable.Rows[0]["Description"].ToString();
            labelQty.Text = requestTable.Rows[0]["Quantity"].ToString();
            labelRequestedOn.Text = requestTable.Rows[0]["RequestedOn"].ToString();
            
            labelRequestor.Text = requestTable.Rows[0]["Requestor"].ToString();
            labelContact.Text = requestTable.Rows[0]["Email"].ToString();
            labelPO.Text = requestTable.Rows[0]["PO"].ToString();
            labelInstructions.Text = requestTable.Rows[0]["Instructions"].ToString();
            if (requestTable.Rows[0]["StartedOn"].Equals(DBNull.Value) || requestTable.Rows[0]["StartedOn"].Equals(""))
            {                
                this.BackColor = Color.FromArgb(255, 255, 128);
            }   
            else
                labelStartedOn.Text = requestTable.Rows[0]["StartedOn"].ToString();
            if (requestTable.Rows[0]["FinishedOn"].Equals(DBNull.Value) || requestTable.Rows[0]["FinishedOn"].Equals(""))
            {
                panelProcedures.Enabled = false;
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 192, 128);
                labelFinishedOn.Text = requestTable.Rows[0]["FinishedOn"].ToString();
                if (requestTable.Rows[0]["Decon"].Equals(true))
                    rBtnDecon.Checked = true;
                if (requestTable.Rows[0]["Ultrasonic"].Equals(true))
                    rBtnUltrasonic.Checked = true;
                if (requestTable.Rows[0]["Dishwasher"].Equals(true))
                    rBtnDW.Checked = true;
                if (requestTable.Rows[0]["WaterPik"].Equals(true))
                    rBtnWP.Checked = true;
                if (requestTable.Rows[0]["Crest10"].Equals(true))
                    rBtnC10.Checked = true;
                if (requestTable.Rows[0]["Crest20"].Equals(true))
                    rBtnC20.Checked = true;
                if (requestTable.Rows[0]["CrestLong"].Equals(true))
                    rBtnCLong.Checked = true;
            }
            if (requestTable.Rows[0]["Hot"].Equals(true))
            {
                rBtnHot.Checked = true;
                panelHot.BackColor = Color.Red;
            }
            if(requestTable.Rows[0]["Bulk"].Equals(true))            
                rBtnBulk.Checked = true;
            if(requestTable.Rows[0]["Cage"].Equals(true))            
                rBtnCage.Checked = true;
            if(requestTable.Rows[0]["CR Ready"].Equals(true))            
                rBtnCRR.Checked = true;
            if (requestTable.Rows[0]["Site"].Equals(DBNull.Value) || requestTable.Rows[0]["Site"].Equals(""))
                gBoxSite.Enabled = false;
            else
            {
                gBoxSite.Text = "Site: " + requestTable.Rows[0]["Site"].ToString();
            }
        }

    }
}
