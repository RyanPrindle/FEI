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
        private static DateTime beginDate = new DateTime(2016, 2, 1);
        private MainForm mMainForm;
        private DetailsForm detailsForm;        
        private Image infoIcon;
        private Font dTPFont = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private String dTPFormat = "M / dd / yyyy";

        public HistoryForm(MainForm mainForm)
        {
            InitializeComponent();
            mMainForm = mainForm;
            //infoIcon = global::Cleaning_Scheduler_Interface.Properties.Resources.info_icon_53629;
            infoIcon = global::Cleaning_Scheduler_Interface.Properties.Resources.blue_info_button_icon_24543;
            
            
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            buttonBack.DialogResult = DialogResult.OK;
            buttonQuit.DialogResult = DialogResult.Cancel;
            btnMain.DialogResult = DialogResult.Abort;
            GetHistoryData();
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
            e.Result = table;
        }

        private void bGWorkerHistoryLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mHistoryTable = new DataTable();
            mHistoryTable = (DataTable)e.Result;
            mHistoryTable.Columns["Quantity"].ColumnName = "Qty";
            mHistoryTable.Columns["RequestedOn"].ColumnName = "Requested";
            mHistoryTable.Columns["StartedOn"].ColumnName = "Started";
            mHistoryTable.Columns["FinishedOn"].ColumnName = "Finished";
            mHistoryTable.Columns["SerialNumber"].ColumnName = "Serial #";
            mHistoryTable.Columns["PartNumber"].ColumnName = "Part #";
            mHistoryTable.Columns["Email"].ColumnName = "Contact";
            
            ResetDateFilters();
            InitHistoryDGV();
            LoadPartComboBox();
            LoadRequestorComboBox();
            //InitHistoryDGV();
            mProgress.Close();
        }

        private void ResetDateFilters()
        {
            dTPickerRequestedFrom.ValueChanged -= new System.EventHandler(this.Filter_ValueChanged);
            dTPickerRequestedTo.ValueChanged -= new System.EventHandler(this.Filter_ValueChanged);
            dTPickerStartedFrom.ValueChanged -= new System.EventHandler(this.Filter_ValueChanged);
            dTPickerStartedTo.ValueChanged -= new System.EventHandler(this.Filter_ValueChanged);
            dTPickerFinishedFrom.ValueChanged -= new System.EventHandler(this.Filter_ValueChanged);
            dTPickerFinishedTo.ValueChanged -= new System.EventHandler(this.Filter_ValueChanged);

            dTPickerRequestedFrom.MinDate = beginDate;
            dTPickerRequestedFrom.Value = DateTime.Today.AddDays(-30).Date;
            dTPickerRequestedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerRequestedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerRequestedTo.MinDate = dTPickerRequestedFrom.Value;
            dTPickerRequestedFrom.MaxDate = dTPickerRequestedTo.Value;
            dTPickerRequestedFrom.CustomFormat = dTPFormat;
            dTPickerRequestedFrom.Format = DateTimePickerFormat.Custom;
            dTPickerRequestedFrom.Font = dTPFont;
            dTPickerRequestedTo.CustomFormat = dTPFormat;
            dTPickerRequestedTo.Format = DateTimePickerFormat.Custom;
            dTPickerRequestedTo.Font = dTPFont;

            dTPickerStartedFrom.MinDate = beginDate;
            dTPickerStartedFrom.Value = DateTime.Today.AddDays(-30).Date;
            dTPickerStartedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerStartedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerStartedTo.MinDate = dTPickerStartedFrom.Value;
            dTPickerStartedFrom.MaxDate = dTPickerStartedTo.Value;
            dTPickerStartedFrom.CustomFormat = dTPFormat;
            dTPickerStartedFrom.Format = DateTimePickerFormat.Custom;
            dTPickerStartedFrom.Font = dTPFont;
            dTPickerStartedTo.CustomFormat = dTPFormat;
            dTPickerStartedTo.Format = DateTimePickerFormat.Custom;
            dTPickerStartedTo.Font = dTPFont;

            dTPickerFinishedFrom.MinDate = beginDate;
            dTPickerFinishedFrom.Value = DateTime.Today.AddDays(-30).Date;
            dTPickerFinishedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerFinishedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerFinishedTo.MinDate = dTPickerFinishedFrom.Value;
            dTPickerFinishedFrom.MaxDate = dTPickerFinishedTo.Value;
            dTPickerFinishedFrom.CustomFormat = dTPFormat;
            dTPickerFinishedFrom.Format = DateTimePickerFormat.Custom;
            dTPickerFinishedFrom.Font = dTPFont;
            dTPickerFinishedTo.CustomFormat = dTPFormat;
            dTPickerFinishedTo.Format = DateTimePickerFormat.Custom;
            dTPickerFinishedTo.Font = dTPFont;

            dTPickerRequestedFrom.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            dTPickerRequestedTo.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            dTPickerStartedFrom.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            dTPickerStartedTo.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            dTPickerFinishedFrom.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            dTPickerFinishedTo.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
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
            dGVHistory.Columns["RequestID"].Visible = false;
            dGVHistory.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVHistory.RowsDefaultCellStyle.Font = mMainForm.dGVRowFont;
            dGVHistory.ColumnHeadersDefaultCellStyle.Font = mMainForm.dGVHeaderFont;
            mMainForm.FormatDGVCheckboxInfoHot(dGVHistory);
            //dGVHistory.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVHistory.MouseWheel += new MouseEventHandler(dGV_MouseWheel);            
            dGVHistory.ResumeLayout();
        }

        private void FilterTable()
        {
            dGVHistory.SuspendLayout();
            int rowCount = mFilteredTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
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
                if (!(comboBoxPartFilter.SelectedItem.ToString() == ("All")) && row >= 0)
                {
                    if (!(mFilteredTable.Rows[row].Field<string>("Part #").ToString() == comboBoxPartFilter.SelectedItem.ToString()))
                    {
                        mFilteredTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
                if (!(comboBoxRequestor.SelectedItem.ToString() == "All") && row >= 0)
                {
                    if (!(mFilteredTable.Rows[row].Field<string>("Requestor").ToString() == comboBoxRequestor.SelectedItem.ToString()))
                    {
                        mFilteredTable.Rows.RemoveAt(row);
                            row--;
                            rowCount--;
                    }
                }
            }          
            dGVHistory.ResumeLayout();
        }       

        private void LoadRequestorComboBox()
        {
            comboBoxRequestor.SelectedIndexChanged -= new System.EventHandler(this.Filter_ValueChanged);
            List<String> requestorList = new List<string>();
            requestorList.Add("All");
            foreach (DataRow row in mFilteredTable.Rows)
            {
                {
                    requestorList.Add(row["Requestor"].ToString());
                }
            }
            mRequestorList = requestorList.Distinct().ToList();
            comboBoxRequestor.DataSource = mRequestorList;
            comboBoxRequestor.Font = dTPFont;
            comboBoxRequestor.SelectedIndexChanged += new System.EventHandler(this.Filter_ValueChanged);
        }

        private void LoadPartComboBox()
        {
            comboBoxPartFilter.SelectedIndexChanged -= new System.EventHandler(this.Filter_ValueChanged);
            List<String> partList = new List<string>();
            partList.Add("All");
            foreach (DataRow row in mFilteredTable.Rows)
            {
                {
                    partList.Add(row["Part #"].ToString());
                }
            }
            mPartList = partList.Distinct().ToList();
            comboBoxPartFilter.DataSource = mPartList;
            comboBoxPartFilter.Font = dTPFont;
            comboBoxPartFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_ValueChanged);
        }

        private void Filter_ValueChanged(object sender, EventArgs e)
        {
            InitHistoryDGV();
            FilterTable();
        }   

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetDateFilters();
            InitHistoryDGV();
            comboBoxPartFilter.SelectedIndex = 0;
            comboBoxRequestor.SelectedIndex = 0;
        }
        
        private void dTPicker_Enter(object sender, EventArgs e)
        {
            buttonReset.Focus();
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
            
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                int shortSide = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 10;
                infoIcon = (Image)new Bitmap(infoIcon, new Size(shortSide, shortSide));
                DataGridView dGV = (DataGridView)sender;
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
            mMainForm.FormatDGVCheckboxInfoHot(dGVHistory);            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
