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

        private DB cleaningPartsDB;
        private DB cleaningRequestsDB;
        private PartRequestForm requestForm = new PartRequestForm();
        private DataTable cleanDBTable = new DataTable();
        private DataTable requestDBTable = new DataTable();
        private String cleaningPartsDBFullPath =@"\\hlsql01\Beamtech\Summit\Summit_Parts_Cleaning_be.mdb";
        private String cleaningRequestsDBFullPath = @"\\hlsql01\Beamtech\Summit\Summit_Parts_Cleaning_Requests_be.mdb"; 
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cleaningPartsDB = new DB(cleaningPartsDBFullPath);
            cleaningRequestsDB = new DB(cleaningRequestsDBFullPath);
            FillDataTables();            
        }

        private void FillDataTables()
        {
            //progressForm = new ProgressBarForm();
            bGWorkerFillTables = new BackgroundWorker();
            bGWorkerFillTables.DoWork += new DoWorkEventHandler(bGWorkerFillTables_DoWork);
            bGWorkerFillTables.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerFillTables_RunWorkerCompleted);
            bGWorkerFillTables.RunWorkerAsync();
            //progressForm.ShowDialog();
        }

        #region BackGround Workers

        private void bGWorkerFillTables_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet dTables = new DataSet();
            DataTable partTable = cleaningPartsDB.GetCleanTable();
            partTable.TableName = "part";
            DataTable requestTable = cleaningRequestsDB.GetRequestsTable();
            requestTable.TableName = "request";
            dTables.Tables.Add(partTable);
            dTables.Tables.Add(requestTable);
            e.Result = dTables;
        }

        private void bGWorkerFillTables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataSet allDBs = (DataSet)e.Result;
            cleanDBTable = allDBs.Tables["part"];
            requestDBTable = allDBs.Tables["request"];
            loadDGVData();                  
            //progressForm.Close();
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
        }

        private void InitInProcessDGV()
        {
        }

        private void InitQueueDGV()
        {
            dGVQueue.SuspendLayout();
            dGVQueue.DataSource = cleanDBTable;
            dGVQueue.ResumeLayout();
        }

        #region Event Handlers

        private void btnColumnRequest_Click(object sender, EventArgs e)
        {
            //Open Parts Cleaning Request Form
        }

        private void btnPartRequest_Click(object sender, EventArgs e)
        {
            //Open Column Cleaning Request Form
        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            //Open Cleaning Area Operator Interface
        }

        #endregion

    }
}
