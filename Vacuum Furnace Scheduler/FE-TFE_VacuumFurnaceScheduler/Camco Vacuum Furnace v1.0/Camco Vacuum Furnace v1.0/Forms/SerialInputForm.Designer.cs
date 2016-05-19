namespace Vacuum_Furnace_Scheduler_v1._0
{
    partial class SerialInputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxSerial = new System.Windows.Forms.ListBox();
            this.labelPart = new System.Windows.Forms.Label();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.labelEnter = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelSerialCounter = new System.Windows.Forms.Label();
            this.textBoxDone = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please enter serial number(s) for part #";
            // 
            // listBoxSerial
            // 
            this.listBoxSerial.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxSerial.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSerial.ItemHeight = 20;
            this.listBoxSerial.Location = new System.Drawing.Point(223, 37);
            this.listBoxSerial.Name = "listBoxSerial";
            this.listBoxSerial.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxSerial.Size = new System.Drawing.Size(112, 144);
            this.listBoxSerial.TabIndex = 7;
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPart.Location = new System.Drawing.Point(256, 10);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(46, 20);
            this.labelPart.TabIndex = 6;
            this.labelPart.Text = "label2";
            this.labelPart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSerial.Location = new System.Drawing.Point(16, 62);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.Size = new System.Drawing.Size(146, 26);
            this.textBoxSerial.TabIndex = 0;
            this.textBoxSerial.WordWrap = false;
            // 
            // labelEnter
            // 
            this.labelEnter.AutoSize = true;
            this.labelEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnter.Location = new System.Drawing.Point(16, 36);
            this.labelEnter.Name = "labelEnter";
            this.labelEnter.Size = new System.Drawing.Size(137, 16);
            this.labelEnter.TabIndex = 4;
            this.labelEnter.Text = "Enter a serial number:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(29, 154);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 27);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(121, 184);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(29, 184);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 28);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "Done";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Visible = false;
            // 
            // labelSerialCounter
            // 
            this.labelSerialCounter.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialCounter.Location = new System.Drawing.Point(219, 184);
            this.labelSerialCounter.Name = "labelSerialCounter";
            this.labelSerialCounter.Size = new System.Drawing.Size(111, 20);
            this.labelSerialCounter.TabIndex = 8;
            this.labelSerialCounter.Text = "Serial Numbers";
            this.labelSerialCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDone
            // 
            this.textBoxDone.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBoxDone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDone.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDone.ForeColor = System.Drawing.Color.Red;
            this.textBoxDone.Location = new System.Drawing.Point(16, 55);
            this.textBoxDone.Name = "textBoxDone";
            this.textBoxDone.Size = new System.Drawing.Size(191, 96);
            this.textBoxDone.TabIndex = 9;
            this.textBoxDone.Text = "A serial Number for each part has been entered please select Done or Cancel.";
            this.textBoxDone.Visible = false;
            // 
            // SerialInputForm
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(347, 217);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxDone);
            this.Controls.Add(this.labelSerialCounter);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelEnter);
            this.Controls.Add(this.textBoxSerial);
            this.Controls.Add(this.labelPart);
            this.Controls.Add(this.listBoxSerial);
            this.Controls.Add(this.label1);
            this.Name = "SerialInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SerialInputForm";
            this.Load += new System.EventHandler(this.SerialInputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxSerial;
        private System.Windows.Forms.Label labelPart;
        private System.Windows.Forms.TextBox textBoxSerial;
        private System.Windows.Forms.Label labelEnter;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSerialCounter;
        private System.Windows.Forms.RichTextBox textBoxDone;
    }
}