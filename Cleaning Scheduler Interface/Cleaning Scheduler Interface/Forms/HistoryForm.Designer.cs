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
            this.btnBack = new System.Windows.Forms.Button();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.gBHot = new System.Windows.Forms.GroupBox();
            this.rBHotNo = new System.Windows.Forms.RadioButton();
            this.rBHotYes = new System.Windows.Forms.RadioButton();
            this.rBHotBoth = new System.Windows.Forms.RadioButton();
            this.gBCRR = new System.Windows.Forms.GroupBox();
            this.rBCRRNo = new System.Windows.Forms.RadioButton();
            this.rBCRRYes = new System.Windows.Forms.RadioButton();
            this.rBCRRBoth = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dTPickerStartedFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dTPickerStartedTo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRequestor = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dTPickerFinishedFrom = new System.Windows.Forms.DateTimePicker();
            this.dTPickerFinishedTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPartFilter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bGWorkerHistoryLoad = new System.ComponentModel.BackgroundWorker();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dGVHistory = new System.Windows.Forms.DataGridView();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.gBHot.SuspendLayout();
            this.gBCRR.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDGV.SuspendLayout();
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
            this.dTPickerRequestedFrom.Location = new System.Drawing.Point(66, 25);
            this.dTPickerRequestedFrom.Name = "dTPickerRequestedFrom";
            this.dTPickerRequestedFrom.Size = new System.Drawing.Size(155, 32);
            this.dTPickerRequestedFrom.TabIndex = 1;
            this.dTPickerRequestedFrom.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dTPickerRequestedFrom.CloseUp += new System.EventHandler(this.dTPicker_CloseUp);
            this.dTPickerRequestedFrom.DropDown += new System.EventHandler(this.dTPicker_DropDown);
            this.dTPickerRequestedFrom.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // dTPickerRequestedTo
            // 
            this.dTPickerRequestedTo.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerRequestedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerRequestedTo.Location = new System.Drawing.Point(66, 63);
            this.dTPickerRequestedTo.MinDate = new System.DateTime(2016, 3, 21, 0, 0, 0, 0);
            this.dTPickerRequestedTo.Name = "dTPickerRequestedTo";
            this.dTPickerRequestedTo.Size = new System.Drawing.Size(155, 32);
            this.dTPickerRequestedTo.TabIndex = 2;
            this.dTPickerRequestedTo.CloseUp += new System.EventHandler(this.dTPicker_CloseUp);
            this.dTPickerRequestedTo.DropDown += new System.EventHandler(this.dTPicker_DropDown);
            this.dTPickerRequestedTo.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "From:";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "To:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dTPickerRequestedFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dTPickerRequestedTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 335);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(238, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date Requested";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBack.BackColor = System.Drawing.Color.DarkGray;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnBack.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.DimGray;
            this.btnBack.Location = new System.Drawing.Point(894, 840);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(262, 60);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Admin Control";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // panelFilter
            // 
            this.panelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFilter.Controls.Add(this.gBHot);
            this.panelFilter.Controls.Add(this.gBCRR);
            this.panelFilter.Controls.Add(this.label10);
            this.panelFilter.Controls.Add(this.buttonReset);
            this.panelFilter.Controls.Add(this.groupBox3);
            this.panelFilter.Controls.Add(this.label4);
            this.panelFilter.Controls.Add(this.comboBoxRequestor);
            this.panelFilter.Controls.Add(this.groupBox2);
            this.panelFilter.Controls.Add(this.comboBoxPartFilter);
            this.panelFilter.Controls.Add(this.groupBox1);
            this.panelFilter.Controls.Add(this.label5);
            this.panelFilter.Location = new System.Drawing.Point(894, 13);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(10);
            this.panelFilter.Size = new System.Drawing.Size(262, 752);
            this.panelFilter.TabIndex = 24;
            // 
            // gBHot
            // 
            this.gBHot.Controls.Add(this.rBHotNo);
            this.gBHot.Controls.Add(this.rBHotYes);
            this.gBHot.Controls.Add(this.rBHotBoth);
            this.gBHot.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBHot.Location = new System.Drawing.Point(10, 263);
            this.gBHot.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.gBHot.Name = "gBHot";
            this.gBHot.Size = new System.Drawing.Size(238, 59);
            this.gBHot.TabIndex = 35;
            this.gBHot.TabStop = false;
            this.gBHot.Text = "High Priority";
            // 
            // rBHotNo
            // 
            this.rBHotNo.AutoSize = true;
            this.rBHotNo.Location = new System.Drawing.Point(169, 26);
            this.rBHotNo.Name = "rBHotNo";
            this.rBHotNo.Size = new System.Drawing.Size(53, 29);
            this.rBHotNo.TabIndex = 2;
            this.rBHotNo.Text = "No";
            this.rBHotNo.UseVisualStyleBackColor = true;
            this.rBHotNo.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            // 
            // rBHotYes
            // 
            this.rBHotYes.AutoSize = true;
            this.rBHotYes.Location = new System.Drawing.Point(99, 26);
            this.rBHotYes.Name = "rBHotYes";
            this.rBHotYes.Size = new System.Drawing.Size(61, 29);
            this.rBHotYes.TabIndex = 1;
            this.rBHotYes.Text = "Yes";
            this.rBHotYes.UseVisualStyleBackColor = true;
            this.rBHotYes.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            // 
            // rBHotBoth
            // 
            this.rBHotBoth.AutoSize = true;
            this.rBHotBoth.Checked = true;
            this.rBHotBoth.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBHotBoth.Location = new System.Drawing.Point(21, 26);
            this.rBHotBoth.Name = "rBHotBoth";
            this.rBHotBoth.Size = new System.Drawing.Size(64, 27);
            this.rBHotBoth.TabIndex = 0;
            this.rBHotBoth.TabStop = true;
            this.rBHotBoth.Text = "Both";
            this.rBHotBoth.UseVisualStyleBackColor = true;
            this.rBHotBoth.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            // 
            // gBCRR
            // 
            this.gBCRR.Controls.Add(this.rBCRRNo);
            this.gBCRR.Controls.Add(this.rBCRRYes);
            this.gBCRR.Controls.Add(this.rBCRRBoth);
            this.gBCRR.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBCRR.Location = new System.Drawing.Point(10, 191);
            this.gBCRR.Name = "gBCRR";
            this.gBCRR.Size = new System.Drawing.Size(238, 59);
            this.gBCRR.TabIndex = 7;
            this.gBCRR.TabStop = false;
            this.gBCRR.Text = "Cleanroom Ready";
            // 
            // rBCRRNo
            // 
            this.rBCRRNo.AutoSize = true;
            this.rBCRRNo.Location = new System.Drawing.Point(169, 26);
            this.rBCRRNo.Name = "rBCRRNo";
            this.rBCRRNo.Size = new System.Drawing.Size(53, 29);
            this.rBCRRNo.TabIndex = 2;
            this.rBCRRNo.Text = "No";
            this.rBCRRNo.UseVisualStyleBackColor = true;
            this.rBCRRNo.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            // 
            // rBCRRYes
            // 
            this.rBCRRYes.AutoSize = true;
            this.rBCRRYes.Location = new System.Drawing.Point(99, 26);
            this.rBCRRYes.Name = "rBCRRYes";
            this.rBCRRYes.Size = new System.Drawing.Size(61, 29);
            this.rBCRRYes.TabIndex = 1;
            this.rBCRRYes.Text = "Yes";
            this.rBCRRYes.UseVisualStyleBackColor = true;
            this.rBCRRYes.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            // 
            // rBCRRBoth
            // 
            this.rBCRRBoth.AutoSize = true;
            this.rBCRRBoth.Checked = true;
            this.rBCRRBoth.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBCRRBoth.Location = new System.Drawing.Point(21, 26);
            this.rBCRRBoth.Name = "rBCRRBoth";
            this.rBCRRBoth.Size = new System.Drawing.Size(64, 27);
            this.rBCRRBoth.TabIndex = 0;
            this.rBCRRBoth.TabStop = true;
            this.rBCRRBoth.Text = "Both";
            this.rBCRRBoth.UseVisualStyleBackColor = true;
            this.rBCRRBoth.CheckedChanged += new System.EventHandler(this.rBCRRHot_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(13, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 25);
            this.label10.TabIndex = 33;
            this.label10.Text = "Requestor:";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(128)))));
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonReset.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.ForeColor = System.Drawing.Color.Navy;
            this.buttonReset.Image = global::Cleaning_Scheduler_Interface.Properties.Resources.refresh;
            this.buttonReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReset.Location = new System.Drawing.Point(10, 678);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(0);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Padding = new System.Windows.Forms.Padding(10);
            this.buttonReset.Size = new System.Drawing.Size(238, 60);
            this.buttonReset.TabIndex = 25;
            this.buttonReset.Text = "    Reset Filters";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dTPickerStartedFrom);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dTPickerStartedTo);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 450);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox3.Size = new System.Drawing.Size(238, 102);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Date Started";
            // 
            // dTPickerStartedFrom
            // 
            this.dTPickerStartedFrom.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerStartedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerStartedFrom.Location = new System.Drawing.Point(66, 25);
            this.dTPickerStartedFrom.Name = "dTPickerStartedFrom";
            this.dTPickerStartedFrom.Size = new System.Drawing.Size(155, 32);
            this.dTPickerStartedFrom.TabIndex = 1;
            this.dTPickerStartedFrom.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dTPickerStartedFrom.CloseUp += new System.EventHandler(this.dTPicker_CloseUp);
            this.dTPickerStartedFrom.DropDown += new System.EventHandler(this.dTPicker_DropDown);
            this.dTPickerStartedFrom.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "To:";
            // 
            // dTPickerStartedTo
            // 
            this.dTPickerStartedTo.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerStartedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerStartedTo.Location = new System.Drawing.Point(66, 63);
            this.dTPickerStartedTo.MinDate = new System.DateTime(2016, 3, 21, 0, 0, 0, 0);
            this.dTPickerStartedTo.Name = "dTPickerStartedTo";
            this.dTPickerStartedTo.Size = new System.Drawing.Size(155, 32);
            this.dTPickerStartedTo.TabIndex = 2;
            this.dTPickerStartedTo.CloseUp += new System.EventHandler(this.dTPicker_CloseUp);
            this.dTPickerStartedTo.DropDown += new System.EventHandler(this.dTPicker_DropDown);
            this.dTPickerStartedTo.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 23);
            this.label9.TabIndex = 5;
            this.label9.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 30);
            this.label4.TabIndex = 24;
            this.label4.Text = "Filter";
            // 
            // comboBoxRequestor
            // 
            this.comboBoxRequestor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxRequestor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRequestor.DropDownHeight = 506;
            this.comboBoxRequestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRequestor.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRequestor.FormattingEnabled = true;
            this.comboBoxRequestor.IntegralHeight = false;
            this.comboBoxRequestor.Location = new System.Drawing.Point(10, 147);
            this.comboBoxRequestor.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.comboBoxRequestor.Name = "comboBoxRequestor";
            this.comboBoxRequestor.Size = new System.Drawing.Size(238, 31);
            this.comboBoxRequestor.TabIndex = 34;
            this.comboBoxRequestor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dTPickerFinishedFrom);
            this.groupBox2.Controls.Add(this.dTPickerFinishedTo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 565);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(238, 102);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Finished";
            // 
            // dTPickerFinishedFrom
            // 
            this.dTPickerFinishedFrom.CalendarFont = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerFinishedFrom.CalendarForeColor = System.Drawing.Color.Navy;
            this.dTPickerFinishedFrom.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dTPickerFinishedFrom.CustomFormat = "M / dd / yyyy";
            this.dTPickerFinishedFrom.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerFinishedFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPickerFinishedFrom.Location = new System.Drawing.Point(66, 25);
            this.dTPickerFinishedFrom.Name = "dTPickerFinishedFrom";
            this.dTPickerFinishedFrom.Size = new System.Drawing.Size(155, 32);
            this.dTPickerFinishedFrom.TabIndex = 7;
            this.dTPickerFinishedFrom.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dTPickerFinishedFrom.CloseUp += new System.EventHandler(this.dTPicker_CloseUp);
            this.dTPickerFinishedFrom.DropDown += new System.EventHandler(this.dTPicker_DropDown);
            // 
            // dTPickerFinishedTo
            // 
            this.dTPickerFinishedTo.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPickerFinishedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPickerFinishedTo.Location = new System.Drawing.Point(66, 63);
            this.dTPickerFinishedTo.MinDate = new System.DateTime(2016, 3, 21, 0, 0, 0, 0);
            this.dTPickerFinishedTo.Name = "dTPickerFinishedTo";
            this.dTPickerFinishedTo.Size = new System.Drawing.Size(155, 32);
            this.dTPickerFinishedTo.TabIndex = 2;
            this.dTPickerFinishedTo.CloseUp += new System.EventHandler(this.dTPicker_CloseUp);
            this.dTPickerFinishedTo.DropDown += new System.EventHandler(this.dTPicker_DropDown);
            this.dTPickerFinishedTo.Enter += new System.EventHandler(this.dTPicker_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "From:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "To:";
            // 
            // comboBoxPartFilter
            // 
            this.comboBoxPartFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPartFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPartFilter.DropDownHeight = 506;
            this.comboBoxPartFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPartFilter.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPartFilter.FormattingEnabled = true;
            this.comboBoxPartFilter.IntegralHeight = false;
            this.comboBoxPartFilter.Location = new System.Drawing.Point(10, 73);
            this.comboBoxPartFilter.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.comboBoxPartFilter.Name = "comboBoxPartFilter";
            this.comboBoxPartFilter.Size = new System.Drawing.Size(238, 31);
            this.comboBoxPartFilter.TabIndex = 30;
            this.comboBoxPartFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Part #:";
            // 
            // bGWorkerHistoryLoad
            // 
            this.bGWorkerHistoryLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerHistoryLoad_DoWork);
            this.bGWorkerHistoryLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerHistoryLoad_RunWorkerCompleted);
            // 
            // panelDGV
            // 
            this.panelDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDGV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDGV.Controls.Add(this.label3);
            this.panelDGV.Controls.Add(this.dGVHistory);
            this.panelDGV.Location = new System.Drawing.Point(10, 13);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            this.panelDGV.Size = new System.Drawing.Size(871, 951);
            this.panelDGV.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Completed Requests";
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
            this.dGVHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGVHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
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
            this.dGVHistory.Location = new System.Drawing.Point(10, 40);
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
            this.dGVHistory.Size = new System.Drawing.Size(847, 897);
            this.dGVHistory.TabIndex = 27;
            this.dGVHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            this.dGVHistory.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dGV_CellPainting);
            this.dGVHistory.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dGV_Scroll);
            this.dGVHistory.Sorted += new System.EventHandler(this.dGVHistory_Sorted);
            this.dGVHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dGVHistory_MouseDown);
            this.dGVHistory.MouseEnter += new System.EventHandler(this.dGV_MouseEnter);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuit.BackColor = System.Drawing.Color.Gray;
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.Black;
            this.btnQuit.Location = new System.Drawing.Point(894, 904);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(262, 60);
            this.btnQuit.TabIndex = 26;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            // 
            // btnMain
            // 
            this.btnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMain.BackColor = System.Drawing.Color.DarkGray;
            this.btnMain.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMain.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.ForeColor = System.Drawing.Color.DimGray;
            this.btnMain.Location = new System.Drawing.Point(894, 774);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(262, 60);
            this.btnMain.TabIndex = 27;
            this.btnMain.Text = "Main Screen";
            this.btnMain.UseVisualStyleBackColor = true;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1169, 974);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelDGV);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.gBHot.ResumeLayout(false);
            this.gBHot.PerformLayout();
            this.gBCRR.ResumeLayout(false);
            this.gBCRR.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelDGV.ResumeLayout(false);
            this.panelDGV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dTPickerRequestedFrom;
        private System.Windows.Forms.DateTimePicker dTPickerRequestedTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPartFilter;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.Panel panelDGV;
        private System.Windows.Forms.DataGridView dGVHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.DateTimePicker dTPickerFinishedFrom;
        private System.Windows.Forms.GroupBox gBHot;
        private System.Windows.Forms.RadioButton rBHotNo;
        private System.Windows.Forms.RadioButton rBHotYes;
        private System.Windows.Forms.RadioButton rBHotBoth;
        private System.Windows.Forms.GroupBox gBCRR;
        private System.Windows.Forms.RadioButton rBCRRNo;
        private System.Windows.Forms.RadioButton rBCRRYes;
        private System.Windows.Forms.RadioButton rBCRRBoth;
    }
}