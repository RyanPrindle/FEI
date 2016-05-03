namespace Cleaning_Scheduler_Interface
{
    partial class ColumnRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnRequestForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.btnColumnCleanRequest = new System.Windows.Forms.Button();
            this.bGWorkerGetData = new System.ComponentModel.BackgroundWorker();
            this.bGWorkerAddContact = new System.ComponentModel.BackgroundWorker();
            this.errorProviderColumnRequestForm = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxRequestor = new System.Windows.Forms.TextBox();
            this.bGWorkerAddColumn = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxColumnSerial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxColumnHot = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxContact = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxColumn = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderColumnRequestForm)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 13);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(236, 35);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // btnColumnCleanRequest
            // 
            this.btnColumnCleanRequest.AutoSize = true;
            this.btnColumnCleanRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnColumnCleanRequest.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColumnCleanRequest.Location = new System.Drawing.Point(289, 12);
            this.btnColumnCleanRequest.Name = "btnColumnCleanRequest";
            this.btnColumnCleanRequest.Size = new System.Drawing.Size(236, 35);
            this.btnColumnCleanRequest.TabIndex = 8;
            this.btnColumnCleanRequest.Text = "Submit Cleaning Request";
            this.btnColumnCleanRequest.UseVisualStyleBackColor = true;
            this.btnColumnCleanRequest.Click += new System.EventHandler(this.btnColumnCleanRequest_Click);
            // 
            // errorProviderColumnRequestForm
            // 
            this.errorProviderColumnRequestForm.ContainerControl = this;
            // 
            // textBoxRequestor
            // 
            this.textBoxRequestor.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorProviderColumnRequestForm.SetIconAlignment(this.textBoxRequestor, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textBoxRequestor.Location = new System.Drawing.Point(209, 13);
            this.textBoxRequestor.Name = "textBoxRequestor";
            this.textBoxRequestor.Size = new System.Drawing.Size(310, 29);
            this.textBoxRequestor.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnColumnCleanRequest);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 285);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(541, 62);
            this.panel1.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textBoxColumnSerial);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxRequestor);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.checkBoxColumnHot);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxComment);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxContact);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBoxColumn);
            this.panel2.Location = new System.Drawing.Point(10, 13);
            this.panel2.MaximumSize = new System.Drawing.Size(541, 266);
            this.panel2.MinimumSize = new System.Drawing.Size(541, 266);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(541, 266);
            this.panel2.TabIndex = 48;
            // 
            // textBoxColumnSerial
            // 
            this.textBoxColumnSerial.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxColumnSerial.Location = new System.Drawing.Point(209, 219);
            this.textBoxColumnSerial.Name = "textBoxColumnSerial";
            this.textBoxColumnSerial.Size = new System.Drawing.Size(120, 29);
            this.textBoxColumnSerial.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(65, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 25);
            this.label5.TabIndex = 57;
            this.label5.Text = "Serial Number:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(97, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 25);
            this.label7.TabIndex = 56;
            this.label7.Text = "Requestor:";
            // 
            // checkBoxColumnHot
            // 
            this.checkBoxColumnHot.AutoSize = true;
            this.checkBoxColumnHot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxColumnHot.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxColumnHot.Location = new System.Drawing.Point(381, 219);
            this.checkBoxColumnHot.Name = "checkBoxColumnHot";
            this.checkBoxColumnHot.Size = new System.Drawing.Size(137, 29);
            this.checkBoxColumnHot.TabIndex = 52;
            this.checkBoxColumnHot.Text = "High Priority";
            this.checkBoxColumnHot.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 55;
            this.label4.Text = "Comment:";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComment.Location = new System.Drawing.Point(209, 87);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(310, 87);
            this.textBoxComment.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 54;
            this.label2.Text = "Completion Contact:";
            // 
            // comboBoxContact
            // 
            this.comboBoxContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContact.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxContact.FormattingEnabled = true;
            this.comboBoxContact.Location = new System.Drawing.Point(209, 180);
            this.comboBoxContact.Name = "comboBoxContact";
            this.comboBoxContact.Size = new System.Drawing.Size(310, 33);
            this.comboBoxContact.TabIndex = 50;
            this.comboBoxContact.SelectedIndexChanged += new System.EventHandler(this.ComboBoxContact_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(73, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 53;
            this.label1.Text = "Column Type:";
            // 
            // comboBoxColumn
            // 
            this.comboBoxColumn.DropDownHeight = 506;
            this.comboBoxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColumn.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxColumn.FormattingEnabled = true;
            this.comboBoxColumn.IntegralHeight = false;
            this.comboBoxColumn.Location = new System.Drawing.Point(209, 48);
            this.comboBoxColumn.Name = "comboBoxColumn";
            this.comboBoxColumn.Size = new System.Drawing.Size(310, 33);
            this.comboBoxColumn.TabIndex = 48;
            // 
            // ColumnRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(561, 357);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(577, 395);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(577, 395);
            this.Name = "ColumnRequestForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Column Clean Request";
            this.Load += new System.EventHandler(this.ColumnRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderColumnRequestForm)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button btnColumnCleanRequest;
        private System.ComponentModel.BackgroundWorker bGWorkerGetData;
        private System.ComponentModel.BackgroundWorker bGWorkerAddContact;
        private System.Windows.Forms.ErrorProvider errorProviderColumnRequestForm;
        private System.ComponentModel.BackgroundWorker bGWorkerAddColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxColumnSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRequestor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxColumnHot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxColumn;
    }
}