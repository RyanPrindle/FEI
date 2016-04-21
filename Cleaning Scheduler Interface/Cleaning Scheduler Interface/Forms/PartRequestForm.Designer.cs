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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxHot = new System.Windows.Forms.CheckBox();
            this.comboBoxSite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxSL = new System.Windows.Forms.GroupBox();
            this.radioButtonBulk = new System.Windows.Forms.RadioButton();
            this.radioButtonCage = new System.Windows.Forms.RadioButton();
            this.groupBoxCR = new System.Windows.Forms.GroupBox();
            this.radioButtonCRNo = new System.Windows.Forms.RadioButton();
            this.radioButtonCRYes = new System.Windows.Forms.RadioButton();
            this.textBoxPO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxContact = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.bGWorkerAddPart = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPartRequestForm)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxSL.SuspendLayout();
            this.groupBoxCR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPartCleanRequest
            // 
            this.btnPartCleanRequest.AutoSize = true;
            this.btnPartCleanRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPartCleanRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartCleanRequest.Location = new System.Drawing.Point(290, 12);
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
            this.buttonCancel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(236, 35);
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
            this.textBoxRequestor.Location = new System.Drawing.Point(210, 14);
            this.textBoxRequestor.Name = "textBoxRequestor";
            this.textBoxRequestor.Size = new System.Drawing.Size(309, 29);
            this.textBoxRequestor.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.btnPartCleanRequest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 447);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(541, 62);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBoxSerialNumber);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxRequestor);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.checkBoxHot);
            this.panel2.Controls.Add(this.comboBoxSite);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.groupBoxSL);
            this.panel2.Controls.Add(this.groupBoxCR);
            this.panel2.Controls.Add(this.textBoxPO);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxComment);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.numericUpDownQty);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxContact);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxPart);
            this.panel2.Location = new System.Drawing.Point(10, 13);
            this.panel2.MaximumSize = new System.Drawing.Size(542, 428);
            this.panel2.MinimumSize = new System.Drawing.Size(542, 428);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(542, 428);
            this.panel2.TabIndex = 27;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSerialNumber.Location = new System.Drawing.Point(209, 257);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(121, 29);
            this.textBoxSerialNumber.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 258);
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
            this.label7.Location = new System.Drawing.Point(98, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 42;
            this.label7.Text = "Requestor:";
            // 
            // checkBoxHot
            // 
            this.checkBoxHot.AutoSize = true;
            this.checkBoxHot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHot.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHot.Location = new System.Drawing.Point(128, 298);
            this.checkBoxHot.Name = "checkBoxHot";
            this.checkBoxHot.Size = new System.Drawing.Size(137, 29);
            this.checkBoxHot.TabIndex = 37;
            this.checkBoxHot.Text = "High Priority";
            this.checkBoxHot.UseVisualStyleBackColor = true;
            // 
            // comboBoxSite
            // 
            this.comboBoxSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSite.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSite.FormattingEnabled = true;
            this.comboBoxSite.Items.AddRange(new object[] {
            "30",
            "50"});
            this.comboBoxSite.Location = new System.Drawing.Point(445, 294);
            this.comboBoxSite.Name = "comboBoxSite";
            this.comboBoxSite.Size = new System.Drawing.Size(73, 33);
            this.comboBoxSite.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "Site:";
            // 
            // groupBoxSL
            // 
            this.groupBoxSL.Controls.Add(this.radioButtonBulk);
            this.groupBoxSL.Controls.Add(this.radioButtonCage);
            this.groupBoxSL.Enabled = false;
            this.groupBoxSL.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSL.Location = new System.Drawing.Point(296, 341);
            this.groupBoxSL.Name = "groupBoxSL";
            this.groupBoxSL.Padding = new System.Windows.Forms.Padding(10);
            this.groupBoxSL.Size = new System.Drawing.Size(230, 71);
            this.groupBoxSL.TabIndex = 40;
            this.groupBoxSL.TabStop = false;
            this.groupBoxSL.Text = "Stock Location";
            // 
            // radioButtonBulk
            // 
            this.radioButtonBulk.AutoSize = true;
            this.radioButtonBulk.Location = new System.Drawing.Point(149, 30);
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
            this.radioButtonCage.Location = new System.Drawing.Point(13, 30);
            this.radioButtonCage.Name = "radioButtonCage";
            this.radioButtonCage.Size = new System.Drawing.Size(121, 29);
            this.radioButtonCage.TabIndex = 10;
            this.radioButtonCage.TabStop = true;
            this.radioButtonCage.Text = "Cage Shelf";
            this.radioButtonCage.UseVisualStyleBackColor = true;
            // 
            // groupBoxCR
            // 
            this.groupBoxCR.Controls.Add(this.radioButtonCRNo);
            this.groupBoxCR.Controls.Add(this.radioButtonCRYes);
            this.groupBoxCR.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCR.ForeColor = System.Drawing.Color.Maroon;
            this.groupBoxCR.Location = new System.Drawing.Point(13, 341);
            this.groupBoxCR.Name = "groupBoxCR";
            this.groupBoxCR.Size = new System.Drawing.Size(230, 71);
            this.groupBoxCR.TabIndex = 35;
            this.groupBoxCR.TabStop = false;
            this.groupBoxCR.Text = "Cleanroom Ready";
            // 
            // radioButtonCRNo
            // 
            this.radioButtonCRNo.AutoSize = true;
            this.radioButtonCRNo.Location = new System.Drawing.Point(132, 30);
            this.radioButtonCRNo.Name = "radioButtonCRNo";
            this.radioButtonCRNo.Size = new System.Drawing.Size(53, 29);
            this.radioButtonCRNo.TabIndex = 9;
            this.radioButtonCRNo.TabStop = true;
            this.radioButtonCRNo.Text = "No";
            this.radioButtonCRNo.UseVisualStyleBackColor = true;
            this.radioButtonCRNo.Click += new System.EventHandler(this.radioButtonCRNo_Click);
            // 
            // radioButtonCRYes
            // 
            this.radioButtonCRYes.AutoSize = true;
            this.radioButtonCRYes.Location = new System.Drawing.Point(48, 30);
            this.radioButtonCRYes.Name = "radioButtonCRYes";
            this.radioButtonCRYes.Size = new System.Drawing.Size(61, 29);
            this.radioButtonCRYes.TabIndex = 8;
            this.radioButtonCRYes.TabStop = true;
            this.radioButtonCRYes.Text = "Yes";
            this.radioButtonCRYes.UseVisualStyleBackColor = true;
            this.radioButtonCRYes.Click += new System.EventHandler(this.radioButtonCRYes_Click);
            // 
            // textBoxPO
            // 
            this.textBoxPO.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPO.Location = new System.Drawing.Point(209, 222);
            this.textBoxPO.Name = "textBoxPO";
            this.textBoxPO.Size = new System.Drawing.Size(310, 29);
            this.textBoxPO.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "PO Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 25);
            this.label4.TabIndex = 38;
            this.label4.Text = "Special Instructions:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComment.Location = new System.Drawing.Point(210, 90);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(310, 87);
            this.textBoxComment.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(350, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Quantity:";
            // 
            // numericUpDownQty
            // 
            this.numericUpDownQty.AutoSize = true;
            this.numericUpDownQty.BackColor = System.Drawing.SystemColors.Window;
            this.numericUpDownQty.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.numericUpDownQty.Location = new System.Drawing.Point(446, 256);
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
            this.label2.Location = new System.Drawing.Point(19, 186);
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
            this.comboBoxContact.Location = new System.Drawing.Point(210, 183);
            this.comboBoxContact.Name = "comboBoxContact";
            this.comboBoxContact.Size = new System.Drawing.Size(310, 33);
            this.comboBoxContact.TabIndex = 31;
            this.comboBoxContact.SelectedIndexChanged += new System.EventHandler(this.ComboBoxContact_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(81, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Part Number:";
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxPart.DropDownHeight = 506;
            this.comboBoxPart.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.IntegralHeight = false;
            this.comboBoxPart.Location = new System.Drawing.Point(210, 50);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(310, 33);
            this.comboBoxPart.TabIndex = 28;
            this.comboBoxPart.Leave += new System.EventHandler(this.comboBoxPart_Leave);
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
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(561, 519);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(577, 557);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(577, 557);
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
            this.groupBoxSL.ResumeLayout(false);
            this.groupBoxSL.PerformLayout();
            this.groupBoxCR.ResumeLayout(false);
            this.groupBoxCR.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBoxSite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxSL;
        private System.Windows.Forms.RadioButton radioButtonBulk;
        private System.Windows.Forms.RadioButton radioButtonCage;
        private System.Windows.Forms.GroupBox groupBoxCR;
        private System.Windows.Forms.RadioButton radioButtonCRNo;
        private System.Windows.Forms.RadioButton radioButtonCRYes;
        private System.Windows.Forms.TextBox textBoxPO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker bGWorkerAddPart;
    }
}