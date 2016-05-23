using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Vacuum_Furnace_Scheduler_v1._0
{
    public partial class MainForm : Form
    {
        #region Properties

        [DllImport("user32")]
        public static extern bool ExitWindowsEx(int operationFlag, int operationReason);

        private static String LOCATIONPROMPT = "Required...";
        private static String ADDCONTACT = "Add a new contact...";
        private static String PARTSELECTPROMPT = "Select a part...";

        private static Color COLORRECEIVED = Color.LightGreen;
        private static Color COLORCLOSED = Color.SaddleBrown;
        private static Color COLOROVEN2INPROCESS = Color.SandyBrown;
        private static Color COLOROVEN1INPROCESS = Color.LightPink;
        private static Color COLORFINISHED = Color.Peru;
        private static Color COLORTFETIT = Color.CadetBlue;
        private static Color COLORTFEMOLY = Color.SkyBlue;
        private static Color COLORTFE = Color.CornflowerBlue;
        private static Color COLORCARBON = Color.Gray;
        private static Color COLOREGUN = Color.YellowGreen;
        private static Color COLOREGUNMOLY = Color.MediumAquamarine;
        private static Color COLOREDITBATCH = Color.Violet;
        private static Color COLORCLEANING = Color.Gold;

        private KnownColor[] queuedColorNames = { KnownColor.SkyBlue, KnownColor.LightBlue };

        private List<NumericUpDown> listOfQtyNumericUpDown;
        private List<ComboBox> listOfPartComboBox;
        private List<ComboBox> listOfContactsComboBox;
        private List<ComboBox> listOfLocationComboBox;

        private List<DataTable> listOfPartTable;
        private List<DataTable> listOfContactsTable;
        private List<DataTable> listOfLocationTable;
        private List<DataTable> dBTables;

        private List<JobRequest> listOfJobRequests;

        private DataGridViewCellStyle dgvStyle = new DataGridViewCellStyle();

        private DataTable jobSelectDataTable;
        private DataTable addToBatchDataTable;
        private DataTable createBatchTable;
        private DataTable batchContentTable;
        private DataTable locationTableMaster;
        private DataTable partTableMaster;
        private ErrorProvider ep;

        private TableLayoutPanel jobRequestTableLayout;
        private Panel addRowPanel;
        private Button addRowButton;

        private OutgasDB outgasDB = new OutgasDB();

        private int editBatchId = 0;
        private int customerId = 0;
        private int contactId = 0;
        private int operatorId = 0;
        private bool operatorPrivs = false;
        private bool suPrivs = false;
        private DataGridViewCellStyle shortDate = new DataGridViewCellStyle();

        private FixtureForm fixture = new FixtureForm();
        private ProgressBarForm progressForm;

        private string filterPart = "";
        private string filterUser = "";
        private string filterJob = "";
        private string filterBatch = "";
        private DateTime filterFromCompletedDate;
        private DateTime filterToCompletedDate;
        private DateTime filterFromStartedDate;
        private DateTime filterToStartedDate;
        private DateTime filterFromCreatedDate;
        private DateTime filterToCreatedDate;
        private DateTime filterFromReceivedDate;
        private DateTime filterToReceivedDate;

        private string newPartNumber = "";
        private string newPartDescription = "";
        private string newPartMaterial = "";
        private string newPartArea = "";
        private string newPartCycle = "";

        private string loggedInUser;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ep = new ErrorProvider();
            GetCustomerLogin();
            DGVSetStyle();
            FillDataTables();
        }


        #region Utilities

        private void DGVSetStyle()
        {
            dgvStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgvStyle.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dgvStyle.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dgvStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            dgvStyle.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            dgvStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dgvStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        }

        private void GetCustomerLogin()
        {
            DataTable customerTable = new DataTable();
            DataTable operatorTable = new DataTable();
            DataTable contactTable = new DataTable();
            contactTable = outgasDB.GetContactList();
            customerTable = outgasDB.GetCustomerList();
            operatorTable = outgasDB.GetOperatorList();
            while (Environment.UserName.Equals(null) || Environment.UserName.Equals("")) ;
            loggedInUser = Environment.UserName.ToLower().Trim();
            String email = loggedInUser + "@fei.com";
            bool custFound = false;
            bool contactFound = false;
            foreach (DataRow custRow in customerTable.Rows)
            {
                String userName = custRow.Field<String>("UserName").Trim();
                if (userName.ToLower().Equals(loggedInUser))
                {
                    customerId = custRow.Field<int>("CustomerId");
                    foreach (DataRow operRow in operatorTable.Rows)
                    {
                        String operName = operRow.Field<String>("UserName");
                        if (operName.ToLower().Equals(loggedInUser))
                        {
                            operatorPrivs = true;
                            operatorId = operRow.Field<int>("OperatorID");
                            if (operRow.Field<bool>("SuperUser"))
                                suPrivs = true;
                        }
                    }
                    custFound = true;
                }
            }
            if (!custFound)
            {
                int cId = 0;
                if (!loggedInUser.Equals(""))
                    cId = outgasDB.AddNewCustomer(loggedInUser);
                if (cId > 0)
                {
                    customerId = cId;
                    customerTable = outgasDB.GetCustomerList();
                }
                else
                {
                    MessageBox.Show("Customer not added");
                }
            }
            if (suPrivs)
            {
                this.Text = "Vacuum Furnace Scheduler - " + loggedInUser.ToUpper() + " logged in as a SuperUser";
            }
            else if (operatorPrivs)
            {
                this.Text = "Vacuum Furnace Scheduler - " + loggedInUser.ToUpper() + " logged in as an Operator";
                tabControl1.TabPages.Remove(tabSuperUser);
            }
            else
            {
                this.Text = "Vacuum Furnace Scheduler - " + loggedInUser.ToLower() + " logged in";
                tabControl1.TabPages.Remove(tabCreateBatch);
                tabControl1.TabPages.Remove(tabEditBatch);
                tabControl1.TabPages.Remove(tabStartBatch);
                tabControl1.TabPages.Remove(tabSuperUser);
            }

            foreach (DataRow conRow in contactTable.Rows)
            {

                String conName = conRow.Field<String>("Email");
                if (email.ToLower().Equals(conName.ToLower()))
                {
                    contactId = conRow.Field<int>("ContactId");
                    contactFound = true;
                    break;
                }
            }
            if (!contactFound)
            {
                contactId = outgasDB.AddIfNewContact(email);
            }
        }

        private Button EnableButton(Button btn)
        {
            btn.BackColor = Color.SteelBlue;
            btn.ForeColor = SystemColors.WindowText;
            btn.FlatStyle = FlatStyle.Standard;
            btn.Enabled = true;
            btn.Refresh();
            return btn;
        }
        private Button DisableButton(Button btn)
        {
            btn.BackColor = Color.LightSteelBlue;
            btn.ForeColor = SystemColors.GradientInactiveCaption;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Refresh();
            btn.Enabled = false;
            return btn;
        }

        private bool CheckBatchTable(DataTable bTable)
        {            
            String partPrev = bTable.Rows[0].Field<String>("Part #");
            String partNow = "";
            String areaPrev = bTable.Rows[0].Field<String>("Area");
            String areaNow = "";
            String matPrev = bTable.Rows[0].Field<String>("Material");
            String matNow = "";

            for (int c = 0; c < bTable.Rows.Count; c++)
            {
                partPrev = bTable.Rows[c].Field<String>("Part #");
                areaPrev = bTable.Rows[c].Field<String>("Area");
                matPrev = bTable.Rows[c].Field<String>("Material");
                for (int i = c+1; i < bTable.Rows.Count; i++)
                {
                    partNow = bTable.Rows[i].Field<String>("Part #").ToString();
                    areaNow = bTable.Rows[i].Field<String>("Area").ToString();
                    matNow = bTable.Rows[i].Field<String>("Material").ToString();

                    if (!(matNow == matPrev))
                        return false;
                    if (!(areaNow == "Carbon"))
                    {
                        if (!(areaNow == areaPrev))
                        {
                            if (!((partNow == "18603") || (partNow == "4035 272 54861") || (partPrev == "18603") || (partPrev == "4035 272 54861")))
                            {
                                return false;
                            }
                            else if (!(((areaNow == "TFE") || (areaNow == "EGUN")) && ((areaPrev == "TFE" || areaPrev == "EGUN"))))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void DGVGenericJob_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int jobId = 0;
            string part = "";
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                jobId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["Job #"].Value.ToString());
                part = dgv.Rows[e.RowIndex].Cells["Part #"].Value.ToString();
                PartInfoForm pForm = new PartInfoForm();
                pForm.mJobID = jobId;
                pForm.mPartNumber = part;
                pForm.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataTables();
        }

        private void SendContactEmail(int batch)
        {
            DataTable contactTable = new DataTable();
            contactTable = outgasDB.GetBatchContact(batch);
            foreach (DataRow row in contactTable.Rows)
            {
                string customer = row.Field<string>("UserName");
                string req = row.Field<DateTime>("DateReceived").ToShortDateString();
                int job = row.Field<int>("JobId");
                string conEmail = row.Field<string>("Email");
                string part = row.Field<string>("PartNumberDescription");
                int qty = row.Field<int>("Qty");
                //TODO Send Email for job owners in batchID.
                SmtpClient smtpClient = new SmtpClient("hiomail.w2k.feico.com");
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = false;
                MailMessage mail = new MailMessage();

                //Setting From , To, Subject, and Body
                mail.From = new MailAddress("VacuumFurnace@fei.com");
                mail.To.Add(new MailAddress(conEmail));
                mail.Subject = "Vacuum Furnace Job Finished";
                mail.Body = "Job #" + job + "   Requested By: " + customer + " on " + req +
                            "\nPart - " + part + "\nQty - " + qty +
                            "\n\nHas finished running in the vacuum furnace, and is ready to be picked up." +
                            "\n\nPlease Acknowledge receipt in the Vacuum Furnace Scheduler under the Pick-Up tab.\n" +
                            "Thank You";

                smtpClient.Send(mail);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Closing, would you like to logoff of the computer also?", "Logoff Completely?", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    ExitWindowsEx(0, 0);
                    break;
                default:
                    break;
            }
        }
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        #region bGWorkerFillTables

        private void FillDataTables()
        {
            progressForm = new ProgressBarForm();
            bGWorkerFillTables = new BackgroundWorker();
            bGWorkerFillTables.DoWork += new DoWorkEventHandler(bGWorkerFillTables_DoWork);
            bGWorkerFillTables.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerFillTables_RunWorkerCompleted);
            bGWorkerFillTables.RunWorkerAsync();
            progressForm.ShowDialog();
        }

        private void bGWorkerFillTables_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DataTable> dTables = new List<DataTable>();
            dTables.Add(outgasDB.GetAllJobBatches());                       //0 - BatchQuery            
            dTables.Add(outgasDB.GetJobQueueRequests());                    //1 - JobQuery            
            dTables.Add(outgasDB.GetPartList());                            //2 - Parts            
            dTables.Add(outgasDB.GetContactList());                         //3 - Contacts            
            dTables.Add(outgasDB.GetLocationList());                        //4 - Location            
            dTables.Add(outgasDB.GetStartBatches());                        //5 - StartBatch            
            dTables.Add(outgasDB.GetCompletedBatches());                    //6 - Completed Batches            
            dTables.Add(outgasDB.GetOperatorTFEJobRequests());              //7 - TFE Job Request
            dTables.Add(outgasDB.GetOperatorOtherJobRequests());            //8 - Other Job Requests
            dTables.Add(outgasDB.GetCreateAllJobRequests());                //9 - All Create Job Requests
            dTables.Add(outgasDB.GetInProcessBatchesOven1());               //10 - In Process Oven1
            dTables.Add(outgasDB.GetInProcessBatchesOven2());               //11 - In Process Oven2
            dTables.Add(outgasDB.GetFinishedJobs());                        //12 - Finished Jobs
            dTables.Add(outgasDB.GetCompletedJobs());                       //13 - Completed Jobs
            dTables.Add(outgasDB.GetCustomerList());                        //14 - Contact List
            dTables.Add(outgasDB.GetClosedFinishedJobBatches());            //15 - Closed Finished Jobs
            dTables.Add(outgasDB.GetEditableBatches());                     //16 - Editable Batches
            dTables.Add(outgasDB.GetMaterialList());                        //17 - Material Table
            e.Result = dTables;
        }

        private void bGWorkerFillTables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dBTables = (List<DataTable>)e.Result;
            QueueInitTab();
            JobRequestInitTab();
            if (suPrivs)
            {
                SuperUserInitTab();
            }
            if (operatorPrivs)
            {
                CreateBatchInitTab();
                StartFinishBatchInitTab();
                EditBatchInitTab();
            }
            HistoryInitTab();
            PickUpInitTab();
            progressForm.Close();
        }

        #endregion

        #region bGWorkerCreateBatch

        private void CreateBatch()
        {
            int job = 0;
            String jobs = "";
            if (CheckBatchTable(addToBatchDataTable))
            {
                foreach (DataRow row in addToBatchDataTable.Rows)
                {
                    job = row.Field<int>("JobId");
                    if (jobs != "")
                        jobs += ", ";
                    jobs += "#" + job.ToString();
                }
                DialogResult dialogResult = MessageBox.Show("A Batch wil be created with \nJob(s) " + jobs, "Create Batch?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    bGWorkerCreateBatch = new BackgroundWorker();
                    bGWorkerCreateBatch.DoWork += new DoWorkEventHandler(bGWorkerCreateBatch_DoWork);
                    bGWorkerCreateBatch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerCreateBatch_RunWorkerCompleted);
                    bGWorkerCreateBatch.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("All of the parts for each batch must be from the same area and same material or they must all be Carbon material. Please try again.", "Error Creating Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bGWorkerCreateBatch_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] message = new string[2];
            List<DataTable> dTables = new List<DataTable>();
            dTables.Add(outgasDB.GetAllJobBatches());
            String jobs = "";
            int job = 0;
            int batch = outgasDB.CreateBatch(operatorId);
            if (batch != 0)
            {
                foreach (DataRow row in addToBatchDataTable.Rows)
                {
                    job = row.Field<int>("JobId");
                    if (outgasDB.AddToBatch(batch, job))
                    {
                        if (jobs != "")
                            jobs += ", ";
                        jobs += "#" + job.ToString();
                    }
                }
                message[0] = "Job " + jobs + "\nCreated Batch #" + batch;
                message[1] = "Batch Created";
            }
            else
            {
                message[0] = "An error with the database occured.";
                message[1] = "Error Creating Batch";
            }
            e.Result = message;
        }

        private void bGWorkerCreateBatch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] mes = (string[])e.Result;
            MessageBox.Show(mes[0], mes[1]);
            FillDataTables();
        }

        #endregion

        #region Colorize

        private void ColorizeDGV(DataGridView dgv)
        {

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Area"].Value.ToString() == "Cleaning")
                {
                    row.DefaultCellStyle.BackColor = COLORCLEANING;
                    row.DefaultCellStyle.SelectionBackColor = COLORCLEANING;
                }
                else if (row.Cells["Area"].Value.ToString() == "TFE")
                {
                    if (row.Cells["Material"].Value.ToString() == "Molybdenum")
                    {
                        row.DefaultCellStyle.BackColor = COLORTFEMOLY;
                        row.DefaultCellStyle.SelectionBackColor = COLORTFEMOLY;

                    }
                    else if (row.Cells["Material"].Value.ToString() == "Titanium")
                    {
                        row.DefaultCellStyle.BackColor = COLORTFETIT;
                        row.DefaultCellStyle.SelectionBackColor = COLORTFETIT;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = COLORTFE;
                        row.DefaultCellStyle.SelectionBackColor = COLORTFE;
                    }
                }
                else if (row.Cells["Area"].Value.ToString() == "ION")
                {
                    row.DefaultCellStyle.BackColor = COLORCARBON;
                    row.DefaultCellStyle.SelectionBackColor = COLORCARBON;
                }

                else if (row.Cells["Area"].Value.ToString() == "Other")
                {
                    row.DefaultCellStyle.BackColor = COLORCLEANING;
                    row.DefaultCellStyle.SelectionBackColor = COLORCLEANING;
                }
                else
                {
                    if (row.Cells["Material"].Value.ToString() == "Molybdenum")
                    {
                        row.DefaultCellStyle.BackColor = COLOREGUNMOLY;
                        row.DefaultCellStyle.SelectionBackColor = COLOREGUNMOLY;
                    }
                    else if (row.Cells["Material"].Value.ToString() == "Carbon")
                    {
                        row.DefaultCellStyle.BackColor = COLORCARBON;
                        row.DefaultCellStyle.SelectionBackColor = COLORCARBON;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = COLOREGUN;
                        row.DefaultCellStyle.SelectionBackColor = COLOREGUN;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Queue

        private void QueueInitTab()
        {
            legendMolyTFE.BackColor = COLORTFEMOLY;
            legendMoly.BackColor = COLOREGUNMOLY;
            legendCarbon.BackColor = COLORCARBON;
            legendEGunTitanium.BackColor = COLOREGUN;
            legendTFETitanium.BackColor = COLORTFETIT;
            legendTFEOther.BackColor = COLORTFE;
            legendOven1InProcess.BackColor = COLOROVEN1INPROCESS;
            legendOven2InProcess.BackColor = COLOROVEN2INPROCESS;
            legendQueued1.BackColor = Color.FromKnownColor(queuedColorNames[0]);
            legendQueued2.BackColor = Color.FromKnownColor(queuedColorNames[1]);

            shortDate.Format = "M/d/yyyy";
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn jobBtnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "btnColumn";
            btnColumn.HeaderText = "Details";
            btnColumn.Text = "Info";
            btnColumn.UseColumnTextForButtonValue = true;
            jobBtnColumn = (DataGridViewButtonColumn)btnColumn.Clone();
            jobBtnColumn.Name = "jobBtnColumn";


            //Oven 1
            DataTable inTableOven1 = new DataTable();
            inTableOven1 = dBTables[10].Copy();
            InProcessTableFormat(ref inTableOven1, ref dGVInOven1);
            dGVInOven1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            if (dGVInOven1.RowCount > 0)
            {
                dGVInOven1.Rows[0].DefaultCellStyle.BackColor = COLOROVEN1INPROCESS;
                dGVInOven1.Rows[0].DefaultCellStyle.SelectionBackColor = COLOROVEN1INPROCESS;
            }

            //Oven 2
            DataTable inTableOven2 = new DataTable();
            inTableOven2 = dBTables[11].Copy();
            InProcessTableFormat(ref inTableOven2, ref dGVInOven2);
            dGVInOven2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVStartFinishBatchContents.ResumeLayout();
            if (dGVInOven2.RowCount > 0)
            {
                dGVInOven2.Rows[0].DefaultCellStyle.BackColor = COLOROVEN2INPROCESS;
                dGVInOven2.Rows[0].DefaultCellStyle.SelectionBackColor = COLOROVEN2INPROCESS;
            }
            //Top section Batches
            DataTable batchQueryDataTable = new DataTable();
            batchQueryDataTable = dBTables[0].Copy();
            batchQueryDataTable.Columns["BatchLineItem"].ColumnName = "Line #";
            batchQueryDataTable.Columns["BatchId"].ColumnName = "Batch #";
            batchQueryDataTable.Columns["JobId"].ColumnName = "Job #";
            batchQueryDataTable.Columns["UserName"].ColumnName = "Requestor";
            batchQueryDataTable.Columns["PartNumber"].ColumnName = "Part #";
            batchQueryDataTable.Columns["Description"].ColumnName = "Description";
            batchQueryDataTable.Columns["DateReceived"].ColumnName = "Received";
            batchQueryDataTable.Columns["DateStarted"].ColumnName = "Started";
            batchQueryDataTable.Columns["DateCreated"].ColumnName = "Created";
            batchQueryDataTable.Columns["Email"].ColumnName = "Notify When Finished";

            dGVQueueBatch.SuspendLayout();
            dGVQueueBatch.DataSource = batchQueryDataTable;
            dGVQueueBatch.DefaultCellStyle = dgvStyle;
            dGVQueueBatch.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (!(dGVQueueBatch.Columns[0].Name == "btnColumn"))
                dGVQueueBatch.Columns.Insert(0, btnColumn);
            dGVQueueBatch.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueueBatch.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            dGVQueueBatch.Columns["Started"].DefaultCellStyle.Format = shortDate.Format;
            dGVQueueBatch.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;

            String prevBatch = "";
            int nextColor = 0;
            Color qColor;
            for (int i = 0; i < dGVQueueBatch.Rows.Count; i++)
            {
                if (dGVQueueBatch.Rows[i].Cells["Status"].Value.ToString() == "Queued")
                {
                    if (prevBatch != dGVQueueBatch.Rows[i].Cells["Batch #"].Value.ToString())
                    {
                        nextColor++;
                        if (nextColor == queuedColorNames.Length)
                            nextColor = 0;
                    }
                    qColor = Color.FromKnownColor(queuedColorNames[nextColor]);
                    prevBatch = dGVQueueBatch.Rows[i].Cells["Batch #"].Value.ToString();
                    dGVQueueBatch.Rows[i].DefaultCellStyle.BackColor = qColor;
                    dGVQueueBatch.Rows[i].DefaultCellStyle.SelectionBackColor = qColor;
                }
                else if (dGVQueueBatch.Rows[i].Cells["Status"].Value.ToString() == "In Process")
                {
                    if (dGVQueueBatch.Rows[i].Cells["Oven"].Value.ToString() == "Oven 1(EGUN)")
                    {
                        dGVQueueBatch.Rows[i].DefaultCellStyle.BackColor = COLOROVEN1INPROCESS;
                        dGVQueueBatch.Rows[i].DefaultCellStyle.SelectionBackColor = COLOROVEN1INPROCESS;
                    }
                    else
                    {
                        dGVQueueBatch.Rows[i].DefaultCellStyle.BackColor = COLOROVEN2INPROCESS;
                        dGVQueueBatch.Rows[i].DefaultCellStyle.SelectionBackColor = COLOROVEN2INPROCESS;
                    }
                }
                else if (dGVQueueBatch.Rows[i].Cells["Status"].Value.ToString() == "Finished")
                {
                    dGVQueueBatch.Rows[i].DefaultCellStyle.BackColor = COLORFINISHED;
                    dGVQueueBatch.Rows[i].DefaultCellStyle.SelectionBackColor = COLORFINISHED;
                }

                else
                {
                    dGVQueueBatch.Rows[i].DefaultCellStyle.BackColor = COLORCLOSED;
                    dGVQueueBatch.Rows[i].DefaultCellStyle.SelectionBackColor = COLORCLOSED;
                }
            }
            dGVQueueBatch.ResumeLayout();

            //Bottom section Jobs with no Batch
            DataTable jobQueryDataTable = new DataTable();
            jobQueryDataTable = dBTables[1].Copy();
            jobQueryDataTable.Columns["UserName"].ColumnName = "Customer";
            jobQueryDataTable.Columns["PartNumber"].ColumnName = "Part #";
            jobQueryDataTable.Columns["Description"].ColumnName = "Description";
            jobQueryDataTable.Columns["DateReceived"].ColumnName = "Received";
            jobQueryDataTable.Columns["JobId"].ColumnName = "Job #";

            dGVQueueJob.SuspendLayout();
            dGVQueueJob.DataSource = jobQueryDataTable;
            dGVQueueJob.DefaultCellStyle = dgvStyle;
            dGVQueueJob.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (!(dGVQueueJob.Columns[0].Name == "jobBtnColumn"))
                dGVQueueJob.Columns.Insert(0, jobBtnColumn);
            dGVQueueJob.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVQueueJob.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            ColorizeDGV(dGVQueueJob);
            //disable column sorting / row reordering.
            dGVQueueBatch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVQueueJob.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVQueueJob.ResumeLayout();

        }

        private void InProcessTableFormat(ref DataTable inProcessTableOven, ref DataGridView dGVOven)
        {
            inProcessTableOven.Columns.Remove("Oven");
            inProcessTableOven.Columns["DateCreated"].ColumnName = "Created";
            inProcessTableOven.Columns["DateStarted"].ColumnName = "Started";
            inProcessTableOven.Columns["BatchID"].ColumnName = "Batch #";
            inProcessTableOven.Columns["ProcessTemp"].ColumnName = "Celsius";
            inProcessTableOven.Columns["CycleId"].ColumnName = "Cycle";
            inProcessTableOven.Columns.Add("Items", typeof(int));
            foreach (DataRow row in inProcessTableOven.Rows)
            {
                row["Items"] = outgasDB.GetAmountOfJobsInBatch((int)row["Batch #"]);
            }
            dGVOven.DataSource = inProcessTableOven;
            dGVOven.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            dGVOven.Columns["Started"].DefaultCellStyle.Format = shortDate.Format;
            dGVOven.Columns["Material"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVOven.DefaultCellStyle = dgvStyle;
            dGVOven.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (dGVOven.Rows.Count > 0)
                dGVOven.Rows[0].Selected = false;
        }

        #endregion

        #region Job Request

        private void JobRequestInitTab()
        {
            JobRequestInitLists();
            JobRequestCreateTableLayout();
            buttonJobRequestSubmit = DisableButton(buttonJobRequestSubmit);
            buttonJobRequestReset = DisableButton(buttonJobRequestReset);
        }

        private void JobRequestInitLists()
        {
            //Initialize Lists
            listOfPartComboBox = new List<ComboBox>();
            listOfQtyNumericUpDown = new List<NumericUpDown>();
            listOfContactsComboBox = new List<ComboBox>();
            listOfLocationComboBox = new List<ComboBox>();
            listOfPartTable = new List<DataTable>();
            listOfContactsTable = new List<DataTable>();
            listOfLocationTable = new List<DataTable>();
            listOfJobRequests = new List<JobRequest>();
            listOfJobRequests.Add(new JobRequest());

            //Add first partlist table to part List    
            partTableMaster = new DataTable();
            partTableMaster = dBTables[2].Copy();
            for (int ind = 0; ind < partTableMaster.Rows.Count; ind++)
            {
                DataRow row = partTableMaster.Rows[ind];
                if (row.Field<string>("PartNumber") == "Cleaning")
                    partTableMaster.Rows.Remove(row);
            }

            //Create first row for combobox dropdown prompt for selecting parts
            DataRow promptPartSelectRow = partTableMaster.NewRow();
            promptPartSelectRow["PartNumber"] = PARTSELECTPROMPT;
            promptPartSelectRow["PartNumberDescription"] = PARTSELECTPROMPT;
            partTableMaster.Rows.InsertAt(promptPartSelectRow, 0);
            partTableMaster.AcceptChanges();
            listOfPartTable.Add(partTableMaster.Copy());

            //Add first emaillist table to notify contact email List
            DataTable cTable = new DataTable();
            cTable = dBTables[3];
            DataRow copy = cTable.NewRow();
            for (int i = 0; i < cTable.Rows.Count; i++)
            {
                if (cTable.Rows[i].Field<int>("ContactId") == contactId)
                {
                    //move to first index
                    copy.ItemArray = cTable.Rows[i].ItemArray;
                    cTable.Rows.Remove(cTable.Rows[i]);
                    cTable.Rows.InsertAt(copy, 0);
                    cTable.AcceptChanges();
                }
            }
            //Create last row add for contact e-mail List
            DataRow promptAddContactRow = cTable.NewRow();
            promptAddContactRow["Email"] = ADDCONTACT;
            promptAddContactRow["ContactId"] = -1;
            cTable.Rows.Add(promptAddContactRow);
            listOfContactsTable.Add(cTable.Copy());

            //Add first location table to list
            locationTableMaster = new DataTable();
            locationTableMaster = dBTables[4].Copy();

            //Create first row for combobox dropdown prompt for location
            DataRow promptLocationSelectRow = locationTableMaster.NewRow();
            promptLocationSelectRow["Location"] = LOCATIONPROMPT;
            locationTableMaster.Rows.InsertAt(promptLocationSelectRow, 0);
            locationTableMaster.Rows[11].Delete();
            locationTableMaster.Rows[10].Delete();
            locationTableMaster.Rows[9].Delete();
            locationTableMaster.Rows[8].Delete();
            locationTableMaster.AcceptChanges();
            listOfLocationTable.Add(locationTableMaster.Copy());
        }

        private void JobRequestCreateTableLayout()
        {
            Font jobRequestHeaderFont = new Font("Arial Narrow", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            if (splitContainerJobRequest.Panel1.Contains(jobRequestTableLayout))
            {
                splitContainerJobRequest.Panel1.Controls.Remove(jobRequestTableLayout);
            }
            // 
            // Qty Header Label
            //             
            Label qtyHeaderLabel = new Label();
            qtyHeaderLabel.Dock = DockStyle.Fill;
            qtyHeaderLabel.Font = jobRequestHeaderFont;
            qtyHeaderLabel.TabIndex = 0;
            qtyHeaderLabel.Text = "Quantity";
            qtyHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PartNumber Header Label
            //
            Label partNumberHeaderLabel = new Label();
            partNumberHeaderLabel.Dock = DockStyle.Fill;
            partNumberHeaderLabel.Font = jobRequestHeaderFont;
            partNumberHeaderLabel.TabIndex = 0;
            partNumberHeaderLabel.Text = "Part Number (Description)";
            partNumberHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Contact Header Label
            //
            Label contactHeaderLabel = new Label();
            contactHeaderLabel.Dock = DockStyle.Fill;
            contactHeaderLabel.Font = jobRequestHeaderFont;
            contactHeaderLabel.TabIndex = 0;
            contactHeaderLabel.Text = "Notify When Complete";
            contactHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Location Header Label
            //
            Label locationHeaderLabel = new Label();
            locationHeaderLabel.Dock = DockStyle.Fill;
            locationHeaderLabel.Font = jobRequestHeaderFont;
            locationHeaderLabel.TabIndex = 0;
            locationHeaderLabel.Text = "Location";
            locationHeaderLabel.TextAlign = ContentAlignment.MiddleCenter;



            JobRequestTableRow newRow = new JobRequestTableRow();

            listOfQtyNumericUpDown.Add(newRow.qtyNumericUpDown);
            listOfPartComboBox.Add(newRow.partComboBox);
            listOfContactsComboBox.Add(newRow.contactComboBox);
            listOfLocationComboBox.Add(newRow.locationComboBox);
            JobRequestLinkListsToControls();

            //Add first job request to List          

            Panel qtyPanel = newRow.qtyPanel;
            Panel partPanel = newRow.partPanel;
            Panel contactPanel = newRow.contactPanel;
            Panel locationPanel = newRow.locationPanel;
            addRowPanel = newRow.addRowPanel;
            addRowButton = newRow.addRowButton;
            addRowButton.Click += new EventHandler(ButtonJobRequestAddRow_Click);



            // 
            // jobRequestTableLayout
            // 
            jobRequestTableLayout = new TableLayoutPanel();
            jobRequestTableLayout.SuspendLayout();
            jobRequestTableLayout.Name = "jobRequestTableLayout";
            jobRequestTableLayout.AutoSize = true;
            jobRequestTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            jobRequestTableLayout.BackColor = Color.SteelBlue;
            jobRequestTableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            jobRequestTableLayout.ColumnStyles.Add(new ColumnStyle());
            jobRequestTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            jobRequestTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            jobRequestTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            jobRequestTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            jobRequestTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            jobRequestTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            jobRequestTableLayout.Controls.Add(qtyHeaderLabel, 0, 0);
            jobRequestTableLayout.Controls.Add(partNumberHeaderLabel, 1, 0);
            jobRequestTableLayout.Controls.Add(contactHeaderLabel, 2, 0);
            jobRequestTableLayout.Controls.Add(locationHeaderLabel, 3, 0);
            jobRequestTableLayout.Controls.Add(qtyPanel, 0, 1);
            jobRequestTableLayout.Controls.Add(partPanel, 1, 1);
            jobRequestTableLayout.Controls.Add(contactPanel, 2, 1);
            jobRequestTableLayout.Controls.Add(locationPanel, 3, 1);
            jobRequestTableLayout.Controls.Add(addRowPanel, 0, 2);
            jobRequestTableLayout.Dock = DockStyle.Top;
            jobRequestTableLayout.Location = new Point(20, 20);
            jobRequestTableLayout.Size = new Size(1136, 177);

            //Add to jobRequest Tab top panel
            splitContainerJobRequest.Panel1.Controls.Add(jobRequestTableLayout);
            jobRequestTableLayout.ResumeLayout();
        }

        private void JobRequestLinkListsToControls()
        {
            for (int i = 0; i < listOfJobRequests.Count; i++)
            {
                listOfQtyNumericUpDown[i].TabIndex = i * 5 + 2;


                listOfPartComboBox[i].Enter -= new EventHandler(ComboBoxParts_Enter);
                listOfPartComboBox[i].DataSource = listOfPartTable[i];
                listOfPartComboBox[i].DisplayMember = "PartNumberDescription";
                listOfPartComboBox[i].ValueMember = "PartNumber";
                listOfPartComboBox[i].TabIndex = i * 5 + 1;
                listOfPartComboBox[i].Enter += new EventHandler(ComboBoxParts_Enter);

                listOfContactsComboBox[i].SelectedIndexChanged -= new EventHandler(ComboBoxContact_SelectedIndexChanged);
                listOfContactsComboBox[i].DataSource = listOfContactsTable[i];
                listOfContactsComboBox[i].DisplayMember = "Email";
                listOfContactsComboBox[i].ValueMember = "ContactId";
                listOfContactsComboBox[i].TabIndex = i * 5 + 4;
                listOfContactsComboBox[i].SelectedIndexChanged += new EventHandler(ComboBoxContact_SelectedIndexChanged);

                listOfLocationComboBox[i].Enter -= new EventHandler(ComboBoxJobRequestLocation_Enter);
                listOfLocationComboBox[i].DataSource = listOfLocationTable[i];
                listOfLocationComboBox[i].DisplayMember = "Location";
                listOfLocationComboBox[i].ValueMember = "Location";
                listOfLocationComboBox[i].TabIndex = i * 5 + 5;
                listOfLocationComboBox[i].Enter += new EventHandler(ComboBoxJobRequestLocation_Enter);
            }

        }

        private bool OkToSubmit(JobRequest temp)
        {
            if (temp.GetLocation() == LOCATIONPROMPT || temp.GetPartNumber() == PARTSELECTPROMPT || temp.GetQuantity() == 0 ||
                temp.GetCustomerId() == 0 || temp.GetContactId() == 0)
                return false;
            return true;
        }

        #region Event Handlers

        private void ComboBoxParts_Enter(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.SuspendLayout();
            DataTable dt = (DataTable)cb.DataSource;
            if (dt.Rows[0].Field<string>("PartNumber").ToString() == PARTSELECTPROMPT)
                dt.Rows.RemoveAt(0);
            cb.ResumeLayout();
            for (int i = 0; i < listOfJobRequests.Count; i++)
            {
                if (listOfLocationComboBox[i].SelectedValue.ToString() == LOCATIONPROMPT)
                {
                    addRowButton.Enabled = false;
                    buttonJobRequestSubmit = DisableButton(buttonJobRequestSubmit);
                }
                else
                {
                    addRowButton.Enabled = true;
                    buttonJobRequestSubmit = EnableButton(buttonJobRequestSubmit);
                }
            }
            buttonJobRequestReset = EnableButton(buttonJobRequestReset);
        }

        private void ComboBoxContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            ComboBox comboBox = (ComboBox)sender;
            for (int i = 0; i < listOfContactsComboBox.Count; i++)
            {
                if (listOfContactsComboBox[i].SelectedValue.ToString() == "-1")
                {
                    index = listOfContactsComboBox[i].SelectedIndex;
                    //Open new window to add new contact email.                    
                    ContactBoxValidation validation = delegate(string val)
                    {
                        if (val == "")
                            return "Email cannot be empty.";
                        if (!(new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch(val))
                            return "Email address is not valid.";
                        return "";
                    };

                    string eMail = "@FEI.com";
                    if (ContactInputBox.Show("Enter email address to notify when complete.", "Email address:", ref eMail, validation) == DialogResult.OK)
                    {
                        int conId = 0;
                        // Add new contact to DB
                        conId = outgasDB.IsContact(eMail);
                        if (conId == 0)
                        {
                            conId = outgasDB.AddIfNewContact(eMail);
                            // Add email to each contactTable 
                            foreach (DataTable contactTable in listOfContactsTable)
                            {
                                DataRow row = contactTable.NewRow();
                                row["Email"] = eMail;
                                row["ContactId"] = conId;
                                //TODO Add row to list of contactstable tables
                                contactTable.Rows.InsertAt(row, contactTable.Rows.Count - 1);
                            }
                            listOfContactsComboBox[i].SelectedIndex = index;
                            MessageBox.Show("Contact Email Saved");
                        }
                        else
                        {
                            DataRow[] rowArray = listOfContactsTable[i].Select("ContactId = '" + conId + "'");
                            if (rowArray.Length > 0)
                            {
                                listOfContactsComboBox[i].SelectedIndex = listOfContactsTable[i].Rows.IndexOf(rowArray[0]);
                            }
                        }
                    }
                }
            }
        }

        private void ComboBoxJobRequestLocation_Enter(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.SuspendLayout();
            DataTable dt = (DataTable)cb.DataSource;
            if (dt.Rows[0].Field<string>("Location").ToString() == LOCATIONPROMPT)
                dt.Rows.RemoveAt(0);
            cb.ResumeLayout();
            ep.Clear();
            for (int i = 0; i < listOfJobRequests.Count; i++)
            {
                if (listOfPartComboBox[i].SelectedValue.ToString() == PARTSELECTPROMPT)
                {
                    addRowButton.Enabled = false;
                    buttonJobRequestSubmit = DisableButton(buttonJobRequestSubmit);
                }
                else
                {
                    addRowButton.Enabled = true;
                    buttonJobRequestSubmit = EnableButton(buttonJobRequestSubmit);
                }
            }
            buttonJobRequestReset = EnableButton(buttonJobRequestReset);

        }

        private void ButtonJobRequestSubmit_Click(object sender, EventArgs e)
        {
            fixture.ShowDialog();
            int succeeded = 0;
            if (fixture.OKButtonClicked)
            {
                for (int i = 0; i < listOfJobRequests.Count; i++)
                {
                    JobRequest tempJobRequest = new JobRequest();

                    tempJobRequest.SetQuantity((int)listOfQtyNumericUpDown[i].Value);
                    tempJobRequest.SetPartNumber(listOfPartComboBox[i].SelectedValue.ToString());
                    tempJobRequest.SetCustomerId(customerId);
                    tempJobRequest.SetLocation(listOfLocationComboBox[i].SelectedValue.ToString());
                    tempJobRequest.SetContactId((int)listOfContactsComboBox[i].SelectedValue);

                    //Collect serial numbers
                    if (tempJobRequest.GetQuantity() > 0 && outgasDB.IsPartSerialized(tempJobRequest.GetPartNumber()))
                    {
                        SerialInputForm serialForm = new SerialInputForm();
                        serialForm.SetPart(tempJobRequest.GetPartNumber());
                        serialForm.SetQuantity(tempJobRequest.GetQuantity());
                        if (serialForm.ShowDialog() == DialogResult.OK)
                        {
                            List<string> serialList = new List<string>();
                            serialList = serialForm.GetSerialList();
                            foreach (string serial in serialList)
                            {
                                tempJobRequest.SetSerialNumber(serial);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Serial Number tracking cancelled. Job Request will still be placed.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //Track how many requests added successfully
                    if (OkToSubmit(tempJobRequest))
                    {
                        //add jobrequest to db
                        listOfJobRequests[i] = tempJobRequest;
                        if (outgasDB.AddJobRequest(listOfJobRequests[i]) > 0)
                            succeeded++;
                    }
                    else
                    {
                        MessageBox.Show("TempJobRequest not able to be added");
                    }
                }
                String mes = succeeded + " request(s) added.";
                MessageBox.Show(mes);
                FillDataTables();
            }
            else
            {
                MessageBox.Show("Please remove the part from the fixture or use an approved fixture before submitting your job request." +
                                " Your request has not been submitted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonJobRequestReset_Click(object sender, EventArgs e)
        {
            JobRequestInitTab();
        }

        private void ButtonJobRequestAddRow_Click(object sender, EventArgs e)
        {
            bool addRow = true;
            for (int i = 0; i < listOfJobRequests.Count; i++)
            {
                if (listOfLocationComboBox[i].SelectedValue.ToString().Equals(LOCATIONPROMPT))
                {
                    ep.SetError(listOfLocationComboBox[i], "Location is required.");
                    MessageBox.Show("Current row(s) must be complete before adding another row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    addRow = false;
                    break;
                }
            }
            if (addRow)
            {
                jobRequestTableLayout.SuspendLayout();
                //add new row to table and lists           
                listOfPartTable.Add(partTableMaster.Copy());
                listOfContactsTable.Add(listOfContactsTable[0].Copy());
                listOfLocationTable.Add(locationTableMaster.Copy());
                listOfJobRequests.Add(new JobRequest());
                JobRequestTableRow addedRow = new JobRequestTableRow();
                listOfQtyNumericUpDown.Add(addedRow.qtyNumericUpDown);
                listOfPartComboBox.Add(addedRow.partComboBox);
                listOfContactsComboBox.Add(addedRow.contactComboBox);
                listOfLocationComboBox.Add(addedRow.locationComboBox);
                JobRequestLinkListsToControls();


                //Add a new row to tableLayout, put panels in each cell in new row.

                jobRequestTableLayout.Controls.Remove(addRowPanel);
                jobRequestTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
                jobRequestTableLayout.Controls.Add(addedRow.qtyPanel, 0, listOfJobRequests.Count);
                jobRequestTableLayout.Controls.Add(addedRow.partPanel, 1, listOfJobRequests.Count);
                jobRequestTableLayout.Controls.Add(addedRow.contactPanel, 2, listOfJobRequests.Count);
                jobRequestTableLayout.Controls.Add(addedRow.locationPanel, 3, listOfJobRequests.Count);
                if (listOfJobRequests.Count < 10)
                {
                    jobRequestTableLayout.Controls.Add(addRowPanel, 0, listOfJobRequests.Count + 1);
                    addRowButton.Enabled = false;
                }
                jobRequestTableLayout.ResumeLayout();
            }
        }

        #endregion

        #endregion

        #region Pick Up

        private void PickUpInitTab()
        {
            shortDate.Format = "M/d/yyyy";
            legMolyTFE.BackColor = COLORTFEMOLY;
            legMoly.BackColor = COLOREGUNMOLY;
            legCarbon.BackColor = COLORCARBON;
            legEGunTitanium.BackColor = COLOREGUN;
            legTFETitanium.BackColor = COLORTFETIT;
            legOtherTFE.BackColor = COLORTFE;


            DataTable pickUpTable = new DataTable();
            pickUpTable = dBTables[12].Copy();
            pickUpTable.Columns["DateReceived"].ColumnName = "Received";
            pickUpTable.Columns["DateCreated"].ColumnName = "Created";
            pickUpTable.Columns["DateCompleted"].ColumnName = "Completed";
            pickUpTable.Columns["BatchLineItem"].ColumnName = "Line #";
            pickUpTable.Columns["BatchId"].ColumnName = "Batch #";
            pickUpTable.Columns["UserName"].ColumnName = "Customer";
            pickUpTable.Columns["PartNumber"].ColumnName = "Part #";
            pickUpTable.Columns["JobId"].ColumnName = "Job #";
            pickUpTable.Columns.Remove("Batch #");
            pickUpTable.Columns.Remove("Line #");



            DataGridViewButtonColumn btnDetailsColumn = new DataGridViewButtonColumn();
            btnDetailsColumn.Name = "btnDetailsColumn";
            btnDetailsColumn.HeaderText = "Details";
            btnDetailsColumn.Text = "Info";
            btnDetailsColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnPickUpColumn = new DataGridViewButtonColumn();
            btnPickUpColumn.Name = "Ack";
            btnPickUpColumn.HeaderText = "Verify Receipt";
            btnPickUpColumn.Text = "Acknowledge";
            btnPickUpColumn.UseColumnTextForButtonValue = true;

            dGVPickUp.SuspendLayout();
            dGVPickUp.DataSource = pickUpTable;
            dGVPickUp.DefaultCellStyle = dgvStyle;
            dGVPickUp.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (!(dGVPickUp.Columns[0].Name == "btnDetailsColumn"))
            {
                dGVPickUp.Columns.Insert(0, btnDetailsColumn);
                dGVPickUp.Columns.Add(btnPickUpColumn);
            }
            dGVPickUp.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVPickUp.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            dGVPickUp.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            dGVPickUp.Columns["Completed"].DefaultCellStyle.Format = shortDate.Format;
            dGVPickUp.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            if (dGVPickUp.Rows.Count > 0)
                dGVPickUp.Rows[0].Selected = false;
            ColorizeDGV(dGVPickUp);
            dGVPickUp.ResumeLayout();

        }

        #region Event Handlers
        private void DGVPickUp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int jobId = 0;
            string part = "";
            jobId = Int32.Parse(dgv.Rows[e.RowIndex].Cells["Job #"].Value.ToString());
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                part = dgv.Rows[e.RowIndex].Cells["Part #"].Value.ToString();
                PartInfoForm pForm = new PartInfoForm();
                pForm.mJobID = jobId;
                pForm.mPartNumber = part;
                pForm.ShowDialog();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (outgasDB.UpdateJobStatusClosed(jobId))
                {
                    MessageBox.Show("Thank you for logging your part as picked up. \n Don't forget to logout.", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataTables();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
        }

        #endregion

        #endregion

        #region History

        private void HistoryInitTab()
        {
            shortDate.Format = "M/d/yyyy";

            lgnMolyTFE.BackColor = COLORTFEMOLY;
            lgnMoly.BackColor = COLOREGUNMOLY;
            lgnCarbon.BackColor = COLORCARBON;
            lgnEGunTitanium.BackColor = COLOREGUN;
            lgnTFETitanium.BackColor = COLORTFETIT;
            lgnCleaning.BackColor = COLORCLEANING;
            lgnTFEOther.BackColor = COLORTFE;

            DataTable partsTable = new DataTable();
            partsTable = dBTables[2].Copy();
            DataRow allPartsRow = partsTable.NewRow();
            allPartsRow["PartNumber"] = "All";
            allPartsRow["PartNumberDescription"] = "All";
            partsTable.Rows.InsertAt(allPartsRow, 0);
            comboBoxPartHistoryFilter.DataSource = partsTable;
            comboBoxPartHistoryFilter.DisplayMember = "PartNumberDescription";
            comboBoxPartHistoryFilter.ValueMember = "PartNumber";
            comboBoxPartHistoryFilter.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);

            DataTable batchTable = new DataTable();
            batchTable = dBTables[6].Copy();
            List<string> batchList = new List<string>();
            foreach (DataRow dRow in batchTable.Rows)
                batchList.Add(dRow.Field<int>("BatchID").ToString());
            batchList.Sort();
            batchList.Insert(0, "All");
            comboBoxBatchHistoryFilter.DataSource = batchList;

            DataTable jobTable = new DataTable();
            jobTable = dBTables[13].Copy();
            List<string> jobIDList = new List<string>();
            foreach (DataRow row in jobTable.Rows)
            {
                jobIDList.Add(row["JobId"].ToString());
            }
            jobIDList.Sort();
            jobIDList.Insert(0, "All");
            comboBoxJobHistoryFilter.DataSource = jobIDList;

            DataTable usernameTable = new DataTable();
            usernameTable = dBTables[14].Copy();
            DataRow allUserRow = usernameTable.NewRow();
            allUserRow["UserName"] = "All";
            usernameTable.Rows.InsertAt(allUserRow, 0);
            comboBoxUserHistoryFilter.DataSource = usernameTable;
            comboBoxUserHistoryFilter.DisplayMember = "UserName";
            comboBoxUserHistoryFilter.ValueMember = "UserName";

            dateTimePickerFromCompletedFilter.MaxDate = DateTime.Today;
            dateTimePickerFromCompletedFilter.Value = DateTime.Today.AddDays(-30);
            dateTimePickerToCompletedFilter.MaxDate = DateTime.Today;
            dateTimePickerToCompletedFilter.Value = DateTime.Today;
            dateTimePickerFromStartedFilter.MaxDate = DateTime.Today;
            dateTimePickerFromStartedFilter.Value = DateTime.Today.AddDays(-30);
            dateTimePickerToStartedFilter.MaxDate = DateTime.Today;
            dateTimePickerToStartedFilter.Value = DateTime.Today;
            dateTimePickerFromCreatedFilter.MaxDate = DateTime.Today;
            dateTimePickerFromCreatedFilter.Value = DateTime.Today.AddDays(-30);
            dateTimePickerToCreatedFilter.MaxDate = DateTime.Today;
            dateTimePickerToCreatedFilter.Value = DateTime.Today;
            dateTimePickerFromReceivedFilter.MaxDate = DateTime.Today;
            dateTimePickerFromReceivedFilter.Value = DateTime.Today.AddDays(-30);
            dateTimePickerToReceivedFilter.MaxDate = DateTime.Today;
            dateTimePickerToReceivedFilter.Value = DateTime.Today;


            RefreshHistoryFilter();

        }

        private void RefreshHistoryFilter()
        {
            DataTable historyJobTable = new DataTable();
            dateTimePickerFromCompletedFilter.MaxDate = dateTimePickerToCompletedFilter.Value.AddDays(-1);
            dateTimePickerToCompletedFilter.MinDate = dateTimePickerFromCompletedFilter.Value.AddDays(1);
            dateTimePickerFromStartedFilter.MaxDate = dateTimePickerToStartedFilter.Value.AddDays(-1);
            dateTimePickerToStartedFilter.MinDate = dateTimePickerFromStartedFilter.Value.AddDays(1);
            dateTimePickerFromCreatedFilter.MaxDate = dateTimePickerToCreatedFilter.Value.AddDays(-1);
            dateTimePickerToCreatedFilter.MinDate = dateTimePickerFromCreatedFilter.Value.AddDays(1);
            dateTimePickerFromReceivedFilter.MaxDate = dateTimePickerToReceivedFilter.Value.AddDays(-1);
            dateTimePickerToReceivedFilter.MinDate = dateTimePickerFromReceivedFilter.Value.AddDays(1);


            historyJobTable = dBTables[15].Copy();
            historyJobTable.Columns["DateStarted"].ColumnName = "Started";
            historyJobTable.Columns["DateCreated"].ColumnName = "Created";
            historyJobTable.Columns["BatchLineItem"].ColumnName = "Line #";
            historyJobTable.Columns["BatchId"].ColumnName = "Batch #";
            historyJobTable.Columns["UserName"].ColumnName = "Customer";
            historyJobTable.Columns["PartNumber"].ColumnName = "Part #";
            historyJobTable.Columns["DateReceived"].ColumnName = "Received";
            historyJobTable.Columns["DateCompleted"].ColumnName = "Completed";
            historyJobTable.Columns["JobId"].ColumnName = "Job #";

            //Batch Filter
            int rowCount = historyJobTable.Rows.Count;
            if (!(filterBatch == "" || filterBatch == "All"))
            {
                for (int row = 0; row < rowCount; row++)
                {
                    //remove all not equal to filter
                    if (!(historyJobTable.Rows[row].Field<int>("Batch #").ToString().Equals(filterBatch)))
                    {
                        historyJobTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
            }

            //Part Filter
            rowCount = historyJobTable.Rows.Count;
            if (!(filterPart == "" || filterPart == "All"))
            {
                for (int row = 0; row < rowCount; row++)
                {
                    //remove all not equal to filter
                    if (!(historyJobTable.Rows[row].Field<string>("Part #").ToString().Equals(filterPart)))
                    {
                        historyJobTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
            }

            //Customer Filter
            rowCount = historyJobTable.Rows.Count;
            if (!(filterUser == "" || filterUser == "All"))
            {
                for (int row = 0; row < rowCount; row++)
                {
                    //remove all not equal to filter
                    if (!(historyJobTable.Rows[row].Field<string>("Customer").ToString().Equals(filterUser)))
                    {
                        historyJobTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
            }

            //Job Filter
            rowCount = historyJobTable.Rows.Count;
            if (!(filterJob == "" || filterJob == "All"))
            {
                for (int row = 0; row < rowCount; row++)
                {
                    //remove all not equal to filter
                    if (!(historyJobTable.Rows[row].Field<int>("Job #").ToString().Equals(filterJob)))
                    {
                        historyJobTable.Rows.RemoveAt(row);
                        row--;
                        rowCount--;
                    }
                }
            }

            //From Completed Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Completed") < filterFromCompletedDate)
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }

            //To Completed Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Completed") > filterToCompletedDate.AddDays(1))
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }
            //From Started Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Started") < filterFromStartedDate)
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }

            //To Started Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Started") > filterToStartedDate.AddDays(1))
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }
            //From Created Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Created") < filterFromCreatedDate)
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }

            //To Created Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Created") > filterToCreatedDate.AddDays(1))
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }
            //From Received Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Received") < filterFromReceivedDate)
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }

            //To Received Filter
            rowCount = historyJobTable.Rows.Count;
            for (int row = 0; row < rowCount; row++)
            {
                //remove all not equal to filter
                if (historyJobTable.Rows[row].Field<DateTime>("Received") > filterToReceivedDate.AddDays(1))
                {
                    historyJobTable.Rows.RemoveAt(row);
                    row--;
                    rowCount--;
                }
            }

            DataGridViewButtonColumn jobBtnColumn = new DataGridViewButtonColumn();
            jobBtnColumn.Name = "btnColumn";
            jobBtnColumn.HeaderText = "Details";
            jobBtnColumn.Text = "Info";
            jobBtnColumn.UseColumnTextForButtonValue = true;
            dGVHistoryJobs.SuspendLayout();
            dGVHistoryJobs.DataSource = historyJobTable;
            dGVHistoryJobs.DefaultCellStyle = dgvStyle;
            dGVHistoryJobs.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (!(dGVHistoryJobs.Columns[0].Name == "btnColumn"))
                dGVHistoryJobs.Columns.Insert(0, jobBtnColumn);
            dGVHistoryJobs.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVHistoryJobs.Columns["Started"].DefaultCellStyle.Format = shortDate.Format;
            dGVHistoryJobs.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            dGVHistoryJobs.Columns["Completed"].DefaultCellStyle.Format = shortDate.Format;
            dGVHistoryJobs.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            dGVHistoryJobs.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            if (dGVHistoryJobs.Rows.Count > 0)
                dGVHistoryJobs.Rows[0].Selected = false;
            ColorizeDGV(dGVHistoryJobs);
            dGVHistoryJobs.ResumeLayout();
        }

        #region Event Handlers

        void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void comboBoxUserHistoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterUser = comboBoxUserHistoryFilter.SelectedValue.ToString();
            RefreshHistoryFilter();
        }

        private void comboBoxBatchHistoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBatch = comboBoxBatchHistoryFilter.SelectedValue.ToString();
            RefreshHistoryFilter();
        }

        private void comboBoxJobHistoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterJob = comboBoxJobHistoryFilter.SelectedValue.ToString();
            RefreshHistoryFilter();
        }

        private void comboBoxPartHistoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterPart = comboBoxPartHistoryFilter.SelectedValue.ToString();
            RefreshHistoryFilter();
        }

        private void dateTimePickerFromCompletedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterFromCompletedDate = dateTimePickerFromCompletedFilter.Value;
            RefreshHistoryFilter();
        }

        private void dateTimePickerToCompletedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterToCompletedDate = dateTimePickerToCompletedFilter.Value;
            RefreshHistoryFilter();
        }

        private void dateTimePickerFromStartedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterFromStartedDate = dateTimePickerFromStartedFilter.Value;
            RefreshHistoryFilter();
        }

        private void dateTimePickerToStartedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterToStartedDate = dateTimePickerToStartedFilter.Value;
            RefreshHistoryFilter();
        }
        private void dateTimePickerFromCreatedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterFromCreatedDate = dateTimePickerFromCreatedFilter.Value;
            RefreshHistoryFilter();
        }

        private void dateTimePickerToCreatedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterToCreatedDate = dateTimePickerToCreatedFilter.Value;
            RefreshHistoryFilter();
        }
        private void dateTimePickerFromReceivedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterFromReceivedDate = dateTimePickerFromReceivedFilter.Value;
            RefreshHistoryFilter();
        }

        private void dateTimePickerToReceivedFilter_ValueChanged(object sender, EventArgs e)
        {
            filterToReceivedDate = dateTimePickerToReceivedFilter.Value;
            RefreshHistoryFilter();
        }

        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            HistoryInitTab();
        }



        #endregion

        #endregion

        #region Create Batch

        private void CreateBatchInitTab()
        {
            DisableButton(buttonCreateBatch);
            JobSelectInitDataTable();
            DGVJobSelectCreateInit();
            DGVBatchCreateInit();
            ColorizeDGV(dGVCreateJob);

            lgMolyTFE.BackColor = COLORTFEMOLY;
            lgMolyEGUN.BackColor = COLOREGUNMOLY;
            lgCarbon.BackColor = COLORCARBON;
            lgTitEGUN.BackColor = COLOREGUN;
            lgTitTFE.BackColor = COLORTFETIT;
            lgOtherTFE.BackColor = COLORTFE;
        }

        private void JobSelectInitDataTable()
        {
            jobSelectDataTable = new DataTable();
            if (tfeRadioButton.Checked == true)
            {
                jobSelectDataTable = dBTables[7];
            }
            else if (otherRadioButton.Checked == true)
            {
                jobSelectDataTable = dBTables[8];
            }
            else
            {
                jobSelectDataTable = dBTables[9];
            }

            jobSelectDataTable.Columns["UserName"].ColumnName = "Customer";
            jobSelectDataTable.Columns["PartNumber"].ColumnName = "Part #";
        }

        private void DGVJobSelectCreateInit()
        {
            dGVCreateJob.SuspendLayout();
            dGVCreateJob.DataSource = jobSelectDataTable;
            dGVCreateJob.DefaultCellStyle = dgvStyle;
            dGVCreateJob.ColumnHeadersDefaultCellStyle = dgvStyle;
            dGVCreateJob.Columns["Part #"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVCreateJob.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (!(dGVCreateJob.Columns[0].Name == "Select"))
            {
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "Select";
                checkColumn.HeaderText = "Select";
                checkColumn.TrueValue = true;
                checkColumn.FalseValue = false;
                dGVCreateJob.Columns.Insert(0, checkColumn);
            }
            dGVCreateJob.Columns["JobId"].Visible = false;
            dGVCreateJob.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVCreateJob.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(DGVCreateBatchJobSelect_CellMouseUp);
            dGVCreateJob.ResumeLayout();
        }

        private void DGVBatchCreateInit()
        {
            addToBatchDataTable = new DataTable();
            addToBatchDataTable = jobSelectDataTable.Clone();
            dGVCreateBatch.SuspendLayout();
            dGVCreateBatch.DataSource = addToBatchDataTable;
            dGVCreateBatch.DefaultCellStyle = dgvStyle;
            dGVCreateBatch.ColumnHeadersDefaultCellStyle = dgvStyle;
            dGVCreateBatch.Columns["Part #"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVCreateBatch.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVCreateBatch.Columns["JobId"].Visible = false;
            dGVCreateBatch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVCreateBatch.ResumeLayout();
        }

        #region Event Handlers

        private void DGVCreateBatchJobSelect_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButton(buttonCreateBatch);
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                dGVCreateJob.EndEdit();
                dGVCreateBatch.SuspendLayout();
                addToBatchDataTable = new DataTable();
                addToBatchDataTable = jobSelectDataTable.Clone();
                for (int d = 0; d < dGVCreateJob.Rows.Count; d++)
                {
                    if (Convert.ToBoolean(dGVCreateJob.Rows[d].Cells[0].Value))
                    {
                        addToBatchDataTable.ImportRow(jobSelectDataTable.Rows[d]);
                    }
                }

                dGVCreateBatch.DataSource = addToBatchDataTable;
                dGVCreateBatch.Columns["Part #"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dGVCreateBatch.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dGVCreateBatch.Columns["JobId"].Visible = false;
                dGVCreateBatch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                ColorizeDGV(dGVCreateBatch);
                dGVCreateBatch.ResumeLayout();
            }
            if (dGVCreateBatch.RowCount > 0)
                EnableButton(buttonCreateBatch);
            else
                DisableButton(buttonCreateBatch);
        }

        private void ButtonCreateBatch_Click(object sender, EventArgs e)
        {
            CreateBatch();
        }

        private void RadioButtonCreate_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            //only react to checked buttons
            if (rb.Checked)
                FillDataTables();
        }

        #endregion

        #endregion

        #region Edit Batch

        private void EditBatchInitTab()
        {

            EditBatchRefresh();
            dGVEditBatchContent.Columns.Clear();
            dGVEditBatchContent.DataSource = null;
            lgdTFEMoly.BackColor = COLORTFEMOLY;
            lgdEGUNMoly.BackColor = COLOREGUNMOLY;
            lgdCarbon.BackColor = COLORCARBON;
            lgdEGUNTit.BackColor = COLOREGUN;
            lgdTFETit.BackColor = COLORTFETIT;
            lgdTFEOther.BackColor = COLORTFE;
            lgnApart.BackColor = COLOREDITBATCH;
            lgnComb.BackColor = COLORRECEIVED;

        }

        private void EditBatchRefresh()
        {
            shortDate.Format = "M/d/yyyy";

            DataGridViewButtonColumn editBtnColumn = new DataGridViewButtonColumn();
            editBtnColumn.Name = "editBtnColumn";
            editBtnColumn.HeaderText = "";
            editBtnColumn.Text = "Edit";
            editBtnColumn.UseColumnTextForButtonValue = true;
            DataTable editBatchTable = new DataTable();
            editBatchTable = outgasDB.GetEditableBatches();
            EditBatchTableColumnNames(editBatchTable);
            dGVEditBatch.DataSource = editBatchTable;
            dGVEditBatch.SuspendLayout();
            dGVEditBatch.DefaultCellStyle = dgvStyle;
            dGVEditBatch.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (!(dGVEditBatch.Columns[0].Name == "editBtnColumn"))
                dGVEditBatch.Columns.Insert(0, editBtnColumn);
            dGVEditBatch.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVEditBatch.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            dGVEditBatch.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            dGVEditBatch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            if (dGVEditBatch.Rows.Count > 0)
                dGVEditBatch.Rows[0].Selected = false;
            foreach (DataGridViewRow row in dGVEditBatch.Rows)
            {
                row.DefaultCellStyle.SelectionBackColor = COLOREDITBATCH;
                if (row.Cells["Area"].Value.ToString() == "TFE")
                {
                    if (row.Cells["Material"].Value.ToString() == "Molybdenum")
                    {
                        row.DefaultCellStyle.BackColor = COLORTFEMOLY;
                    }
                    else if (row.Cells["Material"].Value.ToString() == "Titanium")
                    {
                        row.DefaultCellStyle.BackColor = COLORTFETIT;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = COLORTFE;
                    }
                }
                else if (row.Cells["Area"].Value.ToString() == "ION")
                {
                    row.DefaultCellStyle.BackColor = COLORCARBON;
                }

                else if (row.Cells["Area"].Value.ToString() == "Other")
                {
                    row.DefaultCellStyle.BackColor = COLORCLEANING;
                }
                else
                {
                    if (row.Cells["Material"].Value.ToString() == "Molybdenum")
                    {
                        row.DefaultCellStyle.BackColor = COLOREGUNMOLY;
                    }
                    else if (row.Cells["Material"].Value.ToString() == "Carbon")
                    {
                        row.DefaultCellStyle.BackColor = COLORCARBON;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = COLOREGUN;
                    }
                }
            }
            dGVEditBatch.ResumeLayout();
        }

        private void EditBatchContentInit()
        {
            bool emptyBatch = true;
            shortDate.Format = "M/d/yyyy";
            batchContentTable = new DataTable();
            DataTable addToBatchJobsTable = new DataTable();
            batchContentTable = outgasDB.GetBatch(editBatchId);
            createBatchTable = batchContentTable.Copy();
            if (batchContentTable.Rows.Count > 0)
                addToBatchJobsTable = outgasDB.GetCombineableJobRequests(batchContentTable.Rows[0].Field<string>("Material"), batchContentTable.Rows[0].Field<string>("Area"));
            batchContentTable.Merge(addToBatchJobsTable);
            EditBatchTableColumnNames(batchContentTable);


            DataGridViewTextBoxColumn editColumn = new DataGridViewTextBoxColumn();
            editColumn.HeaderText = "Edit";
            dGVEditBatchContent.Columns.Clear();
            dGVEditBatchContent.SuspendLayout();
            dGVEditBatchContent.DataSource = batchContentTable;
            dGVEditBatchContent.DefaultCellStyle = dgvStyle;
            dGVEditBatchContent.ColumnHeadersDefaultCellStyle = dgvStyle;
            dGVEditBatchContent.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVEditBatchContent.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            dGVEditBatchContent.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            if (dGVEditBatchContent.Columns[0] != editColumn)
                dGVEditBatchContent.Columns.Insert(0, editColumn);
            foreach (DataGridViewRow row in dGVEditBatchContent.Rows)
            {
                if ((String)row.Cells["Batch #"].Value.ToString() != "")
                {
                    DataGridViewButtonCell removeCell = new DataGridViewButtonCell();
                    row.Cells[0] = removeCell;
                    removeCell.UseColumnTextForButtonValue = false;
                    removeCell.Value = "Remove";
                    row.DefaultCellStyle.BackColor = COLOREDITBATCH;
                    row.DefaultCellStyle.SelectionBackColor = COLOREDITBATCH;
                    emptyBatch = false;
                }
                else
                {
                    DataGridViewButtonCell addCell = new DataGridViewButtonCell();
                    row.Cells[0] = addCell;
                    addCell.UseColumnTextForButtonValue = false;
                    addCell.Value = "Add";
                    row.DefaultCellStyle.BackColor = COLORRECEIVED;
                    row.DefaultCellStyle.SelectionBackColor = COLORRECEIVED;
                }
            }
            dGVEditBatchContent.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            if (dGVEditBatchContent.Rows.Count > 0)
                dGVEditBatchContent.Rows[0].Selected = false;

            dGVEditBatchContent.ResumeLayout();
            if (emptyBatch)
                EditBatchInitTab();
        }

        private static void EditBatchTableColumnNames(DataTable batchEditTable)
        {
            batchEditTable.Columns["BatchLineItem"].ColumnName = "Line #";
            batchEditTable.Columns["BatchId"].ColumnName = "Batch #";
            batchEditTable.Columns["UserName"].ColumnName = "Customer";
            batchEditTable.Columns["PartNumber"].ColumnName = "Part";
            batchEditTable.Columns["DateReceived"].ColumnName = "Received";
            batchEditTable.Columns["DateCreated"].ColumnName = "Created";
            batchEditTable.Columns["JobId"].ColumnName = "Job #";
        }

        #region Event Handlers

        private void dGVEditBatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewRow row = dGVEditBatch.Rows[e.RowIndex];
                editBatchId = (int)row.Cells["Batch #"].Value;
                EditBatchContentInit();
            }
        }
        private void dGVEditBatchContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var batchContentGrid = (DataGridView)sender;
            int jobId = 0;
            // if add button add to table
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //Add to current batch
                if (batchContentGrid.Rows[e.RowIndex].Cells["Batch #"].Value.ToString() == "")
                {

                    jobId = (int)batchContentGrid.Rows[e.RowIndex].Cells["Job #"].Value;
                    createBatchTable.Merge(outgasDB.GetJob(jobId));

                    if (CheckBatchTable(createBatchTable))
                    {
                        outgasDB.AddToBatch(editBatchId, jobId);
                    }
                    else
                    {
                        MessageBox.Show("All of the jobs for each batch must be from the same area and same material or they must all be Carbon material. Please try again.", "Illegal Batch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Remove from batch
                else
                {
                    jobId = (int)batchContentGrid.Rows[e.RowIndex].Cells["Job #"].Value;
                    outgasDB.ClearBatch(jobId);
                }
                outgasDB.UpdateLineItemNumbers(editBatchId);
                EditBatchRefresh();
                EditBatchContentInit();
            }
        }

        #endregion

        #endregion

        #region Start / Finish Batch

        private void StartFinishBatchInitTab()
        {
            DataTable emptyTable = new DataTable();

            dGVStartBatch.SuspendLayout();
            dGVBatchInOven1.SuspendLayout();
            dGVBatchInOven2.SuspendLayout();
            dGVStartFinishBatchContents.SuspendLayout();
            if (dGVStartFinishBatchContents.ColumnCount > 0)
                dGVStartFinishBatchContents.Columns.Clear();
            buttonStartBatch.Enabled = false;
            radioButtonOven1.Enabled = false;
            radioButtonOven2.Enabled = false;
            buttonBatchOven1Finished.Enabled = false;
            buttonBatchOven2Finished.Enabled = false;
            shortDate.Format = "M/d/yyyy";
            DataTable startBatchTable = new DataTable();
            startBatchTable = dBTables[5];
            if (startBatchTable.Rows.Count > 1)
            {
                int prevJobId = startBatchTable.Rows[0].Field<int>("BatchID");
                for (int index = 1; index < startBatchTable.Rows.Count; index++)
                {
                    if (startBatchTable.Rows[index].Field<int>("BatchID") == prevJobId)
                    {
                        startBatchTable.Rows.RemoveAt(index);
                        index--;
                    }
                    else
                    {
                        prevJobId = startBatchTable.Rows[index].Field<int>("BatchID");
                    }
                }
            }

            DataGridViewButtonColumn viewBtnColumn = new DataGridViewButtonColumn();
            viewBtnColumn.Name = "Details";
            viewBtnColumn.Text = "View";
            viewBtnColumn.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn view2BtnColumn = (DataGridViewButtonColumn)viewBtnColumn.Clone();
            DataGridViewButtonColumn view3BtnColumn = (DataGridViewButtonColumn)viewBtnColumn.Clone();
            startBatchTable.Columns["DateCreated"].ColumnName = "Created";
            startBatchTable.Columns["CycleId"].ColumnName = "Cycle";
            startBatchTable.Columns["ProcessTemp"].ColumnName = "Celsius";
            startBatchTable.Columns["BatchID"].ColumnName = "Batch #";
            startBatchTable.Columns.Add("Items", typeof(int));
            foreach (DataRow row in startBatchTable.Rows)
            {
                row["Items"] = outgasDB.GetAmountOfJobsInBatch((int)row["Batch #"]);
            }
            dGVStartBatch.DataSource = startBatchTable;
            dGVStartBatch.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            if (!(dGVStartBatch.Columns[0].Name == "Details"))
                dGVStartBatch.Columns.Insert(0, viewBtnColumn);
            dGVStartBatch.DefaultCellStyle = dgvStyle;
            dGVStartBatch.Columns["Material"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVStartBatch.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (dGVStartBatch.Rows.Count > 0)
                dGVStartBatch.Rows[0].Selected = false;
            dGVStartBatch.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            //String prevBatch = "";
            //int nextColor = 0;
            //Color qColor;

            //for (int i = 0; i < dGVStartBatch.Rows.Count; i++)
            //{
            //    if (prevBatch != dGVStartBatch.Rows[i].Cells["Batch #"].Value.ToString())
            //    {
            //        nextColor++;
            //        if (nextColor == queuedColorNames.Length)
            //            nextColor = 0;
            //    }
            //    qColor = Color.FromKnownColor(queuedColorNames[nextColor]);

            //    prevBatch = dGVStartBatch.Rows[i].Cells["Batch #"].Value.ToString();
            //    dGVStartBatch.Rows[i].DefaultCellStyle.BackColor = qColor;
            //    dGVStartBatch.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            //}
            ColorizeDGV(dGVStartBatch);

            //Oven 1
            DataTable inProcessTableOven1 = new DataTable();
            inProcessTableOven1 = dBTables[10].Copy();
            view2BtnColumn = InProcessTableFormatWithViewButton(view2BtnColumn, ref inProcessTableOven1, ref dGVBatchInOven1);
            dGVBatchInOven1.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            if (dGVBatchInOven1.RowCount > 0)
            {
                buttonBatchOven1Finished = EnableButton(buttonBatchOven1Finished);
                buttonOven1Clean = DisableButton(buttonOven1Clean);
                dGVBatchInOven1.Rows[0].DefaultCellStyle.BackColor = COLOROVEN1INPROCESS;
                dGVBatchInOven1.Rows[0].DefaultCellStyle.SelectionBackColor = COLOROVEN1INPROCESS;
            }
            else
            {
                buttonBatchOven1Finished = DisableButton(buttonBatchOven1Finished);
                buttonOven1Clean = EnableButton(buttonOven1Clean);
            }


            //Oven 2
            DataTable inProcessTableOven2 = new DataTable();
            inProcessTableOven2 = dBTables[11].Copy();
            view3BtnColumn = InProcessTableFormatWithViewButton(view3BtnColumn, ref inProcessTableOven2, ref dGVBatchInOven2);
            dGVBatchInOven2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVStartFinishBatchContents.ResumeLayout();
            if (dGVBatchInOven2.RowCount > 0)
            {
                buttonBatchOven2Finished = EnableButton(buttonBatchOven2Finished);
                buttonOven2Clean = DisableButton(buttonOven2Clean);
                dGVBatchInOven2.Rows[0].DefaultCellStyle.BackColor = COLOROVEN2INPROCESS;
                dGVBatchInOven2.Rows[0].DefaultCellStyle.SelectionBackColor = COLOROVEN2INPROCESS;
            }
            else
            {
                buttonBatchOven2Finished = DisableButton(buttonBatchOven2Finished);
                buttonOven2Clean = EnableButton(buttonOven2Clean);
            }
            dGVStartBatch.ResumeLayout();
            dGVBatchInOven1.ResumeLayout();
            dGVBatchInOven2.ResumeLayout();
        }

        private void InProcessTableFill(int batchId)
        {
            DataTable BatchContentsTable = outgasDB.GetBatchJobs(batchId);
            BatchContentsTable.Columns["BatchLineItem"].ColumnName = "Line #";
            BatchContentsTable.Columns["BatchId"].ColumnName = "Batch #";
            BatchContentsTable.Columns["UserName"].ColumnName = "Customer";
            BatchContentsTable.Columns["PartNumber"].ColumnName = "Part #";
            BatchContentsTable.Columns["DateReceived"].ColumnName = "Received";
            BatchContentsTable.Columns["JobId"].ColumnName = "Job #";
            BatchContentsTable.Columns["CycleId"].ColumnName = "Cycle #";
            BatchContentsTable.Columns.Remove("Status");
            DataGridViewButtonColumn infoColumn = new DataGridViewButtonColumn();
            infoColumn.HeaderText = "";
            infoColumn.Text = "Info";
            infoColumn.UseColumnTextForButtonValue = true;
            dGVStartFinishBatchContents.SuspendLayout();
            if (dGVStartFinishBatchContents.ColumnCount > 0)
                dGVStartFinishBatchContents.Columns.Clear();
            dGVStartFinishBatchContents.DataSource = BatchContentsTable;
            dGVStartFinishBatchContents.DefaultCellStyle = dgvStyle;
            dGVStartFinishBatchContents.ColumnHeadersDefaultCellStyle = dgvStyle;
            dGVStartFinishBatchContents.Columns.Remove("Picture");
            dGVStartFinishBatchContents.Columns.Insert(0, infoColumn);
            dGVStartFinishBatchContents.Columns["Received"].DefaultCellStyle.Format = shortDate.Format;
            dGVStartFinishBatchContents.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVStartFinishBatchContents.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            dGVStartFinishBatchContents.Rows[0].Selected = false;
            dGVStartFinishBatchContents.ResumeLayout();
        }

        private DataGridViewButtonColumn InProcessTableFormatWithViewButton(DataGridViewButtonColumn viewBtnColumn, ref DataTable inProcessTableOven, ref DataGridView dGVOven)
        {
            viewBtnColumn = new DataGridViewButtonColumn();
            viewBtnColumn.Name = "Details";
            viewBtnColumn.Text = "View";
            viewBtnColumn.UseColumnTextForButtonValue = true;
            inProcessTableOven.Columns.Remove("Oven");
            inProcessTableOven.Columns["DateCreated"].ColumnName = "Created";
            inProcessTableOven.Columns["DateStarted"].ColumnName = "Started";
            inProcessTableOven.Columns["BatchID"].ColumnName = "Batch #";
            inProcessTableOven.Columns["ProcessTemp"].ColumnName = "Celsius";
            inProcessTableOven.Columns["CycleId"].ColumnName = "Cycle";
            inProcessTableOven.Columns.Add("Items", typeof(int));
            foreach (DataRow row in inProcessTableOven.Rows)
            {
                row["Items"] = outgasDB.GetAmountOfJobsInBatch((int)row["Batch #"]);
            }
            dGVOven.DataSource = inProcessTableOven;
            if (!(dGVOven.Columns[0].Name == "Details"))
                dGVOven.Columns.Insert(0, viewBtnColumn);
            dGVOven.Columns["Created"].DefaultCellStyle.Format = shortDate.Format;
            dGVOven.Columns["Started"].DefaultCellStyle.Format = shortDate.Format;
            dGVOven.Columns["Material"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVOven.DefaultCellStyle = dgvStyle;
            dGVOven.ColumnHeadersDefaultCellStyle = dgvStyle;
            if (dGVOven.Rows.Count > 0)
                dGVOven.Rows[0].Selected = false;
            return viewBtnColumn;
        }

        private void InProcessBatchFormat(int batchId)
        {
            InProcessTableFill(batchId);
            buttonStartBatch = DisableButton(buttonStartBatch);
            radioButtonOven1.Enabled = false;
            radioButtonOven2.Enabled = false;
        }

        #region Event Handlers

        private void DGVStartBatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVBatchInOven1.Rows.Count > 0)
                dGVBatchInOven1.Rows[0].Selected = false;
            if (dGVBatchInOven2.Rows.Count > 0)
                dGVBatchInOven2.Rows[0].Selected = false;
            shortDate.Format = "M/d/yyyy";
            int batchId = 0;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                batchId = Int32.Parse(dGVStartBatch.Rows[e.RowIndex].Cells["Batch #"].Value.ToString());
                InProcessTableFill(batchId);
                if (dGVStartFinishBatchContents.Rows[0].Cells["Area"].Value.ToString().Equals("TFE"))
                {
                    radioButtonOven2.Checked = true;
                }
                else
                    radioButtonOven1.Checked = true;
                radioButtonOven1.Enabled = true;
                radioButtonOven2.Enabled = true;
                buttonStartBatch = EnableButton(buttonStartBatch);
            }
            ColorizeDGV(dGVStartFinishBatchContents);
        }

        private void DGVBatchInOven1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int batchId = 0;
                if (dGVBatchInOven2.Rows.Count > 0)
                    dGVBatchInOven2.Rows[0].Selected = false;
                if (dGVStartBatch.Rows.Count > 0)
                    dGVStartBatch.Rows[0].Selected = false;
                batchId = Int32.Parse(dGVBatchInOven1.Rows[e.RowIndex].Cells["Batch #"].Value.ToString());
                InProcessBatchFormat(batchId);
                foreach (DataGridViewRow row in dGVStartFinishBatchContents.Rows)
                {
                    row.DefaultCellStyle.BackColor = COLOROVEN1INPROCESS;
                    row.DefaultCellStyle.SelectionBackColor = COLOROVEN1INPROCESS;
                }
            }
        }

        private void DGVBatchInOven2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                int batchId = 0;
                if (dGVBatchInOven1.Rows.Count > 0)
                    dGVBatchInOven1.Rows[0].Selected = false;
                if (dGVStartBatch.Rows.Count > 0)
                    dGVStartBatch.Rows[0].Selected = false;
                batchId = Int32.Parse(dGVBatchInOven2.Rows[e.RowIndex].Cells["Batch #"].Value.ToString());
                InProcessBatchFormat(batchId);
                foreach (DataGridViewRow row in dGVStartFinishBatchContents.Rows)
                {
                    row.DefaultCellStyle.BackColor = COLOROVEN2INPROCESS;
                    row.DefaultCellStyle.SelectionBackColor = COLOROVEN2INPROCESS;
                }
            }
        }

        private void ButtonStartBatch_Click(object sender, EventArgs e)
        {
            var result = new DialogResult();
            bool start = false;
            string oven = "";
            if (dGVStartFinishBatchContents.Rows[0].Cells["Area"].Value.ToString().Equals("TFE"))
            {
                //Alert about using different oven
                if (radioButtonOven2.Checked == true)
                {
                    oven = "Oven 2(TFE)";
                    start = true;
                }
                else
                {
                    result = MessageBox.Show("Oven 1(EGUN) is not the normal oven for TFE parts. Are you sure you want to run this Batch in Oven 1(EGUN)?", "Wrong Oven?",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            oven = "Oven 1(EGUN)";
                            start = true;
                            break;
                        case DialogResult.No:
                            MessageBox.Show("Please change the oven and resubmit.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }
            else
            {
                if (radioButtonOven1.Checked == true)
                {
                    oven = "Oven 1(EGUN)";
                    start = true;
                }
                else
                {
                    result = MessageBox.Show("Oven 2(TFE) is not the normal oven for these parts. Are you sure you want to run this Batch in Oven 2(TFE)?", "Wrong Oven?",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            oven = "Oven 2(TFE)";
                            start = true;

                            break;
                        case DialogResult.No:
                            MessageBox.Show("Please change the oven and resubmit.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }
            if (start)
            {
                StartBatchInOven(oven);
                FillDataTables();
            }
        }

        private void StartBatchInOven(string oven)
        {
            if (outgasDB.IsOvenEmpty(oven))
            {
                int batchId = (Int32.Parse(dGVStartFinishBatchContents.Rows[0].Cells["Batch #"].Value.ToString()));
                int cycleId = (Int32.Parse(dGVStartFinishBatchContents.Rows[0].Cells["Cycle #"].Value.ToString()));
                if (outgasDB.StartBatch(batchId, oven))
                {
                    MessageBox.Show("Batch Number " + batchId + " has been started. \n Please make sure this batch is in " + oven + ",\n \t running cycle " + cycleId + ".", "Batch Started", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("There is already a batch In Process for " + oven + ". \nPlease finish the batch in " + oven + " first.", "Oven Already Full", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBatchDone_Click(object sender, EventArgs e)
        {
            int batchId = 0;
            bool cleanCycle = false;
            if (sender == buttonBatchOven1Finished)
            {
                batchId = (Int32.Parse(dGVBatchInOven1.Rows[0].Cells["Batch #"].Value.ToString()));
                if (dGVBatchInOven1.Rows[0].Cells["Material"].Value.ToString().Equals("Cleaning Cycle"))
                {
                    cleanCycle = true;
                }
                buttonOven1Clean = EnableButton(buttonOven1Clean);
            }
            else
            {
                batchId = (Int32.Parse(dGVBatchInOven2.Rows[0].Cells["Batch #"].Value.ToString()));
                if (dGVBatchInOven2.Rows[0].Cells["Material"].Value.ToString().Equals("Cleaning Cycle"))
                {
                    cleanCycle = true;
                }
                buttonOven2Clean = EnableButton(buttonOven2Clean);
            }
            if (outgasDB.UpdateBatchStatusFinished(batchId))
            {
                MessageBox.Show("Batch  #" + batchId + " is now logged as finished.\n Please remove it from the oven.",
                                "Batch Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cleanCycle)
            {
                outgasDB.UpdateJobBatchStatusClosed(batchId);
            }
            else
            {
                SendContactEmail(batchId);
            }
            FillDataTables();
        }

        private void buttonOvenClean_Click(object sender, EventArgs e)
        {
            string oven = "Oven 1(EGUN)";
            Button s = (Button)sender;
            if (s.Name == "buttonOven2Clean")
                oven = "Oven 2(TFE)";
            if (outgasDB.IsOvenEmpty(oven))
            {
                JobRequest tempJobRequest = new JobRequest();
                int job;

                tempJobRequest.SetQuantity(1);
                tempJobRequest.SetPartNumber("Cleaning");
                tempJobRequest.SetCustomerId(customerId);
                tempJobRequest.SetLocation(oven);
                tempJobRequest.SetContactId(contactId);
                job = outgasDB.AddJobRequest(tempJobRequest);
                int batch = outgasDB.CreateBatch(operatorId);
                if (batch != 0)
                {
                    if (outgasDB.AddToBatch(batch, job))
                    {
                        outgasDB.UpdateJobStatus(job, "In Process");
                        if (outgasDB.StartBatch(batch, oven))
                        {
                            MessageBox.Show("Cleaning Cyle - Batch # " + batch + ". \n Please start the cleaning cycle in " + oven + ".", "Cleaning Cycle", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            FillDataTables();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("There is already a batch In Process for " + oven + ". \nPlease finish the batch in " + oven + " before starting the cleaning cycle.", "Oven Already Full", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
        #endregion

        #region Super User

        public void SuperUserInitTab()
        {
            DataTable matTable = outgasDB.GetMaterialList();
            DataTable cycleTable = outgasDB.GetCycleList();
            DataTable areaTable = outgasDB.GetAreaList();
            DataTable deleteJobTable = dBTables[1].Copy();
            comboBoxNewMaterial.SuspendLayout();
            comboBoxNewCycle.SuspendLayout();
            comboBoxNewArea.SuspendLayout();
            comboBoxDeletableJobs.SuspendLayout();

            for (int index = 0; index < matTable.Rows.Count; index++)
            {
                DataRow row = matTable.Rows[index];
                if (row.Field<string>("Material") == "Cleaning Cycle")
                    matTable.Rows.Remove(row);
            }
            for (int index = 0; index < cycleTable.Rows.Count; index++)
            {
                DataRow row = cycleTable.Rows[index];
                if ((row.Field<string>("CycleID") == "17") || (row.Field<string>("CycleID") == "10") || (row.Field<string>("CycleID") == "6"))
                    cycleTable.Rows.Remove(row);
            }
            for (int index = 0; index < areaTable.Rows.Count; index++)
            {
                DataRow row = areaTable.Rows[index];
                if (row.Field<string>("Area") == "Cleaning")
                    areaTable.Rows.Remove(row);
            }
            DataRow matPrompt = matTable.NewRow();
            buttonResetNewPart = DisableButton(buttonResetNewPart);
            buttonSubmitNewPart = DisableButton(buttonSubmitNewPart);
            matPrompt["Material"] = "Select..";
            matTable.Rows.InsertAt(matPrompt, 0);
            comboBoxNewMaterial.DataSource = matTable;
            comboBoxNewMaterial.DisplayMember = "Material";
            comboBoxNewMaterial.ValueMember = "Material";

            DataRow cyclePrompt = cycleTable.NewRow();
            cyclePrompt["CycleID"] = "Select..";
            cycleTable.Rows.InsertAt(cyclePrompt, 0);
            comboBoxNewCycle.DataSource = cycleTable;
            comboBoxNewCycle.DisplayMember = "CycleID";
            comboBoxNewCycle.ValueMember = "CycleID";

            DataRow areaPrompt = areaTable.NewRow();
            areaPrompt["Area"] = "Select..";
            areaTable.Rows.InsertAt(areaPrompt, 0);
            comboBoxNewArea.DataSource = areaTable;
            comboBoxNewArea.DisplayMember = "Area";
            comboBoxNewArea.ValueMember = "Area";

            comboBoxDeletableJobs.DataSource = deleteJobTable;
            comboBoxDeletableJobs.DisplayMember = "JobId";
            comboBoxDeletableJobs.ValueMember = "JobId";

            comboBoxNewMaterial.ResumeLayout();
            comboBoxNewCycle.ResumeLayout();
            comboBoxNewArea.ResumeLayout();
            comboBoxDeletableJobs.ResumeLayout();
        }

        private void EnableSubmitPartIf()
        {
            bool submit = true;
            buttonResetNewPart = EnableButton(buttonResetNewPart);
            if (newPartNumber.Equals(null) || newPartNumber.Equals(""))
                submit = false;
            if (newPartDescription.Equals(null) || newPartDescription.Equals(""))
                submit = false;
            if (newPartMaterial.Equals(null) || newPartMaterial.Equals(""))
                submit = false;
            if (newPartCycle.Equals(null) || newPartCycle.Equals(""))
                submit = false;
            if (newPartArea.Equals(null) || newPartArea.Equals(""))
                submit = false;
            if (submit)
                buttonSubmitNewPart = EnableButton(buttonSubmitNewPart);
            else
                buttonSubmitNewPart = DisableButton(buttonSubmitNewPart);
        }

        #region Event Handlers

        private void buttonResetNewPart_Click(object sender, EventArgs e)
        {
            SuperUserInitTab();
        }

        private void buttonSubmitNewPart_Click(object sender, EventArgs e)
        {
            if (outgasDB.AddNewPart(newPartNumber, newPartDescription, newPartCycle, newPartArea, newPartMaterial))
                MessageBox.Show("Part Added Successfully");
            else
                MessageBox.Show("Error adding part.");
        }
        // PARTNUMBER -----------------------------------
        private void textBoxNewPartNumber_Enter(object sender, EventArgs e)
        {
            if (textBoxNewPartNumber.Text == "Enter Part Number Here")
            {
                textBoxNewPartNumber.Text = "";
                textBoxNewPartNumber.ForeColor = Color.Black;
            }

        }

        private void textBoxNewPartNumber_Finish(object sender, EventArgs e)
        {
            if (textBoxNewPartNumber.Text.Trim() == "")
            {
                textBoxNewPartNumber.ForeColor = SystemColors.AppWorkspace;
                textBoxNewPartNumber.Text = "Enter Part Number Here";
            }
            else
            {
                newPartNumber = textBoxNewPartNumber.Text.Trim();
                EnableSubmitPartIf();
            }

        }
        // DESCRIPTION -----------------------------------
        private void textBoxNewDescription_Enter(object sender, MouseEventArgs e)
        {
            if (textBoxNewDescription.Text == "Enter Description Here")
            {
                textBoxNewDescription.Text = "";
                textBoxNewDescription.ForeColor = Color.Black;
            }
        }

        private void textBoxNewDescription_Finish(object sender, EventArgs e)
        {
            if (textBoxNewDescription.Text.Trim() == "")
            {
                textBoxNewDescription.ForeColor = SystemColors.AppWorkspace;
                textBoxNewDescription.Text = "Enter Description Here";
            }
            else
            {
                newPartDescription = textBoxNewDescription.Text.Trim();
                EnableSubmitPartIf();
            }
        }
        // MATERIAL -----------------------------------       
        private void comboBoxNewMaterial_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxNewMaterial.SelectedValue.ToString().Equals("Select.."))
            {
                comboBoxNewMaterial.ForeColor = SystemColors.AppWorkspace;
            }
            else
            {
                newPartMaterial = comboBoxNewMaterial.SelectedValue.ToString();
                EnableSubmitPartIf();
            }
        }

        private void comboBoxNewMaterial_Enter(object sender, EventArgs e)
        {
            comboBoxNewMaterial.ForeColor = Color.Black;
        }

        private void comboBoxNewMaterial_Leave(object sender, EventArgs e)
        {
            if (comboBoxNewMaterial.SelectedValue.ToString().Equals("Select.."))
            {
                comboBoxNewMaterial.ForeColor = SystemColors.AppWorkspace;
            }
        }
        // CYCLE -----------------------------------
        private void comboBoxNewCycle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxNewCycle.SelectedValue.ToString().Equals("Select.."))
            {
                comboBoxNewCycle.ForeColor = SystemColors.AppWorkspace;
            }
            else
            {
                newPartCycle = comboBoxNewCycle.SelectedValue.ToString();
                EnableSubmitPartIf();
            }
        }

        private void comboBoxNewCycle_Enter(object sender, EventArgs e)
        {
            comboBoxNewCycle.ForeColor = Color.Black;
        }

        private void comboBoxNewCycle_Leave(object sender, EventArgs e)
        {
            if (comboBoxNewCycle.SelectedValue.ToString().Equals("Select.."))
            {
                comboBoxNewCycle.ForeColor = SystemColors.AppWorkspace;
            }
        }
        // AREA -----------------------------------
        private void comboBoxNewArea_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxNewArea.SelectedValue.ToString().Equals("Select.."))
            {
                comboBoxNewArea.ForeColor = SystemColors.AppWorkspace;
            }
            else
            {
                newPartArea = comboBoxNewArea.SelectedValue.ToString();
                EnableSubmitPartIf();
            }
        }

        private void comboBoxNewArea_Enter(object sender, EventArgs e)
        {
            comboBoxNewArea.ForeColor = Color.Black;
        }

        private void comboBoxNewArea_Leave(object sender, EventArgs e)
        {
            if (comboBoxNewArea.SelectedValue.ToString().Equals("Select.."))
            {
                comboBoxNewArea.ForeColor = SystemColors.AppWorkspace;
            }
        }
        // DELETE JOB -----------------------------------
        private void comboBoxDeletableJobs_SelectedValueChanged(object sender, EventArgs e)
        {
            buttonDeleteJob = EnableButton(buttonDeleteJob);
        }

        private void buttonDeleteJob_Click(object sender, EventArgs e)
        {
            int jobId = int.Parse(comboBoxDeletableJobs.SelectedValue.ToString());
            DialogResult result = MessageBox.Show("This will eliminate Job #" + jobId + ".\n(This cannot be undone)\nAre you sure you want to delete this job?", "Delete?",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    if (outgasDB.DeleteJob(jobId))
                        MessageBox.Show("Job #" + jobId + " Has been deleted.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Job #" + jobId + " Has NOT been deleted.", "Delete Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    FillDataTables();
                    break;
            }

        }
        #endregion

        #endregion
    }
}
