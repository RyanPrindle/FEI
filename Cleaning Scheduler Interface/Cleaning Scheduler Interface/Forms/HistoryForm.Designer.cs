namespace Cleaning_Scheduler_Interface
{
    partial class HistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            this.dTPickerRequestedFrom = new System.Windows.Forms.DateTimePicker();
            this.dTPickerRequestedTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboBoxRequestor = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dTPickerStartedFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dTPickerStartedTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dTPickerFinishedFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dTPickerFinishedTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPartFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bGWorkerHistoryLoad = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dGVHistory = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dTPickerRequestedFrom
            // 
            this.dTPickerRequestedFrom.CalendarFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerRequestedFrom.CalendarForeColor = System.Drawing.Color.Navy;
            this.dTPickerRequestedFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dTPickerRequestedFrom.CustomFormat = "M / dd / yyyy";
            this.dTPickerRequestedFrom.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerRequestedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPickerRequestedFrom.Location = new System.Drawing.Point(66, 28);
            this.dTPickerRequestedFrom.Name = "dTPickerRequestedFrom";
            this.dTPickerRequestedFrom.Size = new System.Drawing.Size(155, 32);
            this.dTPickerRequestedFrom.TabIndex = 1;
            this.dTPickerRequestedFrom.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            this.dTPickerRequestedFrom.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // dTPickerRequestedTo
            // 
            this.dTPickerRequestedTo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerRequestedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerRequestedTo.Location = new System.Drawing.Point(66, 63);
            this.dTPickerRequestedTo.MinDate = new System.DateTime(2016, 3, 21, 0, 0, 0, 0);
            this.dTPickerRequestedTo.Name = "dTPickerRequestedTo";
            this.dTPickerRequestedTo.Size = new System.Drawing.Size(155, 29);
            this.dTPickerRequestedTo.TabIndex = 2;
            this.dTPickerRequestedTo.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            this.dTPickerRequestedTo.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "From:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "To:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dTPickerRequestedFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dTPickerRequestedTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(238, 112);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Requested";
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBack.BackColor = System.Drawing.Color.DarkGray;
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonBack.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.Color.Black;
            this.buttonBack.Location = new System.Drawing.Point(1353, 506);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(228, 39);
            this.buttonBack.TabIndex = 23;
            this.buttonBack.Text = "Admin Control";
            this.buttonBack.UseVisualStyleBackColor = false;
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFilter.Controls.Add(this.label10);
            this.panelFilter.Controls.Add(this.buttonReset);
            this.panelFilter.Controls.Add(this.comboBoxRequestor);
            this.panelFilter.Controls.Add(this.groupBox3);
            this.panelFilter.Controls.Add(this.groupBox2);
            this.panelFilter.Controls.Add(this.label5);
            this.panelFilter.Controls.Add(this.comboBoxPartFilter);
            this.panelFilter.Controls.Add(this.groupBox1);
            this.panelFilter.Location = new System.Drawing.Point(10, 506);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10);
            this.panelFilter.Size = new System.Drawing.Size(1330, 136);
            this.panelFilter.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(779, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 23);
            this.label10.TabIndex = 33;
            this.label10.Text = "Requestor:";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonReset.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.ForeColor = System.Drawing.Color.Navy;
            this.buttonReset.Location = new System.Drawing.Point(1101, 10);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Padding = new System.Windows.Forms.Padding(10);
            this.buttonReset.Size = new System.Drawing.Size(215, 112);
            this.buttonReset.TabIndex = 25;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // comboBoxRequestor
            // 
            this.comboBoxRequestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxRequestor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxRequestor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRequestor.DropDownHeight = 506;
            this.comboBoxRequestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRequestor.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRequestor.FormattingEnabled = true;
            this.comboBoxRequestor.IntegralHeight = false;
            this.comboBoxRequestor.Location = new System.Drawing.Point(879, 77);
            this.comboBoxRequestor.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxRequestor.Name = "comboBoxRequestor";
            this.comboBoxRequestor.Size = new System.Drawing.Size(211, 31);
            this.comboBoxRequestor.TabIndex = 34;
            this.comboBoxRequestor.SelectedIndexChanged += new System.EventHandler(this.Filter_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.dTPickerStartedFrom);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dTPickerStartedTo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(257, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(235, 112);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Date Started";
            // 
            // dTPickerStartedFrom
            // 
            this.dTPickerStartedFrom.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerStartedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerStartedFrom.Location = new System.Drawing.Point(66, 27);
            this.dTPickerStartedFrom.Name = "dTPickerStartedFrom";
            this.dTPickerStartedFrom.Size = new System.Drawing.Size(155, 29);
            this.dTPickerStartedFrom.TabIndex = 1;
            this.dTPickerStartedFrom.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            this.dTPickerStartedFrom.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "To:";
            // 
            // dTPickerStartedTo
            // 
            this.dTPickerStartedTo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerStartedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerStartedTo.Location = new System.Drawing.Point(66, 63);
            this.dTPickerStartedTo.MinDate = new System.DateTime(2016, 3, 21, 0, 0, 0, 0);
            this.dTPickerStartedTo.Name = "dTPickerStartedTo";
            this.dTPickerStartedTo.Size = new System.Drawing.Size(155, 29);
            this.dTPickerStartedTo.TabIndex = 2;
            this.dTPickerStartedTo.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            this.dTPickerStartedTo.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "From:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dTPickerFinishedFrom);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dTPickerFinishedTo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(507, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(235, 112);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Finished";
            // 
            // dTPickerFinishedFrom
            // 
            this.dTPickerFinishedFrom.Checked = false;
            this.dTPickerFinishedFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.dTPickerFinishedFrom.CustomFormat = "";
            this.dTPickerFinishedFrom.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerFinishedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerFinishedFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dTPickerFinishedFrom.Location = new System.Drawing.Point(66, 28);
            this.dTPickerFinishedFrom.Name = "dTPickerFinishedFrom";
            this.dTPickerFinishedFrom.Size = new System.Drawing.Size(155, 29);
            this.dTPickerFinishedFrom.TabIndex = 1;
            this.dTPickerFinishedFrom.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            this.dTPickerFinishedFrom.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "To:";
            // 
            // dTPickerFinishedTo
            // 
            this.dTPickerFinishedTo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerFinishedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerFinishedTo.Location = new System.Drawing.Point(66, 63);
            this.dTPickerFinishedTo.MinDate = new System.DateTime(2016, 3, 21, 0, 0, 0, 0);
            this.dTPickerFinishedTo.Name = "dTPickerFinishedTo";
            this.dTPickerFinishedTo.Size = new System.Drawing.Size(155, 29);
            this.dTPickerFinishedTo.TabIndex = 2;
            this.dTPickerFinishedTo.ValueChanged += new System.EventHandler(this.Filter_ValueChanged);
            this.dTPickerFinishedTo.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "From:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(763, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Part Number:";
            // 
            // comboBoxPartFilter
            // 
            this.comboBoxPartFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxPartFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPartFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPartFilter.DropDownHeight = 506;
            this.comboBoxPartFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartFilter.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPartFilter.FormattingEnabled = true;
            this.comboBoxPartFilter.IntegralHeight = false;
            this.comboBoxPartFilter.Location = new System.Drawing.Point(878, 24);
            this.comboBoxPartFilter.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxPartFilter.Name = "comboBoxPartFilter";
            this.comboBoxPartFilter.Size = new System.Drawing.Size(212, 31);
            this.comboBoxPartFilter.TabIndex = 30;
            this.comboBoxPartFilter.SelectedIndexChanged += new System.EventHandler(this.Filter_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Filter";
            // 
            // bGWorkerHistoryLoad
            // 
            this.bGWorkerHistoryLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerHistoryLoad_DoWork);
            this.bGWorkerHistoryLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerHistoryLoad_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dGVHistory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(10, 13);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1571, 462);
            this.panel2.TabIndex = 25;
            // 
            // dGVHistory
            // 
            this.dGVHistory.AllowUserToAddRows = false;
            this.dGVHistory.AllowUserToDeleteRows = false;
            this.dGVHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(202)))));
            this.dGVHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGVHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dGVHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVHistory.ColumnHeadersHeight = 40;
            this.dGVHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGVHistory.Location = new System.Drawing.Point(12, 37);
            this.dGVHistory.Margin = new System.Windows.Forms.Padding(0);
            this.dGVHistory.Name = "dGVHistory";
            this.dGVHistory.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dGVHistory.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVHistory.RowTemplate.Height = 40;
            this.dGVHistory.Size = new System.Drawing.Size(1542, 408);
            this.dGVHistory.TabIndex = 27;
            this.dGVHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVHistory.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVHistory.Sorted += new System.EventHandler(this.dGVHistory_Sorted);
            this.dGVHistory.MouseEnter += new System.EventHandler(this.dGV_MouseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Completed Requests";
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuit.BackColor = System.Drawing.Color.Gray;
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.ForeColor = System.Drawing.Color.Black;
            this.buttonQuit.Location = new System.Drawing.Point(1353, 603);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(228, 39);
            this.buttonQuit.TabIndex = 26;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = false;
            // 
            // btnMain
            // 
            this.btnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMain.BackColor = System.Drawing.Color.DarkGray;
            this.btnMain.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMain.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.ForeColor = System.Drawing.Color.Black;
            this.btnMain.Location = new System.Drawing.Point(1353, 555);
            this.btnMain.Margin = new System.Windows.Forms.Padding(0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(228, 38);
            this.btnMain.TabIndex = 27;
            this.btnMain.Text = "Main Screen";
            this.btnMain.UseVisualStyleBackColor = false;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1594, 655);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoryForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Completed Clean Request History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dTPickerRequestedFrom;
        private System.Windows.Forms.DateTimePicker dTPickerRequestedTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPartFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dTPickerFinishedFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dTPickerFinishedTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dTPickerStartedFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dTPickerStartedTo;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker bGWorkerHistoryLoad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxRequestor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dGVHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button btnMain;
    }
}