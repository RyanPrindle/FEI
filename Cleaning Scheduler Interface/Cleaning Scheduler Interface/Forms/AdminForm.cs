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
        private String[] boolNames = new String[] { "Decon", "Dishwasher", "WaterPik", "Ultrasonic", "Crest10", "Crest20", "CrestLong", "CleanRoomReady", "Bulk", "Cage", "Hot" };
        private Font dGVCheckboxSize = new System.Drawing.Font("Arial", 24.25F, System.Drawing.FontStyle.Bold);
        private DataTable mQueueTable;
        private DataTable mInProcessTable;
        private DataGridViewCellStyle dGVStyle = new DataGridViewCellStyle();
        private ProgressBarForm progressForm;
        private bool edit = false;

        public AdminForm()
        {
            InitializeComponent();
        }
       
        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshTables();
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
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "Delete";
            btnDeleteColumn.HeaderText = "Remove";
            btnDeleteColumn.Text = "Delete";
            btnDeleteColumn.UseColumnTextForButtonValue = true;

            dGVAdminQueue.SuspendLayout();
            dGVAdminQueue.DataSource = mQueueTable;
            dGVAdminQueue.DefaultCellStyle = dGVStyle;

            if (edit)
            {
                if (dGVAdminQueue.Columns.Contains("Start"))
                {
                    dGVAdminQueue.Columns.Remove("Start");
                }
                if (!(dGVAdminQueue.Columns.Contains("Delete")))
                {
                    dGVAdminQueue.Columns.Insert(0,btnDeleteColumn);
                }
            }
            else
            {
                if (dGVAdminQueue.Columns.Contains("Delete"))
                {
                    dGVAdminQueue.Columns.Remove("Delete");
                } 
                if (!(dGVAdminQueue.Columns.Contains("Start")))
                {
                    dGVAdminQueue.Columns.Add(btnStartColumn);
                }
            }
            dGVAdminQueue.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminQueue.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminQueue.Columns["RequestID"].Visible = false;
            dGVAdminQueue.Columns["Finished"].Visible = false;
            dGVAdminQueue.Columns["Started"].Visible = false;
            dGVAdminQueue.Columns["Decon"].Visible = false;
            dGVAdminQueue.Columns["Dishwasher"].Visible = false;
            dGVAdminQueue.Columns["WaterPik"].Visible = false;
            dGVAdminQueue.Columns["Ultrasonic"].Visible = false;
            dGVAdminQueue.Columns["Crest10"].Visible = false;
            dGVAdminQueue.Columns["Crest20"].Visible = false;
            dGVAdminQueue.Columns["CrestLong"].Visible = false;
            dGVAdminQueue.Columns["Serial Number"].Visible = false;
            dGVAdminQueue.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dGVAdminQueue.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            FormatDGVChecksAndHot(dGVAdminQueue);
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
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "Delete";
            btnDeleteColumn.HeaderText = "Remove";
            btnDeleteColumn.Text = "Delete";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn btnBackupColumn = new DataGridViewButtonColumn();
            btnBackupColumn.Name = "Backup";
            btnBackupColumn.HeaderText = "Back Up";
            btnBackupColumn.Text = "Move to Queue";
            btnBackupColumn.UseColumnTextForButtonValue = true;


            dGVAdminInProcess.SuspendLayout();
            dGVAdminInProcess.DataSource = mQueueTable;
            dGVAdminInProcess.DefaultCellStyle = dGVStyle;

            
            if (edit)
            {
                if (dGVAdminInProcess.Columns.Contains("Finish"))
                {
                    dGVAdminInProcess.Columns.Remove("Finish");
                }
                if (!(dGVAdminInProcess.Columns.Contains("Delete")))
                {
                    dGVAdminInProcess.Columns.Insert(0, btnDeleteColumn);
                    dGVAdminInProcess.Columns.Insert(1, btnBackupColumn);
                }
            }
            else
            {
                if (dGVAdminInProcess.Columns.Contains("Delete"))
                {
                    dGVAdminInProcess.Columns.Remove("Delete");
                    dGVAdminInProcess.Columns.Remove("Backup");
                }
                if (!(dGVAdminInProcess.Columns.Contains("Finish")))
                {
                    dGVAdminInProcess.Columns.Add(btnFinishColumn);
                }
            }
            dGVAdminInProcess.DataSource = mInProcessTable;
            dGVAdminInProcess.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["RequestID"].Visible = false;
            dGVAdminInProcess.Columns["Finished"].Visible = false;
            dGVAdminInProcess.Columns["Decon"].Visible = false;
            dGVAdminInProcess.Columns["Dishwasher"].Visible = false;
            dGVAdminInProcess.Columns["WaterPik"].Visible = false;
            dGVAdminInProcess.Columns["Ultrasonic"].Visible = false;
            dGVAdminInProcess.Columns["Crest10"].Visible = false;
            dGVAdminInProcess.Columns["Crest20"].Visible = false;
            dGVAdminInProcess.Columns["CrestLong"].Visible = false;
            dGVAdminInProcess.Columns["Serial Number"].Visible = false;
            dGVAdminInProcess.Columns["Bulk"].Visible = false;
            dGVAdminInProcess.Columns["Cage"].Visible = false;
            dGVAdminInProcess.Columns["Site"].Visible = false;
            dGVAdminInProcess.Columns["CleanRoomReady"].Visible = false;
            dGVAdminInProcess.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dGVAdminInProcess.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            FormatDGVChecksAndHot(dGVAdminInProcess);
            dGVAdminInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVAdminInProcess.EditMode = DataGridViewEditMode.EditProgrammatically; 
            dGVAdminInProcess.ResumeLayout();
        }

        private void FormatDGVChecksAndHot(DataGridView dGV)
        {
            DataGridViewTextBoxColumn col;
            foreach (String column in boolNames)
            {
                col = new DataGridViewTextBoxColumn();
                col.Name = column + "X";
                col.HeaderText = column;
                if (dGV.Columns.Contains(column) && (dGV.Columns[column].Visible == true))
                {
                    dGV.Columns.Insert(dGV.Columns[column].Index, col);
                    dGV.Columns[column].Visible = false;
                }
            }
            foreach (DataGridViewRow row in dGV.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
                foreach (String column in boolNames)
                {
                    if (dGV.Columns.Contains(column + "X"))
                    {
                        if ((bool)row.Cells[column].Value == true)
                        {
                            row.Cells[column + "X"].Value = "X";
                            row.Cells[column + "X"].Style.Font = dGVCheckboxSize;
                        }
                        else
                        {
                            row.Cells[column + "X"].Value = "-";
                        }
                    }
                }
            }
        }

        private void dGVAdminQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                if (dGVAdminQueue.Columns.Contains("Start"))
                {
                    if (e.ColumnIndex == dGVAdminQueue.Columns["Start"].Index)
                    {
                        //Start Cleaning
                        StartCleaning(reqId);
                    }
                }
                if (dGVAdminQueue.Columns.Contains("Edit"))
                {
                    if (e.ColumnIndex == dGVAdminQueue.Columns["Edit"].Index)
                    {
                        //Start Cleaning
                        DeleteRequest(reqId);
                    }
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

                if (dGVAdminInProcess.Columns.Contains("Finish"))
                {
                    if (e.ColumnIndex == dGVAdminInProcess.Columns["Finish"].Index)
                    {
                        //Finish Cleaning
                        FinishCleaning(reqId);
                    }
                }
                if (dGVAdminInProcess.Columns.Contains("Delete"))
                {
                    if (e.ColumnIndex == dGVAdminInProcess.Columns["Delete"].Index)
                    {
                        //Start Cleaning
                        DeleteRequest(reqId);
                    }
                }
                if (dGVAdminInProcess.Columns.Contains("Backup"))
                {
                    if (e.ColumnIndex == dGVAdminInProcess.Columns["Backup"].Index)
                    {
                        //Start Cleaning
                        BackUpRequest(reqId);
                    }
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
            e.Result = cleaningRequestsDB.GetRequestsTable();
        }

        private void bGWorkerRefreshTables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable requestTable = (DataTable)e.Result;
            requestTable.Columns["RequestedOn"].ColumnName = "Requested";
            requestTable.Columns["StartedOn"].ColumnName = "Started";
            requestTable.Columns["FinishedOn"].ColumnName = "Finished";
            requestTable.Columns["SerialNumber"].ColumnName = "Serial Number";
            requestTable.Columns["PartNumber"].ColumnName = "Part Number";
            requestTable.Columns["Email"].ColumnName = "Contact";
            

            mQueueTable = requestTable.Clone();
            mInProcessTable = requestTable.Clone();
            foreach (DataRow row in requestTable.Rows)
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

        private void DeleteRequest(int reqId)
        {
            progressForm = new ProgressBarForm();
            bGWorkerDeleteRequest = new BackgroundWorker();
            bGWorkerDeleteRequest.DoWork += new DoWorkEventHandler(bGWorkerDeleteRequest_DoWork);
            bGWorkerDeleteRequest.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerDeleteRequest_RunWorkerCompleted);
            bGWorkerDeleteRequest.RunWorkerAsync(reqId);
            progressForm.ShowDialog();
        }

        private void bGWorkerDeleteRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB cleaningRequestsDB = new RequestsDB();
            e.Result = cleaningRequestsDB.DeleteRequest((int)e.Argument);
        }

        private void bGWorkerDeleteRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                MessageBox.Show("Request Not Deleted");
            }
            progressForm.Close();
            RefreshTables();
        }

        private void BackUpRequest(int reqId)
        {
            progressForm = new ProgressBarForm();
            bGWorkerBackUpRequest = new BackgroundWorker();
            bGWorkerBackUpRequest.DoWork += new DoWorkEventHandler(bGWorkerBackUpRequest_DoWork);
            bGWorkerBackUpRequest.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerBackUpRequest_RunWorkerCompleted);
            bGWorkerBackUpRequest.RunWorkerAsync(reqId);
            progressForm.ShowDialog();
        }

        private void bGWorkerBackUpRequest_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB cleaningRequestsDB = new RequestsDB();
            e.Result = cleaningRequestsDB.BackUpRequest((int)e.Argument);
        }

        private void bGWorkerBackUpRequest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                MessageBox.Show("Request Not Moved Back to Queue.");
            }
            progressForm.Close();
            RefreshTables();
        }


#endregion
        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditRequests_Click(object sender, EventArgs e)
        {
            edit = !edit;
            InitDGVAdminQueue();
            InitDGVAdminInProcess();
            if (edit)
                btnEditRequests.Text = "Done Editing";
            else
                btnEditRequests.Text = "Edit Requests";
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            //Open History Screen
            HistoryForm historyForm = new HistoryForm();
            historyForm.ShowDialog();
        }

        private void EditEnableDGVAdminQueue()
        {
            
        }

       
    }
}
