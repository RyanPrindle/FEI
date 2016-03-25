namespace Cleaning_Scheduler_Interface
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dGVQueue = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVInProcess = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dGVCompleted = new System.Windows.Forms.DataGridView();
            this.buttonColumnRequest = new System.Windows.Forms.Button();
            this.btnCleaning = new System.Windows.Forms.Button();
            this.btnPartRequest = new System.Windows.Forms.Button();
            this.bGWorkerFillTables = new System.ComponentModel.BackgroundWorker();
            this.buttonQuit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVInProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCompleted)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.splitContainer1.Panel2.Controls.Add(this.buttonQuit);
            this.splitContainer1.Panel2.Controls.Add(this.buttonColumnRequest);
            this.splitContainer1.Panel2.Controls.Add(this.btnCleaning);
            this.splitContainer1.Panel2.Controls.Add(this.btnPartRequest);
            this.splitContainer1.Size = new System.Drawing.Size(949, 472);
            this.splitContainer1.SplitterDistance = 734;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.splitContainer2.Panel1.Controls.Add(this.dGVQueue);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(734, 472);
            this.splitContainer2.SplitterDistance = 156;
            this.splitContainer2.TabIndex = 0;
            // 
            // dGVQueue
            // 
            this.dGVQueue.AllowUserToAddRows = false;
            this.dGVQueue.AllowUserToDeleteRows = false;
            this.dGVQueue.AllowUserToResizeColumns = false;
            this.dGVQueue.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Honeydew;
            this.dGVQueue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dGVQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dGVQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVQueue.DefaultCellStyle = dataGridViewCellStyle15;
            this.dGVQueue.Location = new System.Drawing.Point(12, 37);
            this.dGVQueue.Name = "dGVQueue";
            this.dGVQueue.ReadOnly = true;
            this.dGVQueue.RowHeadersVisible = false;
            this.dGVQueue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            this.dGVQueue.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dGVQueue.RowTemplate.Height = 40;
            this.dGVQueue.Size = new System.Drawing.Size(709, 106);
            this.dGVQueue.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Queue";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Black;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.dGVInProcess);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.dGVCompleted);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer3.Size = new System.Drawing.Size(734, 312);
            this.splitContainer3.SplitterDistance = 153;
            this.splitContainer3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "In Process ";
            // 
            // dGVInProcess
            // 
            this.dGVInProcess.AllowUserToAddRows = false;
            this.dGVInProcess.AllowUserToDeleteRows = false;
            this.dGVInProcess.AllowUserToResizeColumns = false;
            this.dGVInProcess.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.dGVInProcess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dGVInProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVInProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVInProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dGVInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVInProcess.DefaultCellStyle = dataGridViewCellStyle19;
            this.dGVInProcess.Location = new System.Drawing.Point(13, 38);
            this.dGVInProcess.Name = "dGVInProcess";
            this.dGVInProcess.RowHeadersVisible = false;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.dGVInProcess.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dGVInProcess.RowTemplate.Height = 40;
            this.dGVInProcess.Size = new System.Drawing.Size(708, 102);
            this.dGVInProcess.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Completed In Last 7 Days";
            // 
            // dGVCompleted
            // 
            this.dGVCompleted.AllowUserToAddRows = false;
            this.dGVCompleted.AllowUserToDeleteRows = false;
            this.dGVCompleted.AllowUserToResizeColumns = false;
            this.dGVCompleted.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dGVCompleted.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dGVCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVCompleted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVCompleted.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dGVCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVCompleted.DefaultCellStyle = dataGridViewCellStyle23;
            this.dGVCompleted.Location = new System.Drawing.Point(13, 38);
            this.dGVCompleted.Name = "dGVCompleted";
            this.dGVCompleted.ReadOnly = true;
            this.dGVCompleted.RowHeadersVisible = false;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.dGVCompleted.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dGVCompleted.RowTemplate.Height = 40;
            this.dGVCompleted.Size = new System.Drawing.Size(708, 104);
            this.dGVCompleted.TabIndex = 3;
            // 
            // buttonColumnRequest
            // 
            this.buttonColumnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonColumnRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonColumnRequest.Location = new System.Drawing.Point(9, 10);
            this.buttonColumnRequest.Margin = new System.Windows.Forms.Padding(5);
            this.buttonColumnRequest.Name = "buttonColumnRequest";
            this.buttonColumnRequest.Size = new System.Drawing.Size(192, 84);
            this.buttonColumnRequest.TabIndex = 19;
            this.buttonColumnRequest.Text = "Request Column Cleaning";
            this.buttonColumnRequest.UseVisualStyleBackColor = true;
            this.buttonColumnRequest.Click += new System.EventHandler(this.buttonColumnRequest_Click);
            // 
            // btnCleaning
            // 
            this.btnCleaning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleaning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCleaning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.btnCleaning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCleaning.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleaning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.btnCleaning.Location = new System.Drawing.Point(9, 327);
            this.btnCleaning.Margin = new System.Windows.Forms.Padding(5);
            this.btnCleaning.Name = "btnCleaning";
            this.btnCleaning.Size = new System.Drawing.Size(192, 83);
            this.btnCleaning.TabIndex = 20;
            this.btnCleaning.Text = "Cleaning Admin";
            this.btnCleaning.UseVisualStyleBackColor = false;
            this.btnCleaning.Click += new System.EventHandler(this.btnCleaning_Click);
            // 
            // btnPartRequest
            // 
            this.btnPartRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartRequest.Location = new System.Drawing.Point(9, 111);
            this.btnPartRequest.Margin = new System.Windows.Forms.Padding(5);
            this.btnPartRequest.Name = "btnPartRequest";
            this.btnPartRequest.Size = new System.Drawing.Size(192, 83);
            this.btnPartRequest.TabIndex = 18;
            this.btnPartRequest.Text = "Request Part Cleaning";
            this.btnPartRequest.UseVisualStyleBackColor = true;
            this.btnPartRequest.Click += new System.EventHandler(this.btnPartRequest_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonQuit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(132)))));
            this.buttonQuit.Location = new System.Drawing.Point(9, 420);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(5);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(192, 39);
            this.buttonQuit.TabIndex = 21;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(949, 472);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Cleaning Scheduler Interface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVQueue)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVInProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCompleted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dGVInProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dGVCompleted;
        private System.ComponentModel.BackgroundWorker bGWorkerFillTables;
        private System.Windows.Forms.Button buttonColumnRequest;
        private System.Windows.Forms.Button btnCleaning;
        private System.Windows.Forms.Button btnPartRequest;
        private System.Windows.Forms.Button buttonQuit;
    }
}

