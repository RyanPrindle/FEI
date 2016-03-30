using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaning_Scheduler_Interface
{
    public partial class FinishForm : Form
    {
        private int reqId;
        private ProgressBarForm mProgress;
        private CleanProcedure cleanProcedure;
        public FinishForm(int req)
        {
            InitializeComponent();
            reqId = req;
            cleanProcedure = new CleanProcedure();
        }

        private void checkBoxCrest_Click(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            if (check.Checked == true)
            {
                if (check == checkBoxCrest10)
                {
                    checkBoxCrest20.Checked = false;
                    checkBoxCrestLong.Checked = false;
                }
                else if (check == checkBoxCrest20)
                {
                    checkBoxCrest10.Checked = false;
                    checkBoxCrestLong.Checked = false;
                }
                else
                {
                    checkBoxCrest10.Checked = false;
                    checkBoxCrest20.Checked = false;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogFinished_Click(object sender, EventArgs e)
        {
            cleanProcedure.mDecon = checkBoxDecon.Checked;
            cleanProcedure.mDishWasher = checkBoxDishwasher.Checked;
            cleanProcedure.mReqID = reqId;
            cleanProcedure.mUltrasonic = checkBoxUltrasonic.Checked;
            cleanProcedure.mWaterPik = checkBoxWaterPik.Checked;
            cleanProcedure.mCrest10 = checkBoxCrest10.Checked;
            cleanProcedure.mCrest20 = checkBoxCrest20.Checked;
            cleanProcedure.mCrestLong = checkBoxCrestLong.Checked;
            mProgress = new ProgressBarForm();
            bGWorkerLogFinished = new BackgroundWorker();
            bGWorkerLogFinished.DoWork += new DoWorkEventHandler(bGWorkerLogFinished_DoWork);
            bGWorkerLogFinished.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWorkerLogFinished_RunWorkerCompleted);
            bGWorkerLogFinished.RunWorkerAsync(cleanProcedure);
            mProgress.ShowDialog();

        }

        private void bGWorkerLogFinished_DoWork(object sender, DoWorkEventArgs e)
        {
            RequestsDB requestDB = new RequestsDB();
            CleanProcedure mReq = (CleanProcedure)e.Argument;
            e.Result = requestDB.FinishClean(mReq);
            if ((int)e.Result > 0)
            {
                SendEmail(mReq.mReqID);
            }
        }

        private void bGWorkerLogFinished_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int result = (int)e.Result;
            mProgress.Close();
            if (result == 0)
            {
                MessageBox.Show("Could not log as finished.");
            }
            this.Close();
        }

        private void SendEmail(int reqID)
        {
            RequestsDB requestDB = new RequestsDB();
            DataTable mContact = requestDB.GetRequest(reqID);
            String contact = mContact.Rows[0]["Email"].ToString();
            String part = mContact.Rows[0]["PartNumber"].ToString();
            String requestor = mContact.Rows[0]["Requestor"].ToString();
            if (contact != "none")
            {
                SmtpClient smtpClient = new SmtpClient("hiomail.w2k.feico.com");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = false;
                MailMessage mail = new MailMessage();

                //Setting From , To, Subject, and Body
                mail.From = new MailAddress("Cleaning@fei.com");
                mail.To.Add(new MailAddress(contact));
                mail.Subject = "Cleaning Job Finished";
                mail.Body = "Part - " + part + ", requested by " + requestor +
                            " has finished cleaning, and is ready to be picked up." +
                            "\n\nPlease pick up " + part + " from cleaning." +
                            "\n\nThank You";
                smtpClient.Send(mail);
            }
        }
    }
}
