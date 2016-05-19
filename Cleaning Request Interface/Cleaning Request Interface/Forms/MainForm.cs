using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaning_Request_Interface
{
    public partial class MainForm : Form
    {

#region Properties

        private String[] checkBoxColumns = new String[] { }; //"Decon", "Dishwasher", "WaterPik", "Ultrasonic", "Crest10", "Crest20", "CrestLong", "CR Ready", "Bulk", "Cage", "Hot" };
        private PartRequestForm requestPartForm;
        private ColumnRequestForm requestColumnForm;
        private HistoryForm historyForm;
        private ProgressBarForm progressForm;
        private DetailsForm detailsForm;
        private DataTable requestTable = new DataTable();
        private DataTable queueTable = new DataTable();
        private DataTable inProcessTable = new DataTable();
        private DataTable finishedTable = new DataTable();
        private DataTable contactTable = new DataTable();

        public Font dGVRowFont = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
        public Font dGVHeaderFont = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Bold);
        public Font btnFont = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
        public Image infoIcon;
        public Image checkIcon;
        public Color hotColor = Color.Red;
        public Color crrColor = Color.Green;
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
            dGVCompleted.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVCompleted.Columns["Finished"].DefaultCellStyle.Format = "M/d/yyyy";            
            dGVCompleted.Columns["Started"].Visible = false; ;
            dGVCompleted.Columns["RequestID"].Visible = false;
            dGVCompleted.Columns["Hot"].Visible = false;
            dGVCompleted.Columns["Decon"].Visible = false;
            dGVCompleted.Columns["Dishwasher"].Visible = false;
            dGVCompleted.Columns["WaterPik"].Visible = false;
            dGVCompleted.Columns["Ultrasonic"].Visible = false;
            dGVCompleted.Columns["Crest10"].Visible = false;
            dGVCompleted.Columns["Crest20"].Visible = false;
            dGVCompleted.Columns["CrestLong"].Visible = false;
            dGVCompleted.Columns["Bulk"].Visible = false;
            dGVCompleted.Columns["Cage"].Visible = false;
            dGVCompleted.Columns["CR Ready"].Visible = false;
            dGVCompleted.Columns["Serial #"].Visible = false; 
            dGVCompleted.Columns["PO"].Visible = false;
            dGVCompleted.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVCompleted.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;          
            dGVCompleted.Sort(dGVCompleted.Columns["Finished"], ListSortDirection.Descending);

            FormatDGVInfoHot(dGVCompleted);
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
            dGVInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";     
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
            dGVInProcess.Columns["Serial #"].Visible = false;
            dGVInProcess.Columns["PO"].Visible = false;         
            dGVInProcess.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVInProcess.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FormatDGVInfoHot(dGVInProcess);
            dGVInProcess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVInProcess.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVInProcess.ResumeLayout();
        }

        private void InitQueueDGV()
        {
            dGVQueue.SuspendLayout();
            dGVQueue.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            DataView dataView = queueTable.DefaultView;
            dGVQueue.DataSource = dataView;
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
            dGVQueue.Columns["Bulk"].Visible = false;
            dGVQueue.Columns["Cage"].Visible = false;
            dGVQueue.Columns["PO"].Visible = false;
            dGVQueue.Columns["CR Ready"].Visible = false;
            dGVQueue.Columns["Serial #"].Visible = false;
            dGVQueue.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueue.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FormatDGVInfoHot(dGVQueue);
            dGVQueue.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVQueue.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVQueue.ResumeLayout();
        }

        public void FormatDGVInfoHot(DataGridView dGV)
        {
            dGV.SuspendLayout();
            DataGridViewButtonColumn btnInfoColumn = new DataGridViewButtonColumn();
            
            btnInfoColumn.Name = "Info";
            btnInfoColumn.HeaderText = "Info";
            btnInfoColumn.Text = "";
            btnInfoColumn.UseColumnTextForButtonValue = true;
            btnInfoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnInfoColumn.Width = 50;
            btnInfoColumn.FlatStyle = FlatStyle.Standard;
            if(!(dGV.Columns.Contains("Info")))
            {      
                dGV.Columns.Insert(0,btnInfoColumn);
            }
           
            foreach (DataGridViewRow row in dGV.Rows) 
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = hotColor;
                    row.DefaultCellStyle.SelectionBackColor = hotColor;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }              
                else if ((bool)row.Cells["CR Ready"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = crrColor;
                    row.DefaultCellStyle.SelectionBackColor = crrColor;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }   
            }
            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dGV.ResumeLayout();
        }

        private void FormatLayout()
        {
            infoIcon = global::Cleaning_Request_Interface.Properties.Resources.blueInfoButtonIcon;
            checkIcon = global::Cleaning_Request_Interface.Properties.Resources.GreenCheck;
            btnHistory.Font = btnPartRequest.Font = btnQuit.Font = btnColumnRequest.Font = btnFont;
            panelHot.BackColor = hotColor;
            panelCRR.BackColor = crrColor;
            
            int padding = 10;
            int btnHeight = splitContainer1.Height / 10;
            int btnWidth = (pnlButtons.Width - (2 * padding));
            btnHistory.Width = btnQuit.Width = btnPartRequest.Width = pnlButtons.Width;
            

            pnlButtons.Height = 2 * btnHeight + 3 * padding;
            panelLegend.Location = new Point(panelLegend.Location.X, pnlButtons.Height);
            panelLegend.Height = splitContainer1.Height * 4 / 10;

            btnColumnRequest.Location = new Point(padding - 1, padding);
            btnColumnRequest.Height = btnPartRequest.Height = btnHistory.Height = btnQuit.Height = btnHeight;
            btnColumnRequest.Width = btnPartRequest.Width = btnWidth;
            btnQuit.Location = new Point(0, splitContainer1.Height - btnHeight);
            btnPartRequest.Location = new Point(padding - 1, btnHeight + 2 * padding);
            btnHistory.Location = new Point(0, btnQuit.Location.Y - btnHeight - padding);
            splitContainer1.SplitterWidth = splitContainer2.SplitterWidth = splitContainer3.SplitterWidth = padding;
            splitContainer2.SplitterDistance = (splitContainer1.Height - 2 * padding) / 3;
            splitContainer3.SplitterDistance = (splitContainer3.Height - padding) / 2;      
            pBLogo.Location = new Point(0, btnHistory.Location.Y - btnHeight - padding - 157);   
        }
        
        private void OpenHistoryForm()
        {
            historyForm = new HistoryForm(this);
            historyForm.ShowDialog();
            switch (historyForm.DialogResult)
            {
                case DialogResult.Cancel:
                    this.Close();
                    break;
                case DialogResult.OK:
                    FillDataTables();
                    break;
            }
        }
        
