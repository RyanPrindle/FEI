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
    public partial class HistoryForm : Form
    {
        private String[] boolNames = new String[] { "Decon", "Dishwasher", "WaterPik", "Ultrasonic", "Crest10", "Crest20", "CrestLong", "CleanRoomReady", "Bulk", "Cage", "Hot" };
        private Font dGVCheckboxSize = new System.Drawing.Font("Arial", 24.25F, System.Drawing.FontStyle.Bold);
        private ProgressBarForm mProgress;
        private DataTable mHistoryTable;
        private List<String> mPartList;
        private List<String> mRequestorList;
        private DataTable mFilteredTable;
        private static DateTime beginDate = new DateTime(2016, 1, 1);
        private MainForm mMainForm;
        private DetailsForm detailsForm;        
        private Image infoIcon;
        private Image checkIcon;
        private Font dTPFont = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font cBFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private String dTPFormat = "M / dd / yyyy";
        private bool calendarDroppedDown = false;
        private int dgvScrollOffset;

        public HistoryForm(MainForm mainForm)
        {
            InitializeComponent();
            mMainForm = mainForm;
            //infoIcon = global::Cleaning_Scheduler_Interface.Properties.Resources.info_icon_53629;
            infoIcon = Cleaning_Scheduler_Interface.Properties.Resources.blueInfoButtonIcon;
            checkIcon = global::Cleaning_Scheduler_Interface.Properties.Resources.GreenCheck;

            
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            FormatLayout();
            GetHistoryData();
        }

        private void FormatLayout()
        {
            int pad = 10;
            int btnHeight = (panelDGV.Height - panelFilter.Height - 3 * pad) / 3;
            btnQuit.Location = new Point(panelFilter.Location.X ,panelDGV.Height + pad - btnHeight + 3);
            btnBack.Location = new Point(panelFilter.Location.X, panelDGV.Height - 2 * btnHeight + 3);
            btnMain.Location = new Point(panelFilter.Location.X, panelDGV.Height - pad - 3 * btnHeight + 3);
            btnQuit.Height = btnMain.Height = btnBack.Height = btnHeight;
            btnQuit.Font = btnMain.Font = btnBack.Font = buttonReset.Font = mMainForm.btnFont;
        }

        private void GetHistoryData()
        {
            mProgress = new ProgressBarForm();
            bGWorkerHistoryLoad = new BackgroundWorker();
            bGWorkerHistoryLoad.DoWork += new DoWorkEventHandler(bGWorkerHistoryLoad_DoWork);
            bGWorkerHistoryLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerHistoryLoad_RunWorkerCompleted);
            bGWorkerHistoryLoad.RunWorkerAsync();
            mProgress.ShowDialog();
        }

        private void bGWorkerHistoryLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB requestDB = new RequestsDB();
            DataTable table = new DataTable();
            table = requestDB.GetRequestHistoryTable();
            table.Columns["Quantity"].ColumnName = "Qty";
            table.Columns["RequestedOn"].ColumnName = "Requested";
            table.Columns["StartedOn"].ColumnName = "Started";
            table.Columns["FinishedOn"].ColumnName = "Finished";
            table.Columns["SerialNumber"].ColumnName = "Serial #";
            table.Columns["PartNumber"].ColumnName = "Part #";
            table.Columns["Email"].ColumnName = "Contact";
            e.Result = table;
        }

        private void bGWorkerHistoryLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mHistoryTable = new DataTable();
            mHistoryTable = (DataTable)e.Result;
            InitFilters();
            InitHistoryDGV();
            LoadPartComboBox();
            LoadRequestorComboBox();            
            mProgress.Close();
        }

        private void InitFilters()
        {                 
            
            dTPickerRequestedFrom.CustomFormat = dTPFormat;
            dTPickerRequestedFrom.Format = DateTimePickerFormat.Custom;
            dTPickerRequestedFrom.Font = dTPFont;
            dTPickerRequestedFrom.MinDate = beginDate;
            dTPickerRequestedFrom.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerRequestedFrom.Value = beginDate;
            
            dTPickerRequestedTo.CustomFormat = dTPFormat;
            dTPickerRequestedTo.Format = DateTimePickerFormat.Custom;
            dTPickerRequestedTo.Font = dTPFont;
            dTPickerRequestedTo.MinDate = beginDate;
            dTPickerRequestedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerRequestedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);

            dTPickerStartedFrom.CustomFormat = dTPFormat;
            dTPickerStartedFrom.Format = DateTimePickerFormat.Custom;
            dTPickerStartedFrom.Font = dTPFont;
            dTPickerStartedFrom.MinDate = beginDate;
            dTPickerStartedFrom.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerStartedFrom.Value = beginDate;    
        
            dTPickerStartedTo.CustomFormat = dTPFormat;
            dTPickerStartedTo.Format = DateTimePickerFormat.Custom;
            dTPickerStartedTo.Font = dTPFont;
            dTPickerStartedTo.MinDate = beginDate;
            dTPickerStartedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerStartedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);

            dTPickerFinishedFrom.CustomFormat = dTPFormat;
            dTPickerFinishedFrom.Format = DateTimePickerFormat.Custom;
            dTPickerFinishedFrom.Font = dTPFont;
            dTPickerFinishedFrom.MinDate = beginDate;
            dTPickerFinishedFrom.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerFinishedFrom.Value = beginDate;

            dTPickerFinishedTo.CustomFormat = dTPFormat;
            dTPickerFinishedTo.Format = DateTimePickerFormat.Custom;
            dTPickerFinishedTo.Font = dTPFont;
            dTPickerFinishedTo.MinDate = beginDate;
            dTPickerFinishedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerFinishedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);

            rBCRRBoth.CheckedChanged -= new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBCRRYes.CheckedChanged -= new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBCRRNo.CheckedChanged -= new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBHotBoth.CheckedChanged -= new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBHotYes.CheckedChanged -= new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBHotNo.CheckedChanged -= new System.EventHandler(this.rBCRRHot_CheckedChanged);

            rBCRRBoth.Checked = true;
            rBHotBoth.Checked = true;
            
            rBCRRBoth.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBCRRYes.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBCRRNo.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBHotBoth.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBHotYes.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            rBHotNo.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
        }
       
        private void InitHistoryDGV()
        {
            dGVHistory.SuspendLayout();
            dGVHistory.MouseWheel -= new MouseEventHandler(dGV_MouseWheel);
            dGVHistory.DataSource = null;
            dGVHistory.Rows.Clear();
            dGVHistory.Columns.Clear();
            mFilteredTable = new DataTable();
            mFilteredTable = mHistoryTable.Copy();
            dGVHistory.DataSource = mFilteredTable;

            dGVHistory.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVHistory.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVHistory.Columns["Finished"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVHistory.Columns["RequestID"].Visible = false;
            dGVHistory.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVHistory.RowsDefaultCellStyle.Font = mMainForm.dGVRowFont;
            dGVHistory.ColumnHeadersDefaultCellStyle.Font = mMainForm.dGVHeaderFont;
            mMainForm.FormatDGVInfoHot(dGVHistory);
            dGVHistory.MouseWheel += new MouseEventHandler(dGV_MouseWheel);
            LoadPartComboBox();
            LoadRequestorComboBox();
            dGVHistory.ResumeLayout();
        }

        private void FilterTable()
        {
            dGVHistory.SuspendLayout();
            dgvScrollOffset = dGVHistory.HorizontalScrollingOffset;
            mFilteredTable = new DataTable();
            mFilteredTable = mHistoryTable.Copy();
            dGVHistory.DataSource = mFilteredTable;
            int rowCount = mFilteredTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                if (!(comboBoxPartFilter.SelectedItem.ToString() == ("All")) && row >= 0)
                {
                    if (!(mFilteredTable.Rows[row].Field<string>("Part #").ToString() == comboBoxPartFilter.SelectedItem.ToString()))
                    {
                        mFilteredTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
                else if (!(comboBoxRequestor.SelectedItem.ToString() == "All") && row >= 0)
                {
                    if (!(mFilteredTable.Rows[row].Field<string>("Requestor").ToString() == comboBoxRequestor.SelectedItem.ToString()))
                    {
                        mFilteredTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
                else if (mFilteredTable.Rows[row].Field<Boolean>("CR Ready").Equals(false) && (rBCRRYes.Checked == true))
                {
                    mFilteredTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
                else if (mFilteredTable.Rows[row].Field<Boolean>("CR Ready").Equals(true) && (rBCRRNo.Checked == true))
                {
                    mFilteredTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
                else if (mFilteredTable.Rows[row].Field<Boolean>("Hot").Equals(false) && (rBHotYes.Checked == true))
                {
                    mFilteredTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
                else if (mFilteredTable.Rows[row].Field<Boolean>("Hot").Equals(true) && (rBHotNo.Checked == true))
                {
                    mFilteredTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }

                else if (!calendarDroppedDown)
                {
                    if (mFilteredTable.Rows[row].Field<DateTime>("Requested") < dTPickerRequestedFrom.Value.Date ||
                        mFilteredTable.Rows[row].Field<DateTime>("Requested") > dTPickerRequestedTo.Value.Date.AddDays(1).AddTicks(-1) ||
                        mFilteredTable.Rows[row].Field<DateTime>("Started") < dTPickerStartedFrom.Value.Date ||
                        mFilteredTable.Rows[row].Field<DateTime>("Started") > dTPickerStartedTo.Value.Date.AddDays(1).AddTicks(-1) ||
                        mFilteredTable.Rows[row].Field<DateTime>("Finished") < dTPickerFinishedFrom.Value.Date ||
                        mFilteredTable.Rows[row].Field<DateTime>("Finished") > dTPickerFinishedTo.Value.Date.AddDays(1).AddTicks(-1))
                    {
                        mFilteredTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
            }
            mMainForm.FormatDGVInfoHot(dGVHistory);
            dGVHistory.HorizontalScrollingOffset = dgvScrollOffset;
            dGVHistory.ResumeLayout();
        }

        private void LoadRequestorComboBox()
        {
            object item = null;
            if (comboBoxRequestor.SelectedIndex >= 0)
                item = comboBoxRequestor.SelectedItem;
            comboBoxRequestor.SelectedIndexChanged -= new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            mRequestorList = new List<string>();
            foreach (DataRow row in mFilteredTable.Rows)
            {
                {
                    mRequestorList.Add(row["Requestor"].ToString());
                }
            }
            mRequestorList = mRequestorList.Distinct().ToList();
            mRequestorList.Sort();
            mRequestorList.Insert(0, "All");
            comboBoxRequestor.DataSource = mRequestorList;
            comboBoxRequestor.Font = cBFont;
            if (item != null)
                comboBoxRequestor.SelectedItem = item;
            comboBoxRequestor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
        }

        private void LoadPartComboBox()
        {
            object item = null;
            if (comboBoxPartFilter.SelectedIndex >= 0)
                item = comboBoxPartFilter.SelectedItem; 
            comboBoxPartFilter.SelectedIndexChanged -= new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            mPartList = new List<string>();
            
            foreach (DataRow row in mFilteredTable.Rows)
            {
                {
                    mPartList.Add(row["Part #"].ToString());
                }
            }
            mPartList = mPartList.Distinct().ToList();
            mPartList.Sort();
            mPartList.Insert(0,"All");
            comboBoxPartFilter.DataSource = mPartList;
            comboBoxPartFilter.Font = cBFont;
            if (item != null)
                comboBoxPartFilter.SelectedItem = item;
            comboBoxPartFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTable();
        } 

        private void buttonReset_Click(object sender, EventArgs e)
        {
            InitFilters();
            InitHistoryDGV();
            comboBoxPartFilter.SelectedIndex = 0;
            comboBoxRequestor.SelectedIndex = 0;
            LoadPartComboBox();
            LoadRequestorComboBox();
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
                int shortSide = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 10;
                infoIcon = (Image)new Bitmap(infoIcon, new Size(shortSide, shortSide));
                checkIcon = (Image)new Bitmap(checkIcon, new Size(shortSide, shortSide));
                DataGridView dGV = (DataGridView)sender;

                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
                //e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background);

                

                if (e.ColumnIndex == dGV.Columns["Info"].Index)
                {
                    e.PaintContent(e.CellBounds);
                    e.Graphics.DrawImage(infoIcon, e.CellBounds.Location.X + (e.CellBounds.Width - infoIcon.Size.Width) / 2,
                                                e.CellBounds.Location.Y + (e.CellBounds.Height - infoIcon.Size.Height) / 2);
                }

                else if (e.ColumnIndex == dGV.Columns["Decon"].Index ||
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
                    if((bool)dGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
                    e.Graphics.DrawImage(checkIcon, e.CellBounds.Location.X + (e.CellBounds.Width - checkIcon.Size.Width) / 2,
                                                e.CellBounds.Location.Y + (e.CellBounds.Height - checkIcon.Size.Height) / 2);
                }
                else
                    e.PaintContent(e.CellBounds);
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

        private void dGVHistory_Sorted(object sender, EventArgs e)
        {
            mMainForm.FormatDGVInfoHot(dGVHistory);
            dGVHistory.HorizontalScrollingOffset = dgvScrollOffset;
        }

        private void dGV_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dGV = (DataGridView)sender;
            dGV.Update();
        }
       
        private void dTPicker_Enter(object sender, EventArgs e)
        {
            buttonReset.Focus();
        }

        private void dTPicker_DropDown(object sender, EventArgs e)
        {
            calendarDroppedDown = true;
        }

        private void dTPicker_CloseUp(object sender, EventArgs e)
        {
            calendarDroppedDown = false;
            FilterTable();
        }

        private void rBCRRHot_CheckedChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void dGVHistory_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.Location.Y < 40)
                dgvScrollOffset = dgv.HorizontalScrollingOffset;
        }
    }
}
