﻿using System;
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

        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
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
            ResetFilteredTable();
            LoadPartComboBox();
            LoadRequestorComboBox();
            ResetDateFilters();
            InitHistoryDGV();
            mProgress.Close();
        }

        private void ResetDateFilters()
        {
            dTPickerRequestedFrom.ValueChanged -= new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerRequestedTo.ValueChanged -= new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerStartedFrom.ValueChanged -= new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerStartedTo.ValueChanged -= new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerFinishedFrom.ValueChanged -= new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerFinishedTo.ValueChanged -= new System.EventHandler(this.dTPicker_ValueChanged);

            dTPickerRequestedFrom.MinDate = beginDate;
            dTPickerRequestedFrom.Value = DateTime.Today.AddDays(-30).Date;
            dTPickerRequestedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerRequestedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerRequestedTo.MinDate = dTPickerRequestedFrom.Value;
            dTPickerRequestedFrom.MaxDate = dTPickerRequestedTo.Value;

            dTPickerStartedFrom.MinDate = beginDate;
            dTPickerStartedFrom.Value = DateTime.Today.AddDays(-30).Date;
            dTPickerStartedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerStartedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerStartedTo.MinDate = dTPickerStartedFrom.Value;
            dTPickerStartedFrom.MaxDate = dTPickerStartedTo.Value;

            dTPickerFinishedFrom.MinDate = beginDate;
            dTPickerFinishedFrom.Value = DateTime.Today.AddDays(-30).Date;
            dTPickerFinishedTo.Value = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerFinishedTo.MaxDate = DateTime.Today.Date.AddDays(1).AddTicks(-1);
            dTPickerFinishedTo.MinDate = dTPickerFinishedFrom.Value;
            dTPickerFinishedFrom.MaxDate = dTPickerFinishedTo.Value;

            dTPickerRequestedFrom.ValueChanged += new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerRequestedTo.ValueChanged += new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerStartedFrom.ValueChanged += new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerStartedTo.ValueChanged += new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerFinishedFrom.ValueChanged += new System.EventHandler(this.dTPicker_ValueChanged);
            dTPickerFinishedTo.ValueChanged += new System.EventHandler(this.dTPicker_ValueChanged);
        }

        private void InitHistoryDGV()
        {
            dGVHistory.SuspendLayout();
            dGVHistory.DataSource = null;
            dGVHistory.Rows.Clear();
            dGVHistory.Columns.Clear();
            dGVHistory.DataSource = mFilteredTable;
            dGVHistory.Columns["RequestID"].Visible = false;
            dGVHistory.EditMode = DataGridViewEditMode.EditProgrammatically;
            FormatDGVChecksAndHot(dGVHistory);
            dGVHistory.ResumeLayout();
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

        private void ResetFilteredTable()
        {
            mFilteredTable = new DataTable();
            mFilteredTable = mHistoryTable.Copy();
        }

        private void FilterTableByDate()
        {
            dGVHistory.SuspendLayout();
            int rowCount = mFilteredTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                if (mFilteredTable.Rows[row].Field<DateTime>("RequestedOn") < dTPickerRequestedFrom.Value.Date ||
                    mFilteredTable.Rows[row].Field<DateTime>("RequestedOn") > dTPickerRequestedTo.Value.Date.AddDays(1).AddTicks(-1) ||
                    mFilteredTable.Rows[row].Field<DateTime>("StartedOn") < dTPickerStartedFrom.Value.Date ||
                    mFilteredTable.Rows[row].Field<DateTime>("StartedOn") > dTPickerStartedTo.Value.Date.AddDays(1).AddTicks(-1) ||
                    mFilteredTable.Rows[row].Field<DateTime>("FinishedOn") < dTPickerFinishedFrom.Value.Date ||
                    mFilteredTable.Rows[row].Field<DateTime>("FinishedOn") > dTPickerFinishedTo.Value.Date.AddDays(1).AddTicks(-1))
                {
                    mFilteredTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }          
            dGVHistory.ResumeLayout();
            LoadPartComboBox();
            LoadRequestorComboBox();
        }

        private void FilterTableByPart()
        {
            dGVHistory.SuspendLayout();
            int rowCount = mFilteredTable.Rows.Count;
            if (!(comboBoxPartFilter.SelectedItem.ToString() == "All"))
            {
                for (int row = 0; row < rowCount; row++)
                {
                    if (!(mFilteredTable.Rows[row].Field<string>("PartNumber").ToString() == comboBoxPartFilter.SelectedItem.ToString()))
                    {
                        mFilteredTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
            }
            dGVHistory.ResumeLayout();
            LoadRequestorComboBox();
        }

        private void FilterTableByRequestor()
        {
            dGVHistory.SuspendLayout();
            int rowCount = mFilteredTable.Rows.Count;
            if (!(comboBoxRequestor.SelectedItem.ToString() == "All"))
            {
                for (int row = 0; row < rowCount; row++)
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
            LoadPartComboBox();
        }
        
        private void LoadRequestorComboBox()
        {
            comboBoxRequestor.SelectedIndexChanged -= new System.EventHandler(this.comboBoxFilterPart_SelectedIndexChanged);           
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
            comboBoxRequestor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterPart_SelectedIndexChanged);  
        }

        private void LoadPartComboBox()
        {
            comboBoxPartFilter.SelectedIndexChanged -= new System.EventHandler(this.comboBoxFilterPart_SelectedIndexChanged);
            List<String> partList = new List<string>();
            partList.Add("All");
            foreach (DataRow row in mFilteredTable.Rows)
            {
                {
                    partList.Add(row["PartNumber"].ToString());
                }
            }
            mPartList = partList.Distinct().ToList();
            comboBoxPartFilter.DataSource = mPartList;
            comboBoxPartFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterPart_SelectedIndexChanged);           
        }

        private void dTPicker_ValueChanged(object sender, EventArgs e)
        {
            dTPickerFinishedFrom.MaxDate = dTPickerFinishedTo.Value;
            dTPickerFinishedFrom.MinDate = dTPickerFinishedFrom.Value;
            dTPickerFinishedTo.MinDate = dTPickerFinishedFrom.Value;
            dTPickerRequestedFrom.MaxDate = dTPickerRequestedTo.Value;
            dTPickerRequestedFrom.MinDate = dTPickerRequestedFrom.Value;
            dTPickerRequestedTo.MinDate = dTPickerRequestedFrom.Value;
            dTPickerStartedFrom.MaxDate = dTPickerStartedTo.Value;
            dTPickerStartedFrom.MinDate = dTPickerStartedFrom.Value;
            dTPickerStartedTo.MinDate = dTPickerStartedFrom.Value;

            FilterTableByDate();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetDateFilters();
            ResetFilteredTable();
            LoadPartComboBox();
            LoadRequestorComboBox();
            InitHistoryDGV();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void dTPicker_Enter(object sender, EventArgs e)
        {
            buttonReset.Focus();
        }

        private void comboBoxFilterPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTableByPart();
        }

        private void comboBoxRequestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTableByRequestor();
        }
    }
}
