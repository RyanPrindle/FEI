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
        private DataTable requestTable;
        private DataTable gunTable;
        private Image detailIcon;
        private ColumnGunPartListForm columnGunForm;
        private ProgressBarForm progressForm;

        public DetailsForm(int reqId)
        {
            InitializeComponent();
            requestID = reqId;
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            FillDataTables();
        }
            
        private void btnColumnDetails_Click(object sender, EventArgs e)
        {
            //Open Column/Gun Parts List Form
            columnGunForm = new ColumnGunPartListForm(labelPart.Text);
            columnGunForm.ShowDialog();
        }

        private void FillDataTables()
        {
            progressForm = new ProgressBarForm();
            bGWDetails = new BackgroundWorker();
            bGWDetails.DoWork += new DoWorkEventHandler(bGWDetails_DoWork);
            bGWDetails.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWDetails_RunWorkerCompleted);
            bGWDetails.RunWorkerAsync(requestID);
            progressForm.ShowDialog();
        }

        private void bGWDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            int requestId = (int)e.Argument;            
            RequestsDB reqDB = new RequestsDB();
            DataTable reqTable = reqDB.GetRequest(requestID);
            DataTable gunTable = reqDB.GetGunTable();
            List<DataTable> tables = new List<DataTable>();
            tables.Add(reqTable);
            tables.Add(gunTable);
            e.Result = tables;
        }

        private void bGWDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DataTable> dBTable = (List<DataTable>)e.Result;
            requestTable = new DataTable();
            requestTable = dBTable[0];
            gunTable = dBTable[1];
            
            labelPart.Text = requestTable.Rows[0]["PartNumber"].ToString();
            labelDescription.Text = requestTable.Rows[0]["Description"].ToString();
            labelQty.Text = requestTable.Rows[0]["Quantity"].ToString();
            labelRequestedOn.Text = requestTable.Rows[0]["RequestedOn"].ToString();

            detailIcon = global::Cleaning_Scheduler_Interface.Properties.Resources.helpContents;
            int shortSide = Math.Min(btnColumnDetails.Width, btnColumnDetails.Height) - 10;
            detailIcon = (Image)new Bitmap(detailIcon, new Size(shortSide, shortSide));
            //btnColumnDetails.Image = detailIcon;
            
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
                panelProcedures.Visible = false;
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
            {
                gBoxSite.Visible = false;
            }
            else
            {
                gBoxSite.Text = "Site: " + requestTable.Rows[0]["Site"].ToString();
            }
            foreach(DataRow row in gunTable.Rows)
            {
                if (requestTable.Rows[0]["PartNumber"].Equals(row["Type"].ToString()))
                {
                    btnColumnDetails.Visible = true;
                }
            }
            progressForm.Close();
        }

    }
}
