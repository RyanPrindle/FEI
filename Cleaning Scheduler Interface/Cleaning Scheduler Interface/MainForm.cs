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

        
        private PartRequestForm requestForm;
        private AdminForm adminForm;
        private ProgressBarForm progressForm;
        private DataTable requestTable = new DataTable();
        private DataTable queueTable = new DataTable();
        private DataTable inProcessTable = new DataTable();
        private DataTable finishedTable = new DataTable();
        private DataTable contactTable = new DataTable();
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
            dGVCompleted.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Finished"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["RequestID"].Visible = false;
            dGVCompleted.Columns["Started"].Visible = false;
            dGVCompleted.Columns["Type1"].Visible = false;
            dGVCompleted.Columns["Type2"].Visible = false;
            dGVCompleted.Columns["Type3"].Visible = false;
            dGVCompleted.Columns["Type4"].Visible = false;
            dGVCompleted.Columns["Serial Number"].Visible = false;
            dGVCompleted.Columns["Contact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVCompleted.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVCompleted.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);            
            dGVCompleted.ResumeLayout();
        }

        private void InitInProcessDGV()
        {
            dGVInProcess.SuspendLayout();
            dGVInProcess.DataSource = inProcessTable;
            dGVInProcess.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVInProcess.Columns["RequestID"].Visible = false;
            dGVInProcess.Columns["Finished"].Visible = false;
            dGVInProcess.Columns["Type1"].Visible = false;
            dGVInProcess.Columns["Type2"].Visible = false;
            dGVInProcess.Columns["Type3"].Visible = false;
            dGVInProcess.Columns["Type4"].Visible = false;
            dGVInProcess.Columns["Serial Number"].Visible = false;
            dGVInProcess.Columns["Contact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVInProcess.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVInProcess.ResumeLayout();
        }

        private void InitQueueDGV()
        {
            dGVQueue.SuspendLayout();
            dGVQueue.DataSource = queueTable;
            dGVQueue.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVQueue.Columns["RequestID"].Visible = false;
            dGVQueue.Columns["Started"].Visible = false;
            dGVQueue.Columns["Finished"].Visible = false;
            dGVQueue.Columns["Type1"].Visible = false;
            dGVQueue.Columns["Type2"].Visible = false;
            dGVQueue.Columns["Type3"].Visible = false;
            dGVQueue.Columns["Type4"].Visible = false;
            dGVQueue.Columns["Serial Number"].Visible = false;
            dGVQueue.Columns["Contact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueue.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueue.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVQueue.ResumeLayout();
        }

        #region Event Handlers

        private void btnPartRequest_Click(object sender, EventArgs e)
        {  //Open Cleaning Request Form
            requestForm = new PartRequestForm();
            requestForm.ShowDialog();
        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            //Open Cleaning Area Operator Interface
            List<DataTable> tables = new List<DataTable>();
            tables.Add(queueTable);
            tables.Add(inProcessTable);
            adminForm = new AdminForm(tables);
            adminForm.ShowDialog();
        }

        #endregion

    }
}
