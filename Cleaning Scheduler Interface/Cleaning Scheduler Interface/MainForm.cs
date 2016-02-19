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
        private DataSet CleaningDataSet;
        private PartRequestForm requestForm;
        private DataTable cleanDBTable = new DataTable();
        private DataTable requestDBTable = new DataTable();
        private String cleaningPartsDBFullPath =@"\\hlsql01\Beamtech\Summit\Summit_Parts_Cleaning_be.mdb";
        private String cleaningRequestsDBFullPath = @"\\hlsql01\Beamtech\\Cleaning Team\Cleaning Scheduler\CleaningRequestsDB.mdb"; 
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
            DataSet CleaningDS = new DataSet();
            DataTable partTable = cleaningPartsDB.GetCleanTable();
            partTable.TableName = "part";
            DataTable requestTable = cleaningRequestsDB.GetRequestsTable();
            requestTable.TableName = "request";
            CleaningDS.Tables.Add(partTable);
            CleaningDS.Tables.Add(requestTable);
            e.Result = CleaningDS;
        }

        private void bGWorkerFillTables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataSet CleaningDataSet = (DataSet)e.Result;
            cleanDBTable = CleaningDataSet.Tables["part"];
            requestDBTable = CleaningDataSet.Tables["request"];
            requestForm = new PartRequestForm(CleaningDataSet);
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

        private void btnPartRequest_Click(object sender, EventArgs e)
        {
            //Open Column Cleaning Request Form
            requestForm = new PartRequestForm();

        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            //Open Cleaning Area Operator Interface
        }

        #endregion

    }
}
