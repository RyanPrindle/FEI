using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vacuum_Furnace_Scheduler_v1._0
{
    public partial class PartInfoForm : Form
    {
        public PartInfoForm()
        {
            InitializeComponent();
        }
        private OutgasDB outgasDB = new OutgasDB();
        private List<string> serialNumbers = new List<string>();
        public int mJobID { get; set;}
        public string mPartNumber { get; set;}

        public void PartInfoForm_Load(object sender, EventArgs e)
        {            
            DataTable dataTableJob = new DataTable();
            dataTableJob = outgasDB.GetPartJobBatchInfo(mJobID);
            DataRow row;
            if (dataTableJob.Rows.Count == 0)
            {
                dataTableJob = outgasDB.GetJob(mJobID);
                row = dataTableJob.Rows[0];
                if (!DBNull.Value.Equals(row["Location"]))
                {
                    labelLocation.Text = row.Field<string>("Location");

                }
            }
            else
            {
                row = dataTableJob.Rows[0];
                if (!DBNull.Value.Equals(row["BatchID"]))
                {
                    labelBatch.Text = "Batch # " + row.Field<int>("BatchID").ToString() + "  Ln: " + row.Field<int>("BatchLineItem").ToString();
                    labelCreated.Text = row.Field<DateTime>("DateCreated").ToShortDateString();
                }
                if (!DBNull.Value.Equals(row["DateStarted"]))
                {
                    labelStarted.Text = row.Field<DateTime>("DateStarted").ToShortDateString();
                }
                 if (!DBNull.Value.Equals(row["DateCompleted"]))
                {
                    labelCompleted.Text = row.Field<DateTime>("DateCompleted").ToShortDateString();
                    buttonOvenData.Visible = true;
                }
                if (!DBNull.Value.Equals(row["DatePickedUp"]))
                {
                    labelPickedUp.Text = row.Field<DateTime>("DatePickedUp").ToShortDateString();
                }
                if (!DBNull.Value.Equals(row["Oven"]))
                {
                    labelLocation.Text = row.Field<string>("Oven");
                    
                }
            }
            labelRequestor.Text = row.Field<string>("UserName");
            label13.Text = row.Field<string>("Email");
            labelQuantity.Text = row.Field<int>("Qty").ToString();
            labelReceived.Text = row.Field<DateTime>("DateReceived").ToShortDateString();
            if (!DBNull.Value.Equals(row["Picture"]))
                pictureBoxPart.Image = (Image)Properties.Resources.ResourceManager.GetObject(row.Field<string>("Picture").ToString());
            labelJob.Text += " " + mJobID;
            DataTable partTable = new DataTable();
            DataTable tempTable = new DataTable();
            DataTable serialTable = new DataTable();
            partTable = outgasDB.GetPartInfo(mPartNumber);
            
            labelPartNumber.Text += mPartNumber.ToString();
            labelPartMat.Text = partTable.Rows[0].Field<string>("Material");
            labelPartDesc.Text = partTable.Rows[0].Field<string>("Description");
            labelArea.Text = partTable.Rows[0].Field<string>("Area");
            tempTable = outgasDB.GetTempInfo(partTable.Rows[0].Field<string>("CycleId"));
            labelOvenTemp.Text = tempTable.Rows[0].Field<string>("ProcessTemp") + " Celsius";
            labelCycleNumber.Text = partTable.Rows[0].Field<string>("CycleId");
            if (mJobID > 0)
            {
                if (partTable.Rows[0].Field<bool>("Serialized"))
                {
                    serialTable = outgasDB.GetSerialNumberList(mJobID);
                    if (serialTable.Rows.Count == 0)
                    {
                        serialNumbers.Add("This request did not have");
                        serialNumbers.Add("serial numbers entered.");
                    }
                    else
                    {
                        foreach (DataRow dRow in serialTable.Rows)
                        {
                            serialNumbers.Add(dRow.Field<string>("SerialNumber"));
                        }
                    }
                }
                else
                {
                    serialNumbers.Add("This part does not have a");
                    serialNumbers.Add("serial number.");
                }
                listBoxSerialNumber.SuspendLayout();
                listBoxSerialNumber.DataSource = serialNumbers;
                listBoxSerialNumber.ResumeLayout();
            }
        }      

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }

        private void buttonOvenData_Click(object sender, EventArgs e)
        {
            if (labelCompleted.Text.Equals(DateTime.Today.ToShortDateString()))
                MessageBox.Show("The Oven Data for this batch has not been downloaded from the oven yet.\nIt should be available tomorrow.", "Data not available at this time");
            else
            {
                //Open OvenData for Batch
                string file = @"C:\dev\TFE_Projects\TFE_VacuumFurnaceScheduler\OvenData";
                if (labelLocation.Text.Equals("Oven 1(EGUN)"))
                    file += @"\Oven1\Oven1-";
                else
                    file += @"\Oven2\Oven2-";
                file += labelCompleted.Text.Replace('/', '-') + ".DAD";
                System.Diagnostics.Process.Start(file);
            }
        }        
    }
}
