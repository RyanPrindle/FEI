namespace Cleaning_Scheduler_Interface
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.dGVAdminQueue = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVAdminInProcess = new System.Windows.Forms.DataGridView();
            this.bGWStartCleaning = new System.ComponentModel.BackgroundWorker();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEditRequests = new System.Windows.Forms.Button();
            this.bGWorkerRefreshTables = new System.ComponentModel.BackgroundWorker();
            this.bGWorkerDeleteRequest = new System.ComponentModel.BackgroundWorker();
            this.bGWorkerBackUpRequest = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminInProcess)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dGVAdminQueue);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.PaleGreen;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.dGVAdminInProcess);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(966, 494);
            this.splitContainer1.SplitterDistance = 236;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Queue";
            // 
            // dGVAdminQueue
            // 
            this.dGVAdminQueue.AllowUserToAddRows = false;
            this.dGVAdminQueue.AllowUserToDeleteRows = false;
            this.dGVAdminQueue.AllowUserToOrderColumns = true;
            this.dGVAdminQueue.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.dGVAdminQueue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dGVAdminQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVAdminQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVAdminQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dGVAdminQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVAdminQueue.Location = new System.Drawing.Point(13, 38);
            this.dGVAdminQueue.Margin = new System.Windows.Forms.Padding(0);
            this.dGVAdminQueue.Name = "dGVAdminQueue";
            this.dGVAdminQueue.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVAdminQueue.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dGVAdminQueue.RowTemplate.Height = 45;
            this.dGVAdminQueue.Size = new System.Drawing.Size(936, 181);
            this.dGVAdminQueue.TabIndex = 0;
            this.dGVAdminQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVAdminQueue_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "In Process";
            // 
            // dGVAdminInProcess
            // 
            this.dGVAdminInProcess.AllowUserToAddRows = false;
            this.dGVAdminInProcess.AllowUserToDeleteRows = false;
            this.dGVAdminInProcess.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVAdminInProcess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dGVAdminInProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVAdminInProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVAdminInProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dGVAdminInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVAdminInProcess.DefaultCellStyle = dataGridViewCellStyle13;
            this.dGVAdminInProcess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGVAdminInProcess.Location = new System.Drawing.Point(13, 38);
            this.dGVAdminInProcess.Margin = new System.Windows.Forms.Padding(0);
            this.dGVAdminInProcess.Name = "dGVAdminInProcess";
            this.dGVAdminInProcess.RowHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVAdminInProcess.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dGVAdminInProcess.RowTemplate.Height = 45;
            this.dGVAdminInProcess.Size = new System.Drawing.Size(936, 192);
            this.dGVAdminInProcess.TabIndex = 1;
            this.dGVAdminInProcess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVAdminInProcess_CellContentClick);
            // 
            // bGWStartCleaning
            // 
            this.bGWStartCleaning.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWStartCleaning_DoWork);
            this.bGWStartCleaning.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWStartCleaning_RunWorkerCompleted);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnHistory);
            this.pnlButtons.Controls.Add(this.btnExit);
            this.pnlButtons.Controls.Add(this.btnEditRequests);
            this.pnlButtons.Location = new System.Drawing.Point(10, 514);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(966, 85);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHistory.AutoEllipsis = true;
            this.btnHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHistory.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Black;
            this.btnHistory.Location = new System.Drawing.Point(380, 9);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(187, 63);
            this.btnHistory.TabIndex = 23;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Visible = false;
            this.btnHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(762, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(187, 63);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Return to Mainscreen";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // btnEditRequests
            // 
            this.btnEditRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditRequests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(188)))));
            this.btnEditRequests.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRequests.ForeColor = System.Drawing.Color.Black;
            this.btnEditRequests.Location = new System.Drawing.Point(13, 9);
            this.btnEditRequests.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditRequests.Name = "btnEditRequests";
            this.btnEditRequests.Size = new System.Drawing.Size(187, 63);
            this.btnEditRequests.TabIndex = 21;
            this.btnEditRequests.Text = "Edit Requests";
            this.btnEditRequests.UseVisualStyleBackColor = true;
            this.btnEditRequests.Click += new System.EventHandler(this.btnEditRequests_Click);
            // 
            // bGWorkerDeleteRequest
            // 
            this.bGWorkerDeleteRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerDeleteRequest_DoWork);
            this.bGWorkerDeleteRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerDeleteRequest_RunWorkerCompleted);
            // 
            // bGWorkerBackUpRequest
            // 
            this.bGWorkerBackUpRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerBackUpRequest_DoWork);
            this.bGWorkerBackUpRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerBackUpRequest_RunWorkerCompleted);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(986, 608);
            this.ControlBox = false;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AdminForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Cleaning Request Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminInProcess)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dGVAdminQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVAdminInProcess;
        private System.ComponentModel.BackgroundWorker bGWStartCleaning;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnEditRequests;
        private System.ComponentModel.BackgroundWorker bGWorkerRefreshTables;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHistory;
        private System.ComponentModel.BackgroundWorker bGWorkerDeleteRequest;
        private System.ComponentModel.BackgroundWorker bGWorkerBackUpRequest;

    }
}