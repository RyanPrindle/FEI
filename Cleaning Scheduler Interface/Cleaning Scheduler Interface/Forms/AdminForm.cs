using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
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
        private bool edit = false;
        private MainForm mainForm;
        private DetailsForm detailsForm;

        public AdminForm(MainForm mF)
        {
            InitializeComponent();
            mainForm = mF;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            FormatLayout();
            RefreshTables();
        }

        private void FormatLayout()
        {
            int padding = 10;
            int btnHeight = splitContainer1.Height / 10;
            int btnWidth = pnlEdit.Width;
            int btnEditWidth = pnlEdit.Width - (2 * padding);
            panelHot.BackColor = mainForm.hotColor;
            panelCRR.BackColor = mainForm.crrColor;

            btnEditRequests.Font = btnReturnToMain.Font = btnQuit.Font = btnHistory.Font = mainForm.btnFont;
            
            pnlEdit.Location = new Point(splitContainer1.Width + 2 * padding, splitContainer1.Location.Y );
            pnlEdit.Height = btnHeight + 2 * padding;
            pnlLegend.Location = new Point(splitContainer1.Width + 2 * padding, splitContainer1.Location.Y + pnlEdit.Height + padding);
            btnReturnToMain.Width  = btnQuit.Width = btnHistory.Width = btnWidth;
            btnEditRequests.Width = btnEditWidth;
            btnReturnToMain.Height = btnEditRequests.Height = btnQuit.Height = btnHistory.Height = btnHeight;

            btnEditRequests.Location = new Point(padding, padding);
            btnQuit.Location = new Point(splitContainer1.Width + 2 * padding, splitContainer1.Height - btnHeight + padding);
            btnQuit.DialogResult = DialogResult.Cancel;
            btnHistory.Location = new Point(splitContainer1.Width + 2 * padding, splitContainer1.Height - 2 * btnHeight);
            btnReturnToMain.Location = new Point(splitContainer1.Width + 2 * padding, splitContainer1.Height - 3 * btnHeight - padding);
            btnReturnToMain.DialogResult = DialogResult.OK;
            pBLogo.Location = new Point(splitContainer1.Width + 2 * padding, splitContainer1.Height - 3 * btnHeight - padding - 154);
            }

        private void LoadDGV()
        {
            SetDGVStyle();
            InitDGVAdminQueue();
            InitDGVAdminInProcess();
        }

        private void SetDGVStyle()
        {
            dGVStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVStyle.ForeColor = SystemColors.ControlText;
            dGVStyle.SelectionForeColor = dGVStyle.SelectionBackColor;
            dGVStyle.Font = mainForm.dGVRowFont;
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
            btnDeleteColumn.FlatStyle = FlatStyle.Standard;

            dGVAdminQueue.SuspendLayout();
            dGVAdminQueue.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVAdminQueue.DataSource = mQueueTable;
            dGVAdminQueue.DefaultCellStyle = dGVStyle;
            dGVAdminQueue.ColumnHeadersDefaultCellStyle.Font = mainForm.dGVHeaderFont;

            if (edit)
            {
                //if (dGVAdminQueue.Columns.Contains("Start"))
                //    dGVAdminQueue.Columns.Remove("Start");

                if (!(dGVAdminQueue.Columns.Contains("Delete")))
                    dGVAdminQueue.Columns.Add(btnDeleteColumn);
            }
            else
            {
                if (dGVAdminQueue.Columns.Contains("Delete"))
                    dGVAdminQueue.Columns.Remove("Delete");

                if (!(dGVAdminQueue.Columns.Contains("Start")))
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
            dGVAdminQueue.Columns["Ultrasonic"].Visible = false;
            dGVAdminQueue.Columns["Crest10"].Visible = false;
            dGVAdminQueue.Columns["Crest20"].Visible = false;
            dGVAdminQueue.Columns["CrestLong"].Visible = false;
            dGVAdminQueue.Columns["Bulk"].Visible = false;
            dGVAdminQueue.Columns["Cage"].Visible = false;
            dGVAdminQueue.Columns["Hot"].Visible = false;
            dGVAdminQueue.Columns["CR Ready"].Visible = false;
            dGVAdminQueue.Columns["PO"].Visible = false;
            dGVAdminQueue.Columns["Serial #"].Visible = false;
            dGVAdminQueue.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dGVAdminQueue.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            mainForm.FormatDGVInfoHot(dGVAdminQueue);
            dGVAdminQueue.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            dGVAdminQueue.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVAdminQueue.ResumeLayout();
        }

        private void InitDGVAdminInProcess()
        {
            DataGridViewButtonColumn btnFinishColumn = new DataGridViewButtonColumn();
            btnFinishColumn.Name = "Finish";
            btnFinishColumn.HeaderText = "Finish";
            btnFinishColumn.Text = "Complete";
            btnFinishColumn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn btnDeleteColumn = new DataGridViewButtonColumn();
            btnDeleteColumn.Name = "Delete";
            btnDeleteColumn.HeaderText = "Remove";
            btnDeleteColumn.Text = "Delete";
            btnDeleteColumn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn btnToQueueColumn = new DataGridViewButtonColumn();
            btnToQueueColumn.Name = "MoveToQueue";
            btnToQueueColumn.HeaderText = "Cancel";
            btnToQueueColumn.Text = "Move Back";
            btnToQueueColumn.UseColumnTextForButtonValue = true;


            dGVAdminInProcess.SuspendLayout();
            dGVAdminInProcess.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);

            dGVAdminInProcess.DataSource = mQueueTable;
            dGVAdminInProcess.DefaultCellStyle = dGVStyle;
            dGVAdminInProcess.ColumnHeadersDefaultCellStyle.Font = mainForm.dGVHeaderFont;


            if (edit)
            {
                //if (dGVAdminInProcess.Columns.Contains("Finish"))
                //{
                //    dGVAdminInProcess.Columns.Remove("Finish");
                //}
                if (!(dGVAdminInProcess.Columns.Contains("Delete")))
                {
                    dGVAdminInProcess.Columns.Add(btnToQueueColumn);
                    dGVAdminInProcess.Columns.Add(btnDeleteColumn);
                }
            }
            else
            {
                if (dGVAdminInProcess.Columns.Contains("Delete"))
                {
                    dGVAdminInProcess.Columns.Remove("Delete");
                    dGVAdminInProcess.Columns.Remove("MoveToQueue");
                }
                if (!(dGVAdminInProcess.Columns.Contains("Finish")))
                {
                    dGVAdminInProcess.Columns.Add(btnFinishColumn);
                }
            }
            dGVAdminInProcess.DataSource = mInProcessTable;
            dGVAdminInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["RequestID"].Visible = false;
            dGVAdminInProcess.Columns["Requested"].Visible = false;
            dGVAdminInProcess.Columns["Finished"].Visible = false;
            dGVAdminInProcess.Columns["Decon"].Visible = false;
            dGVAdminInProcess.Columns["Dishwasher"].Visible = false;
            dGVAdminInProcess.Columns["WaterPik"].Visible = false;
            dGVAdminInProcess.Columns["Ultrasonic"].Visible = false;
            dGVAdminInProcess.Columns["Crest10"].Visible = false;
            dGVAdminInProcess.Columns["Crest20"].Visible = false;
            dGVAdminInProcess.Columns["CrestLong"].Visible = false;
            dGVAdminInProcess.Columns["Bulk"].Visible = false;
            dGVAdminInProcess.Columns["Cage"].Visible = false;
            dGVAdminInProcess.Columns["Hot"].Visible = false;
            dGVAdminInProcess.Columns["CR Ready"].Visible = false;
            dGVAdminInProcess.Columns["PO"].Visible = false;
            dGVAdminInProcess.Columns["Serial #"].Visible = false;
            dGVAdminInProcess.Columns["Instructions"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (DataGridViewRow row in dGVAdminInProcess.Rows)
            {
                if ((bool)row.Cells["Hot"].Value == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
            mainForm.FormatDGVInfoHot(dGVAdminInProcess);
            dGVAdminInProcess.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
           
            dGVAdminInProcess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVAdminInProcess.ResumeLayout();
        }

        private void FinishCleaning(int reqId)
        {
            FinishForm finishForm = new FinishForm(reqId);
            finishForm.ShowDialog();
            RefreshTables();
        }

        #region Event Handlers

        private void dGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                int shortSide = Math.Min(e.CellBounds.Width, e.CellBounds.Height) * 7 / 10;
                mainForm.infoIcon = (Image)new Bitmap(mainForm.infoIcon, new Size(shortSide, shortSide));
                mainForm.checkIcon = (Image)new Bitmap(mainForm.checkIcon, new Size(shortSide, shortSide));
                DataGridView dGV = (DataGridView)sender;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                e.PaintContent(e.CellBounds);

                if (e.ColumnIndex == dGV.Columns["Info"].Index)
                {
                    e.Graphics.DrawImage(mainForm.infoIcon, e.CellBounds.Location.X + (e.CellBounds.Width - mainForm.infoIcon.Size.Width) / 2,
                                                e.CellBounds.Location.Y + (e.CellBounds.Height - mainForm.infoIcon.Size.Height) / 2);
                }

                e.Handled = true;
            }
        }

        private void dGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                if (dGV.Columns.Contains("Start"))
                {
                    if (e.ColumnIndex == dGV.Columns["Start"].Index)
                    {
                        reqId = Int32.Parse(dGV.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                        StartCleaning(reqId);
                    }
                }
                if (dGV.Columns.Contains("Delete"))
                {
                    if (e.ColumnIndex == dGV.Columns["Delete"].Index)
                    {
                        reqId = Int32.Parse(dGV.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                        DeleteRequest(reqId);
                    }
                }

                if (dGV.Columns.Contains("Finish"))
                {
                    if (e.ColumnIndex == dGV.Columns["Finish"].Index)
                    {
                        reqId = Int32.Parse(dGV.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                        FinishCleaning(reqId);
                    }
                }

                if (dGV.Columns.Contains("MoveToQueue"))
                {
                    if (e.ColumnIndex == dGV.Columns["MoveToQueue"].Index)
                    {
                        reqId = Int32.Parse(dGV.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());      
                        MoveToQueueRequest(reqId);
                    }
                }
                if (dGV.Columns.Contains("Info"))
                {
                    if (e.ColumnIndex == dGV.Columns["Info"].Index)
                    {
                        reqId = Int32.Parse(dGV.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                        //Show Details
                        detailsForm = new DetailsForm(reqId);
                        detailsForm.ShowDialog();
                    }
                }
            }
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

        private void dGV_Sorted(object sender, EventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            mainForm.FormatDGVInfoHot(dGV);
        }

        private void AdminForm_SizeChanged(object sender, EventArgs e)
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
            requestTable.Columns["SerialNumber"].ColumnName = "Serial #";
            requestTable.Columns["PartNumber"].ColumnName = "Part Number";
            requestTable.Columns["Email"].ColumnName = "Contact";
            requestTable.Columns["Quantity"].ColumnName = "Qty";


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

        private void MoveToQueueRequest(int reqId)
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

        


    }
}
