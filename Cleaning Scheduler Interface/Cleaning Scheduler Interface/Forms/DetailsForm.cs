using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaning_Scheduler_Interface
{
    public partial class DetailsForm : Form
    {

#region Properties

        private int requestID;
        private DataTable requestTable;
        private DataTable gunTable;
        private ColumnGunPartListForm columnGunForm;
        private Image detailsIcon;
        private Image imageIcon;
        private ProgressBarForm progressForm;
        private String imagePath;

        #endregion

        public DetailsForm(int reqId)
        {
            InitializeComponent();
            requestID = reqId;
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            detailsIcon = Cleaning_Scheduler_Interface.Properties.Resources.details;
            imageIcon = Cleaning_Scheduler_Interface.Properties.Resources.image_32;
            detailsIcon = ResizeImage(detailsIcon, 28, 27);
            imageIcon = ResizeImage(imageIcon, 28, 27);
            btnDetails.Image = detailsIcon;
            btnImage.Image = imageIcon;
            FillDataTables();
        }

        private Image ResizeImage(Image img, int height, int width)
        {
            img = (Image)new Bitmap(img, new Size(height, width));
            return img;
        }

#region Background Workers

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
            DateTime reqTime = (DateTime)requestTable.Rows[0]["RequestedOn"];
            labelRequestedOn.Text = reqTime.ToString("M/d/yyyy  @  h:mm tt");

            
            labelRequestor.Text = requestTable.Rows[0]["Requestor"].ToString();
            labelContact.Text = requestTable.Rows[0]["Email"].ToString();
            labelPO.Text = requestTable.Rows[0]["PO"].ToString();
            labelInstructions.Text = requestTable.Rows[0]["Instructions"].ToString();
            if (requestTable.Rows[0]["StartedOn"].Equals(DBNull.Value) || requestTable.Rows[0]["StartedOn"].Equals(""))
            {
                this.BackColor = Color.FromArgb(255, 255, 192);
            }
            else
            {
                DateTime startTime = (DateTime)requestTable.Rows[0]["StartedOn"];
                labelStartedOn.Text = startTime.ToString("M/d/yyyy  @  h:mm tt");
            }
            if (requestTable.Rows[0]["FinishedOn"].Equals(DBNull.Value) || requestTable.Rows[0]["FinishedOn"].Equals(""))
            {
                panelProcedures.Visible = false;
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 224, 192);
                DateTime finTime = (DateTime)requestTable.Rows[0]["FinishedOn"];
                labelFinishedOn.Text = finTime.ToString("M/d/yyyy  @  h:mm tt");
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
                lblHot.Text = "High Priority";
                pnlHot.BackColor = Color.Red;
                pnlHot.ForeColor = Color.White;
                pBFire.Visible = true;
                this.BackColor = Color.Black;
            }
            
            if (requestTable.Rows[0]["CR Ready"].Equals(true))
            {
                if (requestTable.Rows[0]["Bulk"].Equals(true))
                    lblCRR.Text = "Cleanroom Ready -Bulk-";
                else
                    lblCRR.Text = "Cleanroom Ready -Cage-";
                pnlCRReady.BackColor = Color.Green;
                pnlCRReady.ForeColor = Color.White;
            }
            foreach(DataRow row in gunTable.Rows)
            {
                if (requestTable.Rows[0]["PartNumber"].Equals(row["Type"].ToString()))
                {
                    btnDetails.Enabled = true;
                    btnImage.Enabled = false;
                }
            }
            imagePath = @"\\hlsql01\Beamtech\Summit\FE_Cleaning\JT\" + labelPart.Text + ".jt";
            if (File.Exists(imagePath))
                btnImage.Enabled = true;
            progressForm.Close();
        }

        #endregion

#region Event Handlers

        private void btnDetails_Click(object sender, EventArgs e)
        {
            columnGunForm = new ColumnGunPartListForm(labelPart.Text);
            columnGunForm.ShowDialog();
        }


        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(imagePath);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Error opening image file.");
            }
        }
#endregion
    }
}
