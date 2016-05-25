using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaning_Scheduler_Interface
{
    public partial class ColumnGunPartListForm : Form
    {
        private String mGun;
        private ProgressBarForm progressForm;
        private String imagePath;
        private Image imageIcon;

        public ColumnGunPartListForm(String gun)
        {
            mGun = gun;
            InitializeComponent();
            this.Text = "Contents of " + mGun;
            imageIcon = Cleaning_Scheduler_Interface.Properties.Resources.image_32;
            imageIcon = (Image)new Bitmap(imageIcon, new Size(28, 27));
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
            Label labelPN = new Label();
            Label labelDesc = new Label();
            Label labelPic = new Label();
            Label lblCount = new Label();
            
            String gun = (String)e.Argument;
            lblTitle.Text = gun + " Parts";
            RequestsDB requestDB = new RequestsDB();
            DataTable gunPartTable = requestDB.GetGunParts(gun);
            tLP.SuspendLayout();
            tLP.Padding = new Padding(0, 0, 1, 0);
            tLP.AutoScroll = true;
            tLP.AutoSize = true;
            tLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tLP.ColumnCount = 3;           
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300f));
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400f));
            tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90f));
            tLP.Controls.Add(lblTitle, 0, 0);
            tLP.Controls.Add(labelPN, 0, 1);
            tLP.Controls.Add(labelDesc, 1, 1);
            tLP.Controls.Add(labelPic, 2, 1);
            tLP.Location = new System.Drawing.Point( 0, 0);
            tLP.Name = "tLPGun";
            tLP.RowCount = 2;
            tLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tLP.TabIndex = 0;
            tLP.MouseEnter += new System.EventHandler(tLP_MouseEnter);
            // 
            TableLayoutRowStyleCollection styles = tLP.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 50;
            }
            // 
            // lblCount
            // 
            //lblCount.AutoSize = true;
            //lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            //lblCount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //lblCount.Location = new System.Drawing.Point(3, 0);
            //lblCount.Name = "lblCount";
            //lblCount.TabIndex = 0;
            //lblCount.Text = "#";
            //lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            tLP.SetColumnSpan(lblTitle, 3);
            lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Arial Black", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitle.Location = new System.Drawing.Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 0;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPN
            // 
            labelPN.AutoSize = true;
            labelPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            labelPN.Dock = System.Windows.Forms.DockStyle.Fill;
            labelPN.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPN.Location = new System.Drawing.Point(3, 29);
            labelPN.Name = "label2";
            //labelPN.Size = new System.Drawing.Size(248, 552);
            labelPN.TabIndex = 1;
            labelPN.Text = "Part Number";
            labelPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            labelDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            labelDesc.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelDesc.Location = new System.Drawing.Point(257, 29);
            labelDesc.Name = "label3";
            labelDesc.Size = new System.Drawing.Size(375, 552);
            labelDesc.TabIndex = 2;
            labelDesc.Text = "Description";
            labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPic
            // 
            labelPic.AutoSize = true;
            labelPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            labelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            labelPic.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPic.Location = new System.Drawing.Point(638, 29);
            labelPic.Name = "label1";
            labelPic.Size = new System.Drawing.Size(272, 552);
            labelPic.TabIndex = 3;
            labelPic.Text = "3D Image";
            labelPic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            foreach (DataRow row in gunPartTable.Rows)
            {
                int index;
                Label lblPartNumber = new Label();
                Label lblDescription = new Label();
                Panel pnlPN = new Panel();
                Panel pnlDesc = new Panel();
                Panel pnlBtn = new Panel();
                Button btnPic = new Button();
                index = gunPartTable.Rows.IndexOf(row) + 3;   
                lblDescription.Font = lblPartNumber.Font = btnPic.Font =  new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
                lblPartNumber.Dock = btnPic.Dock = pnlBtn.Dock = pnlPN.Dock = pnlDesc.Dock = lblDescription.Dock = DockStyle.Fill;
                lblPartNumber.TextAlign = lblDescription.TextAlign = ContentAlignment.MiddleCenter;
                btnPic.UseVisualStyleBackColor = true;
                btnPic.Name = row["PartNumber"].ToString();
                btnPic.Image = imageIcon;
                toolTipPartsList.SetToolTip(btnPic, "3D Image of Part");
                lblPartNumber.Text = row["PartNumber"].ToString();
                imagePath = @"\\hlsql01\Beamtech\Summit\FE_Cleaning\JT\" + lblPartNumber.Text + ".jt";
                if (File.Exists(imagePath))
                    btnPic.Enabled = true;
                else
                    btnPic.Enabled = false;
                lblDescription.Text = row["Description"].ToString();
                btnPic.Click += new System.EventHandler(btnPic_Click);
                pnlBtn.Height = pnlDesc.Height = pnlPN.Height = 50;
                pnlBtn.BorderStyle = pnlDesc.BorderStyle = pnlPN.BorderStyle = BorderStyle.Fixed3D;
                pnlPN.Controls.Add(lblPartNumber);
                pnlDesc.Controls.Add(lblDescription);
                pnlBtn.Controls.Add(btnPic);
                tLP.Controls.Add(pnlPN, 0, index);
                tLP.Controls.Add(pnlDesc, 1, index);
                tLP.Controls.Add(pnlBtn, 2, index);
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

        private void btnPic_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = btn.Name.ToString();
            string filePath = @"\\hlsql01\Beamtech\Summit\FE_Cleaning\JT\" + name + ".jt";
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("No Image Available for this Part");
            }
        }
    }
}
