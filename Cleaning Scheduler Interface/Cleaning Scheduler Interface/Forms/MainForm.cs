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

        private String[] checkBoxColumns = new String[] { "Decon", "Dishwasher", "WaterPik", "Ultrasonic", "Crest10", "Crest20", "CrestLong", "CR Ready", "Bulk", "Cage", "Hot" };
        private PartRequestForm requestPartForm;
        private ColumnRequestForm requestColumnForm;
        private AdminForm adminForm;
        private ProgressBarForm progressForm;
        private DetailsForm detailsForm;
        private DataTable requestTable = new DataTable();
        private DataTable queueTable = new DataTable();
        private DataTable inProcessTable = new DataTable();
        private DataTable finishedTable = new DataTable();
        private DataTable contactTable = new DataTable();
        public Font dGVRowFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
        public Font dGVHeaderFont = new System.Drawing.Font("Arial Narrow", 15.25F, System.Drawing.FontStyle.Bold);
        public Font dGVCheckboxSize = new System.Drawing.Font("Arial", 24.25F, System.Drawing.FontStyle.Bold);
        public Image infoIcon;
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
            requestTable.Columns["SerialNumber"].ColumnName = "Serial #";
            requestTable.Columns["PartNumber"].ColumnName = "Part #";
            requestTable.Columns["Email"].ColumnName = "Contact";
            requestTable.Columns["Quantity"].ColumnName = "Qty";
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
            InitQueueDGV();
            InitInProcessDGV();
            InitCompletedDGV();                        
            progressForm.Close();
        }

        #endregion
        
        private void InitCompletedDGV()
        {
            
            dGVCompleted.SuspendLayout();
            dGVCompleted.DataSource = null;
            dGVCompleted.Rows.Clear();
            dGVCompleted.Columns.Clear();
            dGVCompleted.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVCompleted.DataSource = finishedTable;
            dGVCompleted.DefaultCellStyle.Font = dGVRowFont;
            dGVCompleted.ColumnHeadersDefaultCellStyle.Font = dGVHeaderFont;
            dGVCompleted.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Started"].Visible = false; ;
            dGVCompleted.Columns["RequestID"].Visible = false;
            dGVCompleted.Columns["Instructions"].Visible = false;
            dGVCompleted.Columns["Hot"].Visible = false;
            dGVCompleted.Columns["Decon"].Visible = false;
            dGVCompleted.Columns["Dishwasher"].Visible = false;
            dGVCompleted.Columns["WaterPik"].Visible = false;
            dGVCompleted.Columns["Ultrasonic"].Visible = false;
            dGVCompleted.Columns["Crest10"].Visible = false;
            dGVCompleted.Columns["Crest20"].Visible = false;
            dGVCompleted.Columns["CrestLong"].Visible = false;
            dGVCompleted.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;            
            dGVCompleted.Sort(dGVCompleted.Columns["Finished"], ListSortDirection.Descending);

            FormatDGVCheckboxInfoHot(dGVCompleted);
            //dGVCompleted.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
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
            dGVInProcess.DefaultCellStyle.Font = dGVRowFont;
            dGVInProcess.ColumnHeadersDefaultCellStyle.Font = dGVHeaderFont;
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
            dGVInProcess.Columns["CR Ready"].Visible = false;
            dGVInProcess.Columns["Site"].Visible = false;
            dGVInProcess.Columns["PO"].Visible = false;         
            dGVInProcess.Columns["Serial #"].Visible = false;
            dGVInProcess.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVInProcess.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FormatDGVCheckboxInfoHot(dGVInProcess);
            //dGVInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVInProcess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVInProcess.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVInProcess.ResumeLayout();
        }

        private void InitQueueDGV()
        {
            dGVQueue.SuspendLayout();
            dGVQueue.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVQueue.DataSource = queueTable;
            dGVQueue.DefaultCellStyle.Font = dGVRowFont;
            dGVQueue.ColumnHeadersDefaultCellStyle.Font = dGVHeaderFont;
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
            dGVQueue.Columns["Serial #"].Visible = false;      
            dGVQueue.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueue.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FormatDGVCheckboxInfoHot(dGVQueue);
            //dGVQueue.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVQueue.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVQueue.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVQueue.ResumeLayout();
        }

        public void FormatDGVCheckboxInfoHot(DataGridView dGV)
        {
            DataGridViewButtonColumn btnInfoColumn = new DataGridViewButtonColumn();
            btnInfoColumn.Name = "Info";
            btnInfoColumn.HeaderText = "Info";
            btnInfoColumn.Text = "";
            btnInfoColumn.UseColumnTextForButtonValue = true;
            btnInfoColumn.FlatStyle = FlatStyle.Standard;
            DataGridViewTextBoxColumn col;
            if(!(dGV.Columns.Contains("Info")))
            {      
                dGV.Columns.Insert(0,btnInfoColumn);
            }
            foreach (String column in checkBoxColumns)
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
                foreach (String column in checkBoxColumns)
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
                            row.Cells[column + "X"].Value = "_";
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
            adminForm = new AdminForm(this);
            if (adminForm.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
            FillDataTables();
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

        private void dGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int shortSide = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 10;

            infoIcon = (Image)new Bitmap(infoIcon, new Size(shortSide, shortSide));
            DataGridView dGV = (DataGridView)sender;
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
                e.PaintContent(e.CellBounds);

                if (e.ColumnIndex == dGV.Columns["Info"].Index)
                {
                    e.Graphics.DrawImage(infoIcon, e.CellBounds.Location.X + (e.CellBounds.Width - infoIcon.Size.Width) / 2, e.CellBounds.Location.Y + (e.CellBounds.Height - infoIcon.Size.Height) / 2);
                }
                e.Handled = true;
            }
        }

        private void dGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                if (dgv.Columns.Contains("Info"))
                {
                    if (e.ColumnIndex == dgv.Columns["Info"].Index)
                    {
                        //Show Details
                        detailsForm = new DetailsForm(reqId);
                        detailsForm.ShowDialog();
                    }
                }
            }
        }

#endregion

        private void FormatLayout()
        {
            infoIcon = global::Cleaning_Scheduler_Interface.Properties.Resources.info_icon_53629;
            int padding = 10;
            int btnHeight = 60;
            int btnWidth = (pnlButtons.Width - (2 * padding));
            btnColumnRequest.Location = new Point(padding -1, padding);
            btnColumnRequest.Height = btnHeight;
            btnColumnRequest.Width = btnWidth;
            btnPartRequest.Location = new Point(padding -1, btnHeight + 2*padding);
            btnPartRequest.Height = btnHeight;
            btnPartRequest.Width = btnWidth;
            pnlButtons.Height = btnColumnRequest.Height + btnPartRequest.Height + (3 * padding)+ 4;
            btnCleaning.Location = new Point(0, btnQuit.Location.Y - btnCleaning.Height - padding);
            btnCleaning.Width = pnlButtons.Width;
            btnQuit.Width = pnlButtons.Width;
            splitContainer1.SplitterWidth = splitContainer2.SplitterWidth = splitContainer3.SplitterWidth = padding;
            splitContainer2.SplitterDistance = (splitContainer1.Height - 2 * padding)*2/7;
            splitContainer3.SplitterDistance = (splitContainer3.Height - padding)*2/ 5;
        }

        private void dGV_Sorted(object sender, EventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            FormatDGVCheckboxInfoHot(dGV);
        }
    }
}
