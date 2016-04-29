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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.dGVAdminQueue = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVAdminInProcess = new System.Windows.Forms.DataGridView();
            this.bGWStartCleaning = new System.ComponentModel.BackgroundWorker();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.btnEditRequests = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnReturnToMain = new System.Windows.Forms.Button();
            this.bGWorkerRefreshTables = new System.ComponentModel.BackgroundWorker();
            this.bGWorkerDeleteRequest = new System.ComponentModel.BackgroundWorker();
            this.bGWorkerBackUpRequest = new System.ComponentModel.BackgroundWorker();
            this.pnlControl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminInProcess)).BeginInit();
            this.pnlEdit.SuspendLayout();
            this.pnlControl.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(966, 520);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Queue";
            // 
            // dGVAdminQueue
            // 
            this.dGVAdminQueue.AllowUserToAddRows = false;
            this.dGVAdminQueue.AllowUserToDeleteRows = false;
            this.dGVAdminQueue.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))));
            this.dGVAdminQueue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVAdminQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVAdminQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGVAdminQueue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dGVAdminQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVAdminQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVAdminQueue.ColumnHeadersHeight = 40;
            this.dGVAdminQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVAdminQueue.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGVAdminQueue.Location = new System.Drawing.Point(13, 38);
            this.dGVAdminQueue.Margin = new System.Windows.Forms.Padding(0);
            this.dGVAdminQueue.Name = "dGVAdminQueue";
            this.dGVAdminQueue.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVAdminQueue.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVAdminQueue.RowTemplate.Height = 40;
            this.dGVAdminQueue.Size = new System.Drawing.Size(936, 191);
            this.dGVAdminQueue.TabIndex = 0;
            this.dGVAdminQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVAdminQueue.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVAdminQueue.Sorted += new System.EventHandler(this.dGV_Sorted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "In Process";
            // 
            // dGVAdminInProcess
            // 
            this.dGVAdminInProcess.AllowUserToAddRows = false;
            this.dGVAdminInProcess.AllowUserToDeleteRows = false;
            this.dGVAdminInProcess.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVAdminInProcess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVAdminInProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVAdminInProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGVAdminInProcess.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.dGVAdminInProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVAdminInProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVAdminInProcess.ColumnHeadersHeight = 40;
            this.dGVAdminInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVAdminInProcess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGVAdminInProcess.Location = new System.Drawing.Point(13, 38);
            this.dGVAdminInProcess.Margin = new System.Windows.Forms.Padding(0);
            this.dGVAdminInProcess.Name = "dGVAdminInProcess";
            this.dGVAdminInProcess.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVAdminInProcess.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dGVAdminInProcess.RowTemplate.Height = 40;
            this.dGVAdminInProcess.Size = new System.Drawing.Size(936, 122);
            this.dGVAdminInProcess.TabIndex = 1;
            this.dGVAdminInProcess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVAdminInProcess.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVAdminInProcess.Sorted += new System.EventHandler(this.dGV_Sorted);
            // 
            // bGWStartCleaning
            // 
            this.bGWStartCleaning.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWStartCleaning_DoWork);
            this.bGWStartCleaning.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWStartCleaning_RunWorkerCompleted);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlEdit.Controls.Add(this.btnEditRequests);
            this.pnlEdit.Location = new System.Drawing.Point(10, 540);
            this.pnlEdit.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(223, 58);
            this.pnlEdit.TabIndex = 1;
            // 
            // btnEditRequests
            // 
            this.btnEditRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditRequests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(188)))));
            this.btnEditRequests.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditRequests.ForeColor = System.Drawing.Color.Navy;
            this.btnEditRequests.Location = new System.Drawing.Point(13, 10);
            this.btnEditRequests.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditRequests.Name = "btnEditRequests";
            this.btnEditRequests.Size = new System.Drawing.Size(187, 35);
            this.btnEditRequests.TabIndex = 21;
            this.btnEditRequests.Text = "Edit Requests";
            this.btnEditRequests.UseVisualStyleBackColor = true;
            this.btnEditRequests.Click += new System.EventHandler(this.btnEditRequests_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHistory.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHistory.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Maroon;
            this.btnHistory.Location = new System.Drawing.Point(31, 10);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(161, 35);
            this.btnHistory.TabIndex = 23;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuit.BackColor = System.Drawing.Color.Gray;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.Black;
            this.btnQuit.Location = new System.Drawing.Point(502, 10);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(0);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(198, 35);
            this.btnQuit.TabIndex = 24;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            // 
            // btnReturnToMain
            // 
            this.btnReturnToMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnToMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReturnToMain.BackColor = System.Drawing.Color.DarkGray;
            this.btnReturnToMain.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReturnToMain.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToMain.ForeColor = System.Drawing.Color.Black;
            this.btnReturnToMain.Location = new System.Drawing.Point(257, 10);
            this.btnReturnToMain.Margin = new System.Windows.Forms.Padding(0);
            this.btnReturnToMain.Name = "btnReturnToMain";
            this.btnReturnToMain.Size = new System.Drawing.Size(230, 35);
            this.btnReturnToMain.TabIndex = 22;
            this.btnReturnToMain.Text = "Main Screen";
            this.btnReturnToMain.UseVisualStyleBackColor = false;
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
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlControl.Controls.Add(this.btnHistory);
            this.pnlControl.Controls.Add(this.btnReturnToMain);
            this.pnlControl.Controls.Add(this.btnQuit);
            this.pnlControl.Location = new System.Drawing.Point(259, 540);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(717, 59);
            this.pnlControl.TabIndex = 25;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(986, 608);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Cleaning Request Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.SizeChanged += new System.EventHandler(this.AdminForm_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAdminInProcess)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dGVAdminQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVAdminInProcess;
        private System.ComponentModel.BackgroundWorker bGWStartCleaning;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.Button btnEditRequests;
        private System.ComponentModel.BackgroundWorker bGWorkerRefreshTables;
        private System.Windows.Forms.Button btnReturnToMain;
        private System.Windows.Forms.Button btnHistory;
        private System.ComponentModel.BackgroundWorker bGWorkerDeleteRequest;
        private System.ComponentModel.BackgroundWorker bGWorkerBackUpRequest;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel pnlControl;

    }
}