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
    public partial class ColumnGunPartListForm : Form
    {
        private String mGun;
        private ProgressBarForm progressForm;

        public ColumnGunPartListForm(String gun)
        {
            mGun = gun;
            InitializeComponent();
            this.Text = "Contents of " + mGun;
        }        

        private void ColumnGunPartListForm_Load(object sender, EventArgs e)
        {
            FillDataTables();
        }

        private void FillDataTables()
        {
            progressForm = new ProgressBarForm();
            bGWGunParts = new BackgroundWorker();
            bGWGunParts.DoWork += new DoWorkEventHandler(bGWGunParts_DoWork);
            bGWGunParts.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bGWGunParts_RunWorkerCompleted);
            bGWGunParts.RunWorkerAsync(mGun);
            progressForm.ShowDialog();
        }

        #region BackGround Workers
        private void bGWGunParts_DoWork(object sender, DoWorkEventArgs e)
        {
            TableLayoutPanel tLP = new TableLayoutPanel();
            Label lblTitle = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label1 = new Label();
            Label lblCount = new Label();
            
            String gun = (String)e.Argument;
            lblTitle.Text = gun + " Parts";
            RequestsDB requestDB = new RequestsDB();
            DataTable gunPartTable = requestDB.GetGunParts(gun);
            tLP.SuspendLayout();
            tLP.Padding = new Padding(0, 0, 1, 0);
            tLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tLP.AutoScroll = true;
            tLP.ColumnCount = 4;
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));            
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            tLP.Controls.Add(lblTitle, 1, 0);
            tLP.Controls.Add(lblCount, 0, 2);
            tLP.Controls.Add(label2, 1, 2);
            tLP.Controls.Add(label3, 2, 2);
            tLP.Controls.Add(label1, 3, 2);
            tLP.Location = new System.Drawing.Point( 0, 0);
            tLP.Name = "tLPGun";
            tLP.RowCount = 3;
            tLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tLP.Size = new System.Drawing.Size(908, 576);
            tLP.TabIndex = 0;

            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCount.Location = new System.Drawing.Point(3, 0);
            lblCount.Name = "lblCount";
            lblCount.TabIndex = 0;
            lblCount.Text = "#";
            lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tLP.SetColumnSpan(lblTitle, 4);
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Location = new System.Drawing.Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(907, 29);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Parts Clean";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(3, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(248, 552);
            label2.TabIndex = 1;
            label2.Text = "Part Number";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(257, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(375, 552);
            label3.TabIndex = 2;
            label3.Text = "Description";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(638, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(272, 552);
            label1.TabIndex = 3;
            label1.Text = "Picture / Drawing";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Image image;
            foreach (DataRow row in gunPartTable.Rows)
            {
                int index;
                Label lblPartNumber = new Label();
                Label lblDescription = new Label();
                Label lblNumber = new Label();
                LinkLabel lblPic = new LinkLabel();
                PictureBox pBPartDrawing = new PictureBox();
                image = (Image)Cleaning_Request_Interface.Properties.Resources.ResourceManager.GetObject(row["Image"].ToString());
                pBPartDrawing.Image = image;
                pBPartDrawing.SizeMode = PictureBoxSizeMode.Zoom;
                pBPartDrawing.Height = 24;
                pBPartDrawing.Width = 256;
                lblPartNumber.Dock = DockStyle.Fill;
                lblPartNumber.BorderStyle = BorderStyle.Fixed3D;
                lblPartNumber.TextAlign = ContentAlignment.MiddleCenter;
                lblDescription.Dock = DockStyle.Fill;
                lblDescription.BorderStyle = BorderStyle.Fixed3D;
                lblDescription.TextAlign = ContentAlignment.MiddleCenter;
                index = gunPartTable.Rows.IndexOf(row) + 3;
                lblNumber.Dock = DockStyle.Fill;
                lblNumber.BorderStyle = BorderStyle.Fixed3D;
                lblNumber.TextAlign = ContentAlignment.MiddleCenter;
                lblNumber.Text = gunPartTable.Rows.IndexOf(row) + 1 + "";
                lblPic.Dock = DockStyle.Fill;
                lblPic.BorderStyle = BorderStyle.Fixed3D;
                lblPic.TextAlign = ContentAlignment.MiddleCenter;
                lblPartNumber.Text = row["PartNumber"].ToString();
                lblDescription.Text = row["Description"].ToString();
                tLP.Controls.Add(lblNumber, 0, index);
                tLP.Controls.Add(lblPartNumber, 1, index);
                tLP.Controls.Add(lblDescription, 2, index);
                tLP.Controls.Add(lblPic, 3, index);
            }
            tLP.ResumeLayout();
            e.Result = tLP;
        }

        private void bGWGunParts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TableLayoutPanel tLP = (TableLayoutPanel)e.Result;
            this.SuspendLayout();
            tLP.MouseEnter += new System.EventHandler(tLP_MouseEnter);
            panelTLP.Controls.Add(tLP);
            tLP.HorizontalScroll.Enabled = false;
            this.ResumeLayout();
            progressForm.Close();
        }
        #endregion

        private void tLP_MouseEnter(object sender, EventArgs e)
        {
            TableLayoutPanel tLP = (TableLayoutPanel)sender;
            tLP.Focus();            
        }
    }
}
