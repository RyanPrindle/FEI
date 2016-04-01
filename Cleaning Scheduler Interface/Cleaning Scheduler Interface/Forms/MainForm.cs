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

        private String[] boolNames = new String[] { "Decon", "Dishwasher", "WaterPik", "Ultrasonic", "Crest10", "Crest20", "CrestLong", "CleanRoomReady", "Bulk", "Cage", "Hot" };
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
        private Font dGVCheckboxSize = new System.Drawing.Font("Arial", 24.25F, System.Drawing.FontStyle.Bold);
        #endregion

        public MainForm()
        {         
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormatLayout();
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
            requestTable = new DataTable();
            requestTable = dBTable[0];
            requestTable.Columns["RequestedOn"].ColumnName = "Requested";
            requestTable.Columns["StartedOn"].ColumnName = "Started";
            requestTable.Columns["FinishedOn"].ColumnName = "Finished";
            requestTable.Columns["SerialNumber"].ColumnName = "Serial Number";
            requestTable.Columns["PartNumber"].ColumnName = "Part Number";
            requestTable.Columns["Email"].ColumnName = "Contact";
            queueTable = new DataTable();
            queueTable = requestTable.Clone();
            inProcessTable = new DataTable();
            inProcessTable = requestTable.Clone();
            finishedTable = new DataTable();
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
                    if ((DateTime)row["Finished"] > DateTime.Today.AddDays(-7))
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
            dGVCompleted.DataSource = null;
            dGVCompleted.Rows.Clear();
            dGVCompleted.Columns.Clear();
            dGVCompleted.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVCompleted.DataSource = finishedTable;
            dGVCompleted.DefaultCellStyle.Font = dGVFont;
            dGVCompleted.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Started"].Visible = false; ;
            dGVCompleted.Columns["RequestID"].Visible = false;
            dGVCompleted.Columns["Instructions"].Visible = false;
            dGVCompleted.Columns["Hot"].Visible = false;
            dGVCompleted.Sort(dGVCompleted.Columns["Finished"], ListSortDirection.Descending);
            //DataGridViewTextBoxColumn checkedColumn = new DataGridViewTextBoxColumn();

            FormatDGVChecksAndHot(dGVCompleted);
            dGVCompleted.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVCompleted.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVCompleted.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVCompleted.ResumeLayout();
        }
        
        private void InitInProcessDGV()
        {
            DataGridViewTextBoxColumn checkedColumn = new DataGridViewTextBoxColumn();

            dGVInProcess.SuspendLayout();
            dGVInProcess.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVInProcess.DataSource = inProcessTable;
            dGVInProcess.DefaultCellStyle.Font = dGVFont;
            dGVInProcess.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVInProcess.Columns["RequestID"].Visible = false;
            dGVInProcess.Columns["Finished"].Visible = false;
            dGVInProcess.Columns["Hot"].Visible = false;
            dGVInProcess.Columns["Decon"].Visible = false;
            dGVInProcess.Columns["Dishwasher"].Visible = false;
            dGVInProcess.Columns["WaterPik"].Visible = false;
            dGVInProcess.Columns["Ultrasonic"].Visible = false;
            dGVInProcess.Columns["Crest10"].Visible = false;
            dGVInProcess.Columns["Crest20"].Visible = false;
            dGVInProcess.Columns["CrestLong"].Visible = false;
            dGVInProcess.Columns["Bulk"].Visible = false;
            dGVInProcess.Columns["Cage"].Visible = false;
            dGVInProcess.Columns["CleanRoomReady"].Visible = false;
            dGVInProcess.Columns["Site"].Visible = false;
            dGVInProcess.Columns["PO"].Visible = false;         
            dGVInProcess.Columns["Serial Number"].Visible = false;
            dGVInProcess.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVInProcess.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FormatDGVChecksAndHot(dGVInProcess);
            dGVInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVInProcess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVInProcess.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVInProcess.ResumeLayout();
        }

        private void InitQueueDGV()
        {
            dGVQueue.SuspendLayout();
            dGVQueue.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVQueue.DataSource = queueTable;
            dGVQueue.DefaultCellStyle.Font = dGVFont;
            dGVQueue.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVQueue.Columns["RequestID"].Visible = false;
            dGVQueue.Columns["Started"].Visible = false;
            dGVQueue.Columns["Finished"].Visible = false;
            dGVQueue.Columns["Hot"].Visible = false;
            dGVQueue.Columns["Decon"].Visible = false;
            dGVQueue.Columns["Dishwasher"].Visible = false;
            dGVQueue.Columns["WaterPik"].Visible = false;
            dGVQueue.Columns["Ultrasonic"].Visible = false;
            dGVQueue.Columns["Crest10"].Visible = false;
            dGVQueue.Columns["Crest20"].Visible = false;
            dGVQueue.Columns["CrestLong"].Visible = false;
            dGVQueue.Columns["PO"].Visible = false;
            dGVQueue.Columns["Serial Number"].Visible = false;      
            dGVQueue.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueue.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FormatDGVChecksAndHot(dGVQueue);
            dGVQueue.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVQueue.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVQueue.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVQueue.ResumeLayout();
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


#region Event Handlers

        private void btnPartRequest_Click(object sender, EventArgs e)
        { 
            requestPartForm = new PartRequestForm();
            requestPartForm.ShowDialog();
            FillDataTables();
        }
        
        private void buttonColumnRequest_Click(object sender, EventArgs e)
        {
            requestColumnForm = new ColumnRequestForm();
            requestColumnForm.ShowDialog();
            FillDataTables();
        }

        private void btnCleaning_Click(object sender, EventArgs e)
        {
            adminForm = new AdminForm();
            if (adminForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dGV_MouseWheel(object sender, MouseEventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            int currentIndex = dGV.FirstDisplayedScrollingRowIndex;
            int scrollLines = SystemInformation.MouseWheelScrollLines;

            if (e.Delta > 0)
            {
                dGV.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines);
            }
            else if (e.Delta < 0)
            {
                if (dGV.Rows.Count > (currentIndex + scrollLines))
                    dGV.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines;
            }
        }

        private void dGV_MouseEnter(object sender, EventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            dGV.Focus();
        }
        
#endregion

        private void FormatLayout()
        { 
            int padding = 10;
            int btnHeight = 75;
            int btnWidth = (pnlButtons.Width - (2 * padding));
            btnColumnRequest.Location = new Point(padding -1, padding);
            btnColumnRequest.Height = btnHeight;
            btnColumnRequest.Width = btnWidth;
            btnPartRequest.Location = new Point(padding -1, btnHeight + 2*padding);
            btnPartRequest.Height = btnHeight;
            btnPartRequest.Width = btnWidth;
            pnlButtons.Height = splitContainer1.Height - btnCleaning.Height - btnQuit.Height - 2 * padding;
            btnCleaning.Location = new Point(0, btnQuit.Location.Y - btnCleaning.Height - padding);
            btnCleaning.Width = pnlButtons.Width;
            btnQuit.Width = pnlButtons.Width;
            splitContainer1.SplitterWidth = splitContainer2.SplitterWidth = splitContainer3.SplitterWidth = padding;
            splitContainer2.SplitterDistance = (splitContainer1.Height - 2 * padding)/4;
            splitContainer3.SplitterDistance = (splitContainer3.Height - padding)/ 3;
        }
    
    
    }
}
