namespace Cleaning_Scheduler_Interface
{
    partial class PartRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartRequestForm));
            this.btnPartCleanRequest = new System.Windows.Forms.Button();
            this.bGWorkerGetData = new System.ComponentModel.BackgroundWorker();
            this.bGWorkerAddContact = new System.ComponentModel.BackgroundWorker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.errorProviderPartRequestForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxRequestor = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtnNonStandard = new System.Windows.Forms.RadioButton();
            this.rBtnStandard = new System.Windows.Forms.RadioButton();
            this.pnlStandard = new System.Windows.Forms.Panel();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPartDescription = new System.Windows.Forms.Label();
            this.panelNonStandard = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEnterDescription = new System.Windows.Forms.Label();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxHot = new System.Windows.Forms.CheckBox();
            this.groupBoxCR = new System.Windows.Forms.GroupBox();
            this.radioButtonCRNo = new System.Windows.Forms.RadioButton();
            this.radioButtonCRYes = new System.Windows.Forms.RadioButton();
            this.gBoxStockLocation = new System.Windows.Forms.GroupBox();
            this.radioButtonBulk = new System.Windows.Forms.RadioButton();
            this.radioButtonCage = new System.Windows.Forms.RadioButton();
            this.textBoxPO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.textBoxInstructions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxContact = new System.Windows.Forms.ComboBox();
            this.bGWorkerAddPart = new System.ComponentModel.BackgroundWorker();
            this.toolTipPartRequest = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPartRequestForm)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlStandard.SuspendLayout();
            this.panelNonStandard.SuspendLayout();
            this.groupBoxCR.SuspendLayout();
            this.gBoxStockLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPartCleanRequest
            // 
            this.btnPartCleanRequest.AutoSize = true;
            this.btnPartCleanRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPartCleanRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartCleanRequest.Location = new System.Drawing.Point(268, 12);
            this.btnPartCleanRequest.Name = "btnPartCleanRequest";
            this.btnPartCleanRequest.Size = new System.Drawing.Size(236, 35);
            this.btnPartCleanRequest.TabIndex = 13;
            this.btnPartCleanRequest.Text = "Submit Cleaning Request";
            this.btnPartCleanRequest.UseVisualStyleBackColor = true;
            this.btnPartCleanRequest.Click += new System.EventHandler(this.btnPartCleanRequest_Click);
            // 
            // bGWorkerAddContact
            // 
            this.bGWorkerAddContact.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerAddContact_DoWork);
            this.bGWorkerAddContact.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerAddContact_RunWorkerCompleted);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonCancel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 12);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(222, 35);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // errorProviderPartRequestForm
            // 
            this.errorProviderPartRequestForm.ContainerControl = this;
            // 
            // textBoxRequestor
            // 
            this.textBoxRequestor.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProviderPartRequestForm.SetIconAlignment(this.textBoxRequestor, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textBoxRequestor.Location = new System.Drawing.Point(121, 9);
            this.textBoxRequestor.Name = "textBoxRequestor";
            this.textBoxRequestor.Size = new System.Drawing.Size(207, 29);
            this.textBoxRequestor.TabIndex = 26;
            this.textBoxRequestor.TextChanged += new System.EventHandler(this.textBoxRequestor_TextChanged);
            this.textBoxRequestor.MouseEnter += new System.EventHandler(this.textBoxRequestor_MouseEnter);
            this.textBoxRequestor.MouseLeave += new System.EventHandler(this.textBoxRequestor_MouseLeave);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProviderPartRequestForm.SetIconAlignment(this.textBoxDescription, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textBoxDescription.Location = new System.Drawing.Point(107, 10);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(210, 29);
            this.textBoxDescription.TabIndex = 30;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.btnPartCleanRequest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 526);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(518, 62);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.textBoxSerialNumber);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxRequestor);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.checkBoxHot);
            this.panel2.Controls.Add(this.groupBoxCR);
            this.panel2.Controls.Add(this.textBoxPO);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelInstructions);
            this.panel2.Controls.Add(this.textBoxInstructions);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.numericUpDownQty);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxContact);
            this.panel2.Location = new System.Drawing.Point(10, 13);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(519, 500);
            this.panel2.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(14, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(491, 25);
            this.label5.TabIndex = 46;
            this.label5.Text = "*  Required";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtnNonStandard);
            this.groupBox1.Controls.Add(this.rBtnStandard);
            this.groupBox1.Controls.Add(this.pnlStandard);
            this.groupBox1.Controls.Add(this.panelNonStandard);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(13, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 100);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Number";
            // 
            // rBtnNonStandard
            // 
            this.rBtnNonStandard.AutoSize = true;
            this.rBtnNonStandard.ForeColor = System.Drawing.Color.Black;
            this.rBtnNonStandard.Location = new System.Drawing.Point(9, 63);
            this.rBtnNonStandard.Name = "rBtnNonStandard";
            this.rBtnNonStandard.Size = new System.Drawing.Size(147, 29);
            this.rBtnNonStandard.TabIndex = 31;
            this.rBtnNonStandard.Text = "Non-Standard";
            this.rBtnNonStandard.UseVisualStyleBackColor = true;
            // 
            // rBtnStandard
            // 
            this.rBtnStandard.AutoSize = true;
            this.rBtnStandard.Checked = true;
            this.rBtnStandard.ForeColor = System.Drawing.Color.Black;
            this.rBtnStandard.Location = new System.Drawing.Point(9, 31);
            this.rBtnStandard.Name = "rBtnStandard";
            this.rBtnStandard.Size = new System.Drawing.Size(107, 29);
            this.rBtnStandard.TabIndex = 30;
            this.rBtnStandard.TabStop = true;
            this.rBtnStandard.Text = "Standard";
            this.rBtnStandard.UseVisualStyleBackColor = true;
            this.rBtnStandard.CheckedChanged += new System.EventHandler(this.rBtnStandard_CheckedChanged);
            // 
            // pnlStandard
            // 
            this.pnlStandard.Controls.Add(this.comboBoxPart);
            this.pnlStandard.Controls.Add(this.label1);
            this.pnlStandard.Controls.Add(this.lblPartDescription);
            this.pnlStandard.Location = new System.Drawing.Point(149, 19);
            this.pnlStandard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStandard.Name = "pnlStandard";
            this.pnlStandard.Size = new System.Drawing.Size(339, 78);
            this.pnlStandard.TabIndex = 46;
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPart.DropDownHeight = 506;
            this.comboBoxPart.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.IntegralHeight = false;
            this.comboBoxPart.Location = new System.Drawing.Point(118, 8);
            this.comboBoxPart.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(199, 33);
            this.comboBoxPart.TabIndex = 28;
            this.comboBoxPart.SelectedIndexChanged += new System.EventHandler(this.comboBoxPart_SelectedIndexChanged);
            this.comboBoxPart.MouseEnter += new System.EventHandler(this.comboBoxPart_MouseEnter);
            this.comboBoxPart.MouseLeave += new System.EventHandler(this.comboBoxPart_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Part Number:";
            // 
            // lblPartDescription
            // 
            this.lblPartDescription.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartDescription.ForeColor = System.Drawing.Color.Black;
            this.lblPartDescription.Location = new System.Drawing.Point(3, 44);
            this.lblPartDescription.Name = "lblPartDescription";
            this.lblPartDescription.Size = new System.Drawing.Size(333, 29);
            this.lblPartDescription.TabIndex = 29;
            this.lblPartDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelNonStandard
            // 
            this.panelNonStandard.Controls.Add(this.textBoxDescription);
            this.panelNonStandard.Controls.Add(this.label4);
            this.panelNonStandard.Controls.Add(this.lblEnterDescription);
            this.panelNonStandard.Location = new System.Drawing.Point(149, 19);
            this.panelNonStandard.Margin = new System.Windows.Forms.Padding(0);
            this.panelNonStandard.Name = "panelNonStandard";
            this.panelNonStandard.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelNonStandard.Size = new System.Drawing.Size(339, 78);
            this.panelNonStandard.TabIndex = 47;
            this.panelNonStandard.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Description:";
            // 
            // lblEnterDescription
            // 
            this.lblEnterDescription.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterDescription.ForeColor = System.Drawing.Color.Black;
            this.lblEnterDescription.Location = new System.Drawing.Point(3, 44);
            this.lblEnterDescription.Name = "lblEnterDescription";
            this.lblEnterDescription.Size = new System.Drawing.Size(333, 29);
            this.lblEnterDescription.TabIndex = 29;
            this.lblEnterDescription.Text = "Enter A Short Description Above";
            this.lblEnterDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSerialNumber.Location = new System.Drawing.Point(226, 326);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(279, 29);
            this.textBoxSerialNumber.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(83, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 25);
            this.label8.TabIndex = 44;
            this.label8.Text = "Serial Number:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(13, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 42;
            this.label7.Text = "Requestor:";
            // 
            // checkBoxHot
            // 
            this.checkBoxHot.AutoSize = true;
            this.checkBoxHot.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHot.Location = new System.Drawing.Point(367, 13);
            this.checkBoxHot.Name = "checkBoxHot";
            this.checkBoxHot.Size = new System.Drawing.Size(137, 29);
            this.checkBoxHot.TabIndex = 37;
            this.checkBoxHot.Text = "High Priority";
            this.checkBoxHot.UseVisualStyleBackColor = true;
            // 
            // groupBoxCR
            // 
            this.groupBoxCR.Controls.Add(this.radioButtonCRNo);
            this.groupBoxCR.Controls.Add(this.radioButtonCRYes);
            this.groupBoxCR.Controls.Add(this.gBoxStockLocation);
            this.groupBoxCR.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCR.ForeColor = System.Drawing.Color.Maroon;
            this.groupBoxCR.Location = new System.Drawing.Point(13, 361);
            this.groupBoxCR.Name = "groupBoxCR";
            this.groupBoxCR.Size = new System.Drawing.Size(491, 108);
            this.groupBoxCR.TabIndex = 35;
            this.groupBoxCR.TabStop = false;
            this.groupBoxCR.Text = "Cleanroom Ready";
            // 
            // radioButtonCRNo
            // 
            this.radioButtonCRNo.AutoSize = true;
            this.radioButtonCRNo.ForeColor = System.Drawing.Color.Black;
            this.radioButtonCRNo.Location = new System.Drawing.Point(43, 29);
            this.radioButtonCRNo.Name = "radioButtonCRNo";
            this.radioButtonCRNo.Size = new System.Drawing.Size(53, 29);
            this.radioButtonCRNo.TabIndex = 9;
            this.radioButtonCRNo.Text = "No";
            this.radioButtonCRNo.UseVisualStyleBackColor = true;
            this.radioButtonCRNo.CheckedChanged += new System.EventHandler(this.radioButtonCR_CheckedChanged);
            // 
            // radioButtonCRYes
            // 
            this.radioButtonCRYes.AutoSize = true;
            this.radioButtonCRYes.ForeColor = System.Drawing.Color.Black;
            this.radioButtonCRYes.Location = new System.Drawing.Point(43, 64);
            this.radioButtonCRYes.Name = "radioButtonCRYes";
            this.radioButtonCRYes.Size = new System.Drawing.Size(61, 29);
            this.radioButtonCRYes.TabIndex = 8;
            this.radioButtonCRYes.Text = "Yes";
            this.radioButtonCRYes.UseVisualStyleBackColor = true;
            this.radioButtonCRYes.CheckedChanged += new System.EventHandler(this.radioButtonCR_CheckedChanged);
            this.radioButtonCRYes.Click += new System.EventHandler(this.radioButtonCRYes_Click);
            // 
            // gBoxStockLocation
            // 
            this.gBoxStockLocation.Controls.Add(this.radioButtonBulk);
            this.gBoxStockLocation.Controls.Add(this.radioButtonCage);
            this.gBoxStockLocation.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxStockLocation.ForeColor = System.Drawing.Color.Maroon;
            this.gBoxStockLocation.Location = new System.Drawing.Point(206, 21);
            this.gBoxStockLocation.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.gBoxStockLocation.Name = "gBoxStockLocation";
            this.gBoxStockLocation.Padding = new System.Windows.Forms.Padding(10);
            this.gBoxStockLocation.Size = new System.Drawing.Size(261, 72);
            this.gBoxStockLocation.TabIndex = 40;
            this.gBoxStockLocation.TabStop = false;
            this.gBoxStockLocation.Text = "Stock Location";
            // 
            // radioButtonBulk
            // 
            this.radioButtonBulk.AutoSize = true;
            this.radioButtonBulk.ForeColor = System.Drawing.Color.Black;
            this.radioButtonBulk.Location = new System.Drawing.Point(160, 30);
            this.radioButtonBulk.Name = "radioButtonBulk";
            this.radioButtonBulk.Size = new System.Drawing.Size(68, 29);
            this.radioButtonBulk.TabIndex = 11;
            this.radioButtonBulk.TabStop = true;
            this.radioButtonBulk.Text = "Bulk";
            this.radioButtonBulk.UseVisualStyleBackColor = true;
            // 
            // radioButtonCage
            // 
            this.radioButtonCage.AutoSize = true;
            this.radioButtonCage.ForeColor = System.Drawing.Color.Black;
            this.radioButtonCage.Location = new System.Drawing.Point(32, 30);
            this.radioButtonCage.Name = "radioButtonCage";
            this.radioButtonCage.Size = new System.Drawing.Size(78, 29);
            this.radioButtonCage.TabIndex = 10;
            this.radioButtonCage.TabStop = true;
            this.radioButtonCage.Text = "Cage ";
            this.radioButtonCage.UseVisualStyleBackColor = true;
            // 
            // textBoxPO
            // 
            this.textBoxPO.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPO.Location = new System.Drawing.Point(226, 291);
            this.textBoxPO.Name = "textBoxPO";
            this.textBoxPO.Size = new System.Drawing.Size(279, 29);
            this.textBoxPO.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(107, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "PO Number:";
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstructions.Location = new System.Drawing.Point(32, 155);
            this.labelInstructions.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(188, 25);
            this.labelInstructions.TabIndex = 38;
            this.labelInstructions.Text = "Special Instructions:";
            // 
            // textBoxInstructions
            // 
            this.textBoxInstructions.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstructions.Location = new System.Drawing.Point(226, 157);
            this.textBoxInstructions.Multiline = true;
            this.textBoxInstructions.Name = "textBoxInstructions";
            this.textBoxInstructions.Size = new System.Drawing.Size(279, 87);
            this.textBoxInstructions.TabIndex = 29;
            this.textBoxInstructions.MouseEnter += new System.EventHandler(this.textBoxInstructions_MouseEnter);
            this.textBoxInstructions.MouseLeave += new System.EventHandler(this.textBoxInstructions_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(39, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Qty:";
            // 
            // numericUpDownQty
            // 
            this.numericUpDownQty.AutoSize = true;
            this.numericUpDownQty.BackColor = System.Drawing.SystemColors.Window;
            this.numericUpDownQty.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.numericUpDownQty.Location = new System.Drawing.Point(92, 205);
            this.numericUpDownQty.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQty.Name = "numericUpDownQty";
            this.numericUpDownQty.Size = new System.Drawing.Size(73, 32);
            this.numericUpDownQty.TabIndex = 33;
            this.numericUpDownQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Completion Contact:";
            // 
            // comboBoxContact
            // 
            this.comboBoxContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContact.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContact.FormattingEnabled = true;
            this.comboBoxContact.Location = new System.Drawing.Point(226, 252);
            this.comboBoxContact.Name = "comboBoxContact";
            this.comboBoxContact.Size = new System.Drawing.Size(278, 33);
            this.comboBoxContact.TabIndex = 31;
            this.comboBoxContact.SelectedIndexChanged += new System.EventHandler(this.ComboBoxContact_SelectedIndexChanged);
            this.comboBoxContact.MouseEnter += new System.EventHandler(this.comboBoxContact_MouseEnter);
            this.comboBoxContact.MouseLeave += new System.EventHandler(this.comboBoxContact_MouseLeave);
            // 
            // bGWorkerAddPart
            // 
            this.bGWorkerAddPart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerAddPart_DoWork);
            this.bGWorkerAddPart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerAddPart_RunWorkerCompleted);
            // 
            // PartRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.ClientSize = new System.Drawing.Size(538, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartRequestForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Part Clean Request";
            this.Load += new System.EventHandler(this.PartRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPartRequestForm)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlStandard.ResumeLayout(false);
            this.pnlStandard.PerformLayout();
            this.panelNonStandard.ResumeLayout(false);
            this.panelNonStandard.PerformLayout();
            this.groupBoxCR.ResumeLayout(false);
            this.groupBoxCR.PerformLayout();
            this.gBoxStockLocation.ResumeLayout(false);
            this.gBoxStockLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPartCleanRequest;
        private System.ComponentModel.BackgroundWorker bGWorkerGetData;
        private System.ComponentModel.BackgroundWorker bGWorkerAddContact;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProviderPartRequestForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxRequestor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxHot;
        private System.Windows.Forms.GroupBox gBoxStockLocation;
        private System.Windows.Forms.RadioButton radioButtonBulk;
        private System.Windows.Forms.RadioButton radioButtonCage;
        private System.Windows.Forms.GroupBox groupBoxCR;
        private System.Windows.Forms.RadioButton radioButtonCRNo;
        private System.Windows.Forms.RadioButton radioButtonCRYes;
        private System.Windows.Forms.TextBox textBoxPO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.TextBox textBoxInstructions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxContact;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker bGWorkerAddPart;
        private System.Windows.Forms.Label lblPartDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlStandard;
        private System.Windows.Forms.RadioButton rBtnNonStandard;
        private System.Windows.Forms.RadioButton rBtnStandard;
        private System.Windows.Forms.ToolTip toolTipPartRequest;
        private System.Windows.Forms.Panel panelNonStandard;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEnterDescription;
        private System.Windows.Forms.Label label5;
    }
}