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
    public partial class MainForm : Form
    {
        #region Properties

        
        private PartRequestForm requestPartForm;
        private ColumnRequestForm requestColumnForm;
        private AdminForm adminForm;
        private ProgressBarForm progressForm;
        private DataTable requestTable = new DataTable();
        private DataTable queueTable = new DataTable();
        private DataTable inProcessTable = new DataTable();
        private DataTable finishedTable = new DataTable();
        private DataTable contactTable = new DataTable();
        private Font dGVFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular);
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillDataTables();            
        }

        private void FillDataTables()
        {
            progressForm = new ProgressBarForm();
            bGWorkerFillTables = new BackgroundWorker();
            bGWorkerFillTables.DoWork += new DoWorkEventHandler(bGWorkerFillTables_DoWork);
            bGWorkerFillTables.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerFillTables_RunWorkerCompleted);
            bGWorkerFillTables.RunWorkerAsync();
            progressForm.ShowDialog();
        }

        #region BackGround Workers

        private void bGWorkerFillTables_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB cleaningRequestsDB = new RequestsDB();
            DataTable requestTable = cleaningRequestsDB.GetRequestsTable();
            DataTable contactTable = cleaningRequestsDB.GetContactTable();
            List<DataTable> tables = new List<DataTable>();
            tables.Add(requestTable);
            tables.Add(contactTable);
            e.Result = tables;
        }

        private void bGWorkerFillTables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            List<DataTable> dBTable = (List<DataTable>)e.Result;
            requestTable = dBTable[0];
            requestTable.Columns["RequestedOn"].ColumnName = "Requested";
            requestTable.Columns["StartedOn"].ColumnName = "Started";
            requestTable.Columns["FinishedOn"].ColumnName = "Finished";
            requestTable.Columns["SerialNumber"].ColumnName = "Serial Number";
            requestTable.Columns["PartNumber"].ColumnName = "Part Number";

            queueTable = requestTable.Clone();
            inProcessTable = requestTable.Clone();
            finishedTable = requestTable.Clone();
            contactTable = dBTable[1];
            foreach (DataRow row in requestTable.Rows)
            {
                if (DBNull.Value.Equals(row["Started"]))
                {
                    queueTable.Rows.Add(row.ItemArray);
                }
                else if (DBNull.Value.Equals(row["Finished"]))
                {
                    inProcessTable.Rows.Add(row.ItemArray); 
                }
                else
                {
                    finishedTable.Rows.Add(row.ItemArray);                    
                }
            }
            loadDGVData();                  
            progressForm.Close();
        }

        #endregion

        private void loadDGVData()
        {
            InitQueueDGV();
            InitInProcessDGV();
            InitCompletedDGV();        
        }

        private void InitCompletedDGV()
        {
            dGVCompleted.SuspendLayout();
            dGVCompleted.DataSource = finishedTable;
            dGVCompleted.DefaultCellStyle.Font = dGVFont;
            dGVCompleted.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Finished"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["RequestID"].Visible = false;
            dGVCompleted.Columns["Comment"].Visible = false;
            dGVCompleted.Columns["Contact"].Visible = false;
            foreach (DataGridViewRow row in dGVCompleted.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            dGVCompleted.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVCompleted.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVCompleted.ResumeLayout();
        }

        private void InitInProcessDGV()
        {
            dGVInProcess.SuspendLayout();
            dGVInProcess.DataSource = inProcessTable;
            dGVInProcess.DefaultCellStyle.Font = dGVFont;
            dGVInProcess.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVInProcess.Columns["RequestID"].Visible = false;
            dGVInProcess.Columns["Finished"].Visible = false;
            dGVInProcess.Columns["Decon"].Visible = false;
            dGVInProcess.Columns["Dishwasher"].Visible = false;
            dGVInProcess.Columns["WaterPik"].Visible = false;
            dGVInProcess.Columns["Ultrasound"].Visible = false;
            dGVInProcess.Columns["Crest10"].Visible = false;
            dGVInProcess.Columns["Crest20"].Visible = false;
            dGVInProcess.Columns["CrestLong"].Visible = false;
            dGVInProcess.Columns["Bulk"].Visible = false;
            dGVInProcess.Columns["Cage"].Visible = false;
            dGVInProcess.Columns["CleanRoomReady"].Visible = false;
            dGVInProcess.Columns["Site"].Visible = false;
            dGVInProcess.Columns["PO"].Visible = false;         
            dGVInProcess.Columns["Serial Number"].Visible = false;
            dGVInProcess.Columns["Contact"].Visible = false;
            dGVInProcess.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVInProcess.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            foreach (DataGridViewRow row in dGVInProcess.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            dGVInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVInProcess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVInProcess.ResumeLayout();
        }

        private void InitQueueDGV()
        {
            dGVQueue.SuspendLayout();
            dGVQueue.DataSource = queueTable;
            dGVQueue.DefaultCellStyle.Font = dGVFont;
            dGVQueue.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVQueue.Columns["RequestID"].Visible = false;
            dGVQueue.Columns["Started"].Visible = false;
            dGVQueue.Columns["Finished"].Visible = false;
            dGVQueue.Columns["Decon"].Visible = false;
            dGVQueue.Columns["Dishwasher"].Visible = false;
            dGVQueue.Columns["WaterPik"].Visible = false;
            dGVQueue.Columns["Ultrasound"].Visible = false;
            dGVQueue.Columns["Crest10"].Visible = false;
            dGVQueue.Columns["Crest20"].Visible = false;
            dGVQueue.Columns["CrestLong"].Visible = false;
            dGVQueue.Columns["Bulk"].Visible = false;
            dGVQueue.Columns["Cage"].Visible = false;
            dGVQueue.Columns["CleanRoomReady"].Visible = false;
            dGVQueue.Columns["Site"].Visible = false;
            dGVQueue.Columns["PO"].Visible = false;
            dGVQueue.Columns["Serial Number"].Visible = false;
            dGVQueue.Columns["Contact"].Visible = false;            
            dGVQueue.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueue.Columns["Comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            foreach (DataGridViewRow row in dGVQueue.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            dGVQueue.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVQueue.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVQueue.ResumeLayout();
        }

#region Event Handlers

        private void btnPartRequest_Click(object sender, EventArgs e)
        {  //Open Part Cleaning Request Form
            requestPartForm = new PartRequestForm();
            requestPartForm.ShowDialog();
            FillDataTables();
        }
        
        private void buttonColumnRequest_Click(object sender, EventArgs e)
        {
            //Open Column Cleaning Request Form
            requestColumnForm = new ColumnRequestForm();
            requestColumnForm.ShowDialog();
            FillDataTables();
        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            //Open Cleaning Area Operator Interface
            List<DataTable> tables = new List<DataTable>();
            tables.Add(queueTable);
            tables.Add(inProcessTable);
            adminForm = new AdminForm(tables);
            adminForm.ShowDialog();
            FillDataTables();
        }
#endregion
    }
}