#region Event Handlers

        private void btnPartRequest_Click(object sender, EventArgs e)
        { 
            requestPartForm = new PartRequestForm();
            if(requestPartForm.ShowDialog() == DialogResult.OK)
                FillDataTables();
        }
        
        private void buttonColumnRequest_Click(object sender, EventArgs e)
        {
            requestColumnForm = new ColumnRequestForm();
            requestColumnForm.ShowDialog();
            FillDataTables();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            OpenHistoryForm();
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
            if (e.RowIndex > -1)
            {
                int shortSide = Math.Min(e.CellBounds.Width, e.CellBounds.Height) *7 / 10;
                infoIcon = (Image)new Bitmap(infoIcon, new Size(shortSide, shortSide));
                checkIcon = (Image)new Bitmap(checkIcon, new Size(shortSide, shortSide));
                DataGridView dGV = (DataGridView)sender;

                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background);

                e.PaintContent(e.CellBounds);

                if (e.ColumnIndex == dGV.Columns["Info"].Index)
                {
                    e.Graphics.DrawImage(infoIcon, e.CellBounds.Location.X + (e.CellBounds.Width - infoIcon.Size.Width) / 2,
                                                e.CellBounds.Location.Y + (e.CellBounds.Height - infoIcon.Size.Height) / 2);
                }

                if (e.ColumnIndex == dGV.Columns["Decon"].Index ||
                    e.ColumnIndex == dGV.Columns["Dishwasher"].Index ||
                    e.ColumnIndex == dGV.Columns["WaterPik"].Index ||
                    e.ColumnIndex == dGV.Columns["Ultrasonic"].Index ||
                    e.ColumnIndex == dGV.Columns["Crest10"].Index ||
                    e.ColumnIndex == dGV.Columns["Crest20"].Index ||
                    e.ColumnIndex == dGV.Columns["CrestLong"].Index ||
                    e.ColumnIndex == dGV.Columns["CR Ready"].Index ||
                    e.ColumnIndex == dGV.Columns["Bulk"].Index ||
                    e.ColumnIndex == dGV.Columns["Cage"].Index ||
                    e.ColumnIndex == dGV.Columns["Hot"].Index)
                {
                    if ((bool)dGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
                        e.Graphics.DrawImage(checkIcon, e.CellBounds.Location.X + (e.CellBounds.Width - checkIcon.Size.Width) / 2,
                                                    e.CellBounds.Location.Y + (e.CellBounds.Height - checkIcon.Size.Height) / 2);

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
                if (dgv.Columns.Contains("Info"))
                {
                    if (e.ColumnIndex == dgv.Columns["Info"].Index)
                    {
                        
                        reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());                
                        //Show Details
                        detailsForm = new DetailsForm(reqId);
                        detailsForm.ShowDialog();
                    }
                }
            }
        }
        
        private void dGV_Sorted(object sender, EventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            FormatDGVInfoHot(dGV);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            FormatLayout();
        }

        private void splitContainer_Paint(object sender, PaintEventArgs e)
        {
            var control = sender as SplitContainer;
            //paint the three dots'
            Point[] points = new Point[3];
            var w = control.Width;
            var h = control.Height;
            var d = control.SplitterDistance;
            var sW = control.SplitterWidth;

            //calculate the position of the points'
            if (control.Orientation == Orientation.Horizontal)
            {
                points[0] = new Point((w / 2), d + (sW / 2));
                points[1] = new Point(points[0].X - 20, points[0].Y);
                points[2] = new Point(points[0].X + 20, points[0].Y);
            }
            else
            {
                points[0] = new Point(d + (sW / 2), (h / 2));
                points[1] = new Point(points[0].X, points[0].Y - 10);
                points[2] = new Point(points[0].X, points[0].Y + 10);
            }

            foreach (Point p in points)
            {
                p.Offset(-2, -2);
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue),
                    new Rectangle(p, new Size(3, 3)));

                p.Offset(1, 1);
                e.Graphics.FillEllipse(SystemBrushes.ControlLight,
                    new Rectangle(p, new Size(3, 3)));
            }
        }
        
#endregion

#region BackGround Workers

        private void bGWorkerFillTables_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB cleaningRequestsDB = new RequestsDB();
            PartsDB partDB = new PartsDB();
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
            contactTable = dBTable[1];


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
                    if ((DateTime)row["Finished"] > DateTime.Today.AddDays(-2))
                        finishedTable.Rows.Add(row.ItemArray);
                }
            }
            InitQueueDGV();
            InitInProcessDGV();
            InitCompletedDGV();
            progressForm.Close();
        }

        #endregion
        

    }
}
