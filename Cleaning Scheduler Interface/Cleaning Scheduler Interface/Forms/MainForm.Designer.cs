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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.dGVQueue = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVInProcess = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dGVCompleted = new System.Windows.Forms.DataGridView();
            this.pBLogo = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnCleaning = new System.Windows.Forms.Button();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelCRR = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelHot = new System.Windows.Forms.Panel();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnColumnRequest = new System.Windows.Forms.Button();
            this.btnPartRequest = new System.Windows.Forms.Button();
            this.bGWorkerFillTables = new System.ComponentModel.BackgroundWorker();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).BeginInit();
            this.panelLegend.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.splitContainer1.Panel2.Controls.Add(this.pBLogo);
            this.splitContainer1.Panel2.Controls.Add(this.btnQuit);
            this.splitContainer1.Panel2.Controls.Add(this.btnCleaning);
            this.splitContainer1.Panel2.Controls.Add(this.panelLegend);
            this.splitContainer1.Panel2.Controls.Add(this.btnHistory);
            this.splitContainer1.Panel2.Controls.Add(this.pnlButtons);
            this.splitContainer1.Size = new System.Drawing.Size(1199, 764);
            this.splitContainer1.SplitterDistance = 921;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.dGVQueue);
            this.splitContainer2.Panel1.ForeColor = System.Drawing.Color.Black;
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(142)))));
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(921, 764);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Queue";
            // 
            // dGVQueue
            // 
            this.dGVQueue.AllowUserToAddRows = false;
            this.dGVQueue.AllowUserToDeleteRows = false;
            this.dGVQueue.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(228)))));
            this.dGVQueue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGVQueue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.dGVQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVQueue.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVQueue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVQueue.ColumnHeadersHeight = 40;
            this.dGVQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVQueue.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVQueue.Location = new System.Drawing.Point(0, 40);
            this.dGVQueue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dGVQueue.Name = "dGVQueue";
            this.dGVQueue.ReadOnly = true;
            this.dGVQueue.RowHeadersVisible = false;
            this.dGVQueue.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(202)))));
            this.dGVQueue.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVQueue.RowTemplate.Height = 40;
            this.dGVQueue.Size = new System.Drawing.Size(917, 148);
            this.dGVQueue.TabIndex = 0;
            this.dGVQueue.TabStop = false;
            this.dGVQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVQueue.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVQueue.Sorted += new System.EventHandler(this.dGV_Sorted);
            this.dGVQueue.MouseEnter += new System.EventHandler(this.dGV_MouseEnter);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.dGVInProcess);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Panel2.Controls.Add(this.dGVCompleted);
            this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.splitContainer3.Size = new System.Drawing.Size(921, 562);
            this.splitContainer3.SplitterDistance = 207;
            this.splitContainer3.SplitterWidth = 10;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "In Process ";
            // 
            // dGVInProcess
            // 
            this.dGVInProcess.AllowUserToAddRows = false;
            this.dGVInProcess.AllowUserToDeleteRows = false;
            this.dGVInProcess.AllowUserToResizeColumns = false;
            this.dGVInProcess.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(255)))), ((int)(((byte)(238)))));
            this.dGVInProcess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVInProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGVInProcess.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.dGVInProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVInProcess.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVInProcess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dGVInProcess.ColumnHeadersHeight = 40;
            this.dGVInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVInProcess.DefaultCellStyle = dataGridViewCellStyle7;
            this.dGVInProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVInProcess.Location = new System.Drawing.Point(0, 40);
            this.dGVInProcess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dGVInProcess.Name = "dGVInProcess";
            this.dGVInProcess.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(255)))), ((int)(((byte)(212)))));
            this.dGVInProcess.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dGVInProcess.RowTemplate.Height = 40;
            this.dGVInProcess.Size = new System.Drawing.Size(917, 163);
            this.dGVInProcess.TabIndex = 3;
            this.dGVInProcess.TabStop = false;
            this.dGVInProcess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVInProcess.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVInProcess.Sorted += new System.EventHandler(this.dGV_Sorted);
            this.dGVInProcess.MouseEnter += new System.EventHandler(this.dGV_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Completed In Last 2 Days";
            // 
            // dGVCompleted
            // 
            this.dGVCompleted.AllowUserToAddRows = false;
            this.dGVCompleted.AllowUserToDeleteRows = false;
            this.dGVCompleted.AllowUserToResizeColumns = false;
            this.dGVCompleted.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(215)))));
            this.dGVCompleted.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dGVCompleted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGVCompleted.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.dGVCompleted.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVCompleted.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVCompleted.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dGVCompleted.ColumnHeadersHeight = 40;
            this.dGVCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVCompleted.DefaultCellStyle = dataGridViewCellStyle11;
            this.dGVCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVCompleted.Location = new System.Drawing.Point(0, 40);
            this.dGVCompleted.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dGVCompleted.Name = "dGVCompleted";
            this.dGVCompleted.ReadOnly = true;
            this.dGVCompleted.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dGVCompleted.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dGVCompleted.RowTemplate.Height = 40;
            this.dGVCompleted.Size = new System.Drawing.Size(917, 301);
            this.dGVCompleted.TabIndex = 3;
            this.dGVCompleted.TabStop = false;
            this.dGVCompleted.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVCompleted.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVCompleted.Sorted += new System.EventHandler(this.dGV_Sorted);
            this.dGVCompleted.MouseEnter += new System.EventHandler(this.dGV_MouseEnter);
            // 
            // pBLogo
            // 
            this.pBLogo.Image = global::Cleaning_Scheduler_Interface.Properties.Resources.fei_company_logo;
            this.pBLogo.Location = new System.Drawing.Point(12, 496);
            this.pBLogo.Name = "pBLogo";
            this.pBLogo.Size = new System.Drawing.Size(240, 80);
            this.pBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBLogo.TabIndex = 28;
            this.pBLogo.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuit.BackColor = System.Drawing.Color.Gray;
            this.btnQuit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.Black;
            this.btnQuit.Location = new System.Drawing.Point(31, 694);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(5);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(61, 60);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // btnCleaning
            // 
            this.btnCleaning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCleaning.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCleaning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCleaning.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleaning.ForeColor = System.Drawing.Color.DimGray;
            this.btnCleaning.Location = new System.Drawing.Point(36, 617);
            this.btnCleaning.Margin = new System.Windows.Forms.Padding(5);
            this.btnCleaning.Name = "btnCleaning";
            this.btnCleaning.Size = new System.Drawing.Size(61, 60);
            this.btnCleaning.TabIndex = 4;
            this.btnCleaning.Text = "Admin Control";
            this.btnCleaning.UseVisualStyleBackColor = true;
            this.btnCleaning.Click += new System.EventHandler(this.btnCleaning_Click);
            // 
            // panelLegend
            // 
            this.panelLegend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLegend.Controls.Add(this.label7);
            this.panelLegend.Controls.Add(this.panelCRR);
            this.panelLegend.Controls.Add(this.label4);
            this.panelLegend.Controls.Add(this.panelHot);
            this.panelLegend.ForeColor = System.Drawing.Color.Black;
            this.panelLegend.Location = new System.Drawing.Point(0, 247);
            this.panelLegend.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(262, 243);
            this.panelLegend.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(119, 146);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 70);
            this.label7.TabIndex = 27;
            this.label7.Text = "Cleanroom Ready";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelCRR
            // 
            this.panelCRR.BackColor = System.Drawing.Color.Green;
            this.panelCRR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCRR.Location = new System.Drawing.Point(10, 146);
            this.panelCRR.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelCRR.Name = "panelCRR";
            this.panelCRR.Size = new System.Drawing.Size(94, 70);
            this.panelCRR.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 70);
            this.label4.TabIndex = 24;
            this.label4.Text = "High Priority";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHot
            // 
            this.panelHot.BackColor = System.Drawing.Color.Red;
            this.panelHot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHot.Location = new System.Drawing.Point(10, 28);
            this.panelHot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelHot.Name = "panelHot";
            this.panelHot.Size = new System.Drawing.Size(94, 70);
            this.panelHot.TabIndex = 23;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistory.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.DimGray;
            this.btnHistory.Location = new System.Drawing.Point(36, 556);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(5);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(61, 60);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnColumnRequest);
            this.pnlButtons.Controls.Add(this.btnPartRequest);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(268, 233);
            this.pnlButtons.TabIndex = 22;
            // 
            // btnColumnRequest
            // 
            this.btnColumnRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnColumnRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnColumnRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColumnRequest.ForeColor = System.Drawing.Color.Navy;
            this.btnColumnRequest.Location = new System.Drawing.Point(10, 10);
            this.btnColumnRequest.Margin = new System.Windows.Forms.Padding(0);
            this.btnColumnRequest.Name = "btnColumnRequest";
            this.btnColumnRequest.Size = new System.Drawing.Size(190, 62);
            this.btnColumnRequest.TabIndex = 1;
            this.btnColumnRequest.Text = "Request Column / Gun Cleaning";
            this.btnColumnRequest.UseVisualStyleBackColor = true;
            this.btnColumnRequest.Click += new System.EventHandler(this.buttonColumnRequest_Click);
            // 
            // btnPartRequest
            // 
            this.btnPartRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPartRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPartRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartRequest.ForeColor = System.Drawing.Color.Navy;
            this.btnPartRequest.Location = new System.Drawing.Point(10, 136);
            this.btnPartRequest.Margin = new System.Windows.Forms.Padding(0);
            this.btnPartRequest.Name = "btnPartRequest";
            this.btnPartRequest.Size = new System.Drawing.Size(246, 85);
            this.btnPartRequest.TabIndex = 2;
            this.btnPartRequest.Text = "Request Part Cleaning";
            this.btnPartRequest.UseVisualStyleBackColor = true;
            this.btnPartRequest.Click += new System.EventHandler(this.btnPartRequest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1219, 784);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Cleaning Scheduler Interface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).EndInit();
            this.panelLegend.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dGVInProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dGVCompleted;
        private System.ComponentModel.BackgroundWorker bGWorkerFillTables;
        private System.Windows.Forms.Button btnColumnRequest;
        private System.Windows.Forms.Button btnCleaning;
        private System.Windows.Forms.Button btnPartRequest;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel panelHot;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dGVQueue;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelCRR;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.PictureBox pBLogo;
    }
}

