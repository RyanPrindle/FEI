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
    public partial class AdminForm : Form
    {
        private DataTable mQueueTable;
        private DataTable mInProcessTable;
        private DataGridViewCellStyle dGVStyle = new DataGridViewCellStyle();
        private ProgressBarForm progressForm;

        public AdminForm( List<DataTable> tables)
        {
            InitializeComponent();
            mQueueTable = tables[0];
            mInProcessTable = tables[1];
        }
       
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            SetDGVStyle();
            InitDGVAdminQueue();
            InitDGVAdminInProcess();
        }

        private void SetDGVStyle()
        {
            dGVStyle.Padding = new Padding(3);
            dGVStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVStyle.ForeColor = SystemColors.ControlText;
            dGVStyle.SelectionForeColor = dGVStyle.SelectionBackColor;            
        }

        private void InitDGVAdminQueue()
        {
            DataGridViewButtonColumn btnStartColumn = new DataGridViewButtonColumn();
            btnStartColumn.Name = "Start";
            btnStartColumn.HeaderText = "Clean";
            btnStartColumn.Text = "Start";
            btnStartColumn.UseColumnTextForButtonValue = true;

            dGVAdminQueue.SuspendLayout();
            dGVAdminQueue.DataSource = mQueueTable;
            dGVAdminQueue.DefaultCellStyle = dGVStyle;
            if (!(dGVAdminQueue.Columns[0].Name == "Start"))
            {
                dGVAdminQueue.Columns.Add(btnStartColumn);
            }
            dGVAdminQueue.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminQueue.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminQueue.Columns["RequestID"].Visible = false;
            dGVAdminQueue.Columns["Finished"].Visible = false;
            dGVAdminQueue.Columns["Started"].Visible = false;
            dGVAdminQueue.Columns["Decon"].Visible = false;
            dGVAdminQueue.Columns["Dishwasher"].Visible = false;
            dGVAdminQueue.Columns["WaterPik"].Visible = false;
            dGVAdminQueue.Columns["Ultrasound"].Visible = false;
            dGVAdminQueue.Columns["Crest10"].Visible = false;
            dGVAdminQueue.Columns["Crest20"].Visible = false;
            dGVAdminQueue.Columns["CrestLong"].Visible = false;
            dGVAdminQueue.Columns["Serial Number"].Visible = false;
            dGVAdminQueue.Columns["Contact"].Visible = false;
            dGVAdminQueue.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dGVAdminQueue.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.Cells["Hot"].Style.BackColor = Color.Red;
                    row.Cells["Hot"].Style.SelectionBackColor = Color.Red;
                }
            }
            dGVAdminQueue.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVAdminQueue.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVAdminQueue.ResumeLayout();
        }

        private void InitDGVAdminInProcess()
        {
            DataGridViewButtonColumn btnFinishColumn = new DataGridViewButtonColumn();
            btnFinishColumn.Name = "Finish";
            btnFinishColumn.HeaderText = "Finish";
            btnFinishColumn.Text = "Done";
            btnFinishColumn.UseColumnTextForButtonValue = true;

            dGVAdminInProcess.SuspendLayout();
            dGVAdminInProcess.DataSource = mQueueTable;
            dGVAdminInProcess.DefaultCellStyle = dGVStyle;
            if (!(dGVAdminInProcess.Columns[0].Name == "Finish"))
            {
                dGVAdminInProcess.Columns.Add(btnFinishColumn);
            }
            dGVAdminInProcess.DataSource = mInProcessTable;
            dGVAdminInProcess.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["RequestID"].Visible = false;
            dGVAdminInProcess.Columns["Finished"].Visible = false;
            dGVAdminInProcess.Columns["Decon"].Visible = false;
            dGVAdminInProcess.Columns["Dishwasher"].Visible = false;
            dGVAdminInProcess.Columns["WaterPik"].Visible = false;
            dGVAdminInProcess.Columns["Ultrasound"].Visible = false;
            dGVAdminInProcess.Columns["Crest10"].Visible = false;
            dGVAdminInProcess.Columns["Crest20"].Visible = false;
            dGVAdminInProcess.Columns["CrestLong"].Visible = false;
            dGVAdminInProcess.Columns["Serial Number"].Visible = false;
            dGVAdminInProcess.Columns["Contact"].Visible = false;
            dGVAdminInProcess.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dGVAdminInProcess.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.Cells["Hot"].Style.BackColor = Color.Red;
                    row.Cells["Hot"].Style.SelectionBackColor = Color.Red;
                }
            }
            dGVAdminInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVAdminInProcess.EditMode = DataGridViewEditMode.EditProgrammatically; 
            dGVAdminInProcess.ResumeLayout();
        }

        private void dGVAdminQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                if (e.ColumnIndex == dGVAdminQueue.Columns["Start"].Index)
                {
                    //Start Cleaning
                    StartCleaning(reqId);
                }
            }
        }

        private void dGVAdminInProcess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                if (e.ColumnIndex == dGVAdminInProcess.Columns["Finish"].Index)
                {
                    //Finish Cleaning
                    MessageBox.Show("Finish Cleaning " + reqId);
                    FinishCleaning(reqId);
                }
            }
        }

        private void FinishCleaning(int reqId)
        {
            FinishForm finishForm = new FinishForm(reqId);
            finishForm.ShowDialog();
            RefreshTables();
        }

