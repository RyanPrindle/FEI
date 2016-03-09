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
    public partial class AdminForm : Form
    {
        private DataTable mQueueTable;
        private DataTable mInProcessTable;
        private DataGridViewCellStyle dGVStyle = new DataGridViewCellStyle();
        private ProgressBarForm progressForm;


        public AdminForm( List<DataTable> tables)
        {
            InitializeComponent();
            mQueueTable = tables[0];
            mInProcessTable = tables[1];
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void LoadDGV()
        {
            SetDGVStyle();
            InitQueueDGV();
            InitInProcessDGV();
        }

        private void SetDGVStyle()
        {
            dGVStyle.Padding = new Padding(3);
            dGVStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVStyle.ForeColor = SystemColors.ControlText;
            dGVStyle.SelectionForeColor = dGVStyle.SelectionBackColor;
        }

        private void InitQueueDGV()
        {
            DataGridViewButtonColumn btnStartColumn = new DataGridViewButtonColumn();
            btnStartColumn.Name = "Start";
            btnStartColumn.HeaderText = "Clean";
            btnStartColumn.Text = "Start";
            btnStartColumn.UseColumnTextForButtonValue = true;

            dGVAdminQueue.SuspendLayout();
            dGVAdminQueue.DataSource = mQueueTable;
            dGVAdminQueue.DefaultCellStyle = dGVStyle;
            if (!(dGVAdminQueue.Columns[0].Name == "Start"))
            {
                dGVAdminQueue.Columns.Add(btnStartColumn);
            }
            dGVAdminQueue.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminQueue.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminQueue.Columns["RequestID"].Visible = false;
            dGVAdminQueue.Columns["Finished"].Visible = false;
            dGVAdminQueue.Columns["Started"].Visible = false;
            dGVAdminQueue.Columns["Type1"].Visible = false;
            dGVAdminQueue.Columns["Type2"].Visible = false;
            dGVAdminQueue.Columns["Type3"].Visible = false;
            dGVAdminQueue.Columns["Type4"].Visible = false;
            dGVAdminQueue.Columns["Serial Number"].Visible = false;
            dGVAdminQueue.Columns["Contact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVAdminQueue.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVAdminQueue.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVAdminQueue.ResumeLayout();
        }

        private void InitInProcessDGV()
        {
            DataGridViewButtonColumn btnFinishColumn = new DataGridViewButtonColumn();
            btnFinishColumn.Name = "Finish";
            btnFinishColumn.HeaderText = "Finish";
            btnFinishColumn.Text = "Done";
            btnFinishColumn.UseColumnTextForButtonValue = true;

            dGVAdminInProcess.SuspendLayout();
            dGVAdminInProcess.DataSource = mQueueTable;
            dGVAdminInProcess.DefaultCellStyle = dGVStyle;
            if (!(dGVAdminInProcess.Columns[0].Name == "Finish"))
            {
                dGVAdminInProcess.Columns.Add(btnFinishColumn);
            }
            dGVAdminInProcess.DataSource = mInProcessTable;
            dGVAdminInProcess.Columns["Requested"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["Started"].DefaultCellStyle.Format = "M/d/yyyy";
            dGVAdminInProcess.Columns["RequestID"].Visible = false;
            dGVAdminInProcess.Columns["Finished"].Visible = false;
            dGVAdminInProcess.Columns["Type1"].Visible = false;
            dGVAdminInProcess.Columns["Type2"].Visible = false;
            dGVAdminInProcess.Columns["Type3"].Visible = false;
            dGVAdminInProcess.Columns["Type4"].Visible = false;
            dGVAdminInProcess.Columns["Serial Number"].Visible = false;
            dGVAdminInProcess.Columns["Contact"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVAdminInProcess.Columns["Part Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVAdminInProcess.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVAdminInProcess.ResumeLayout();
        }

        private void dGVAdminQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                if (e.ColumnIndex == dGVAdminQueue.Columns["Start"].Index)
                {
                    //Start Cleaning
                    MessageBox.Show("Start Cleaning " + reqId);
                    StartCleaning(reqId);
                }
            }
        }

        private void dGVAdminInProcess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int reqId = 0;
            if (e.RowIndex >= 0)
            {
                reqId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["RequestID"].Value.ToString());
                if (e.ColumnIndex == dGVAdminInProcess.Columns["Finish"].Index)
                {
                    //Finish Cleaning
                    MessageBox.Show("Finish Cleaning " + reqId);
                }
            }
        }

        private void StartCleaning(int reqId)
        {
            progressForm = new ProgressBarForm();
            bGWStartCleaning = new BackgroundWorker();
            bGWStartCleaning.DoWork += new DoWorkEventHandler(bGWStartCleaning_DoWork);
            bGWStartCleaning.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWStartCleaning_RunWorkerCompleted);
            bGWStartCleaning.RunWorkerAsync();
            progressForm.ShowDialog();
        }

        private void bGWStartCleaning_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bGWStartCleaning_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressForm.Close();
        }
    }
}