#region BackGround Workers

        private void StartCleaning(int reqId)
        {
            progressForm = new ProgressBarForm();
            bGWStartCleaning = new BackgroundWorker();
            bGWStartCleaning.DoWork += new DoWorkEventHandler(bGWStartCleaning_DoWork);
            bGWStartCleaning.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWStartCleaning_RunWorkerCompleted);
            bGWStartCleaning.RunWorkerAsync(reqId);
            progressForm.ShowDialog();
        }

        private void bGWStartCleaning_DoWork(object sender, DoWorkEventArgs e)
        {
            int reqId = (int)e.Argument;
            RequestsDB requestsDB = new RequestsDB();
            e.Result = requestsDB.StartCleaning(reqId);
        }

        private void bGWStartCleaning_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int result = (int)e.Result;
            progressForm.Close();
            if (result == 0)
            {
                MessageBox.Show("Request not started.");
            }
            RefreshTables();
        }

        public void RefreshTables()
        {
            progressForm = new ProgressBarForm();
            bGWorkerRefreshTables = new BackgroundWorker();
            bGWorkerRefreshTables.DoWork += new DoWorkEventHandler(bGWorkerRefreshTables_DoWork);
            bGWorkerRefreshTables.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerRefreshTables_RunWorkerCompleted);
            bGWorkerRefreshTables.RunWorkerAsync();
            progressForm.ShowDialog();
        }

        private void bGWorkerRefreshTables_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB cleaningRequestsDB = new RequestsDB();
            DataTable requestTable = cleaningRequestsDB.GetRequestsTable();
            DataTable contactTable = cleaningRequestsDB.GetContactTable();
            List<DataTable> tables = new List<DataTable>();
            tables.Add(requestTable);
            tables.Add(contactTable);
            e.Result = tables;
        }

        private void bGWorkerRefreshTables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<DataTable> dBTable = (List<DataTable>)e.Result;
            dBTable[0].Columns["RequestedOn"].ColumnName = "Requested";
            dBTable[0].Columns["StartedOn"].ColumnName = "Started";
            dBTable[0].Columns["FinishedOn"].ColumnName = "Finished";
            dBTable[0].Columns["SerialNumber"].ColumnName = "Serial Number";
            dBTable[0].Columns["PartNumber"].ColumnName = "Part Number";

            mQueueTable = dBTable[0].Clone();
            mInProcessTable = dBTable[0].Clone();
            foreach (DataRow row in dBTable[0].Rows)
            {
                if (DBNull.Value.Equals(row["Started"]))
                {
                    mQueueTable.Rows.Add(row.ItemArray);
                }
                else if (DBNull.Value.Equals(row["Finished"]))
                {
                    mInProcessTable.Rows.Add(row.ItemArray);
                }
            }
            LoadDGV();
            progressForm.Close();
        }

#endregion
        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditRequests_Click(object sender, EventArgs e)
        {

        }               
    }
}
