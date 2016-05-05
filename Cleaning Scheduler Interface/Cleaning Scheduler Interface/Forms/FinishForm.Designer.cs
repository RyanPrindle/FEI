namespace Cleaning_Scheduler_Interface
{
    partial class FinishForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogFinished = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.bGWorkerLogFinished = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxDishwasher = new System.Windows.Forms.CheckBox();
            this.checkBoxDecon = new System.Windows.Forms.CheckBox();
            this.groupBoxCrest = new System.Windows.Forms.GroupBox();
            this.checkBoxCrestLong = new System.Windows.Forms.CheckBox();
            this.checkBoxCrest20 = new System.Windows.Forms.CheckBox();
            this.checkBoxCrest10 = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterPik = new System.Windows.Forms.CheckBox();
            this.checkBoxUltrasonic = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxCrest.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnLogFinished);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Location = new System.Drawing.Point(10, 249);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(395, 66);
            this.panel1.TabIndex = 48;
            // 
            // btnLogFinished
            // 
            this.btnLogFinished.AutoSize = true;
            this.btnLogFinished.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogFinished.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogFinished.Location = new System.Drawing.Point(164, 14);
            this.btnLogFinished.Name = "btnLogFinished";
            this.btnLogFinished.Size = new System.Drawing.Size(214, 35);
            this.btnLogFinished.TabIndex = 8;
            this.btnLogFinished.Text = "Log Cleaning Finished";
            this.btnLogFinished.UseVisualStyleBackColor = true;
            this.btnLogFinished.Click += new System.EventHandler(this.btnLogFinished_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(13, 13);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(80, 35);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // bGWorkerLogFinished
            // 
            this.bGWorkerLogFinished.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWorkerLogFinished_DoWork);
            this.bGWorkerLogFinished.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWorkerLogFinished_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.checkBoxDishwasher);
            this.panel2.Controls.Add(this.checkBoxDecon);
            this.panel2.Controls.Add(this.groupBoxCrest);
            this.panel2.Controls.Add(this.checkBoxWaterPik);
            this.panel2.Controls.Add(this.checkBoxUltrasonic);
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(395, 229);
            this.panel2.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Check-off cleaning process(es) used.";
            // 
            // checkBoxDishwasher
            // 
            this.checkBoxDishwasher.AutoSize = true;
            this.checkBoxDishwasher.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDishwasher.Location = new System.Drawing.Point(30, 164);
            this.checkBoxDishwasher.Name = "checkBoxDishwasher";
            this.checkBoxDishwasher.Size = new System.Drawing.Size(111, 27);
            this.checkBoxDishwasher.TabIndex = 4;
            this.checkBoxDishwasher.Text = "Dishwasher";
            this.checkBoxDishwasher.UseVisualStyleBackColor = true;
            // 
            // checkBoxDecon
            // 
            this.checkBoxDecon.AutoSize = true;
            this.checkBoxDecon.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDecon.Location = new System.Drawing.Point(30, 65);
            this.checkBoxDecon.Name = "checkBoxDecon";
            this.checkBoxDecon.Size = new System.Drawing.Size(133, 27);
            this.checkBoxDecon.TabIndex = 3;
            this.checkBoxDecon.Text = "Decontaminant";
            this.checkBoxDecon.UseVisualStyleBackColor = true;
            // 
            // groupBoxCrest
            // 
            this.groupBoxCrest.Controls.Add(this.checkBoxCrestLong);
            this.groupBoxCrest.Controls.Add(this.checkBoxCrest20);
            this.groupBoxCrest.Controls.Add(this.checkBoxCrest10);
            this.groupBoxCrest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxCrest.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCrest.Location = new System.Drawing.Point(209, 55);
            this.groupBoxCrest.Name = "groupBoxCrest";
            this.groupBoxCrest.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxCrest.Size = new System.Drawing.Size(161, 129);
            this.groupBoxCrest.TabIndex = 2;
            this.groupBoxCrest.TabStop = false;
            this.groupBoxCrest.Text = "Crest";
            // 
            // checkBoxCrestLong
            // 
            this.checkBoxCrestLong.AutoSize = true;
            this.checkBoxCrestLong.Location = new System.Drawing.Point(8, 96);
            this.checkBoxCrestLong.Name = "checkBoxCrestLong";
            this.checkBoxCrestLong.Size = new System.Drawing.Size(118, 27);
            this.checkBoxCrestLong.TabIndex = 2;
            this.checkBoxCrestLong.Text = "> 20 minutes";
            this.checkBoxCrestLong.UseVisualStyleBackColor = true;
            this.checkBoxCrestLong.Click += new System.EventHandler(this.checkBoxCrest_Click);
            // 
            // checkBoxCrest20
            // 
            this.checkBoxCrest20.AutoSize = true;
            this.checkBoxCrest20.Location = new System.Drawing.Point(8, 63);
            this.checkBoxCrest20.Name = "checkBoxCrest20";
            this.checkBoxCrest20.Size = new System.Drawing.Size(105, 27);
            this.checkBoxCrest20.TabIndex = 1;
            this.checkBoxCrest20.Text = "20 minutes";
            this.checkBoxCrest20.UseVisualStyleBackColor = true;
            this.checkBoxCrest20.Click += new System.EventHandler(this.checkBoxCrest_Click);
            // 
            // checkBoxCrest10
            // 
            this.checkBoxCrest10.AutoSize = true;
            this.checkBoxCrest10.Location = new System.Drawing.Point(9, 30);
            this.checkBoxCrest10.Name = "checkBoxCrest10";
            this.checkBoxCrest10.Size = new System.Drawing.Size(105, 27);
            this.checkBoxCrest10.TabIndex = 0;
            this.checkBoxCrest10.Text = "10 minutes";
            this.checkBoxCrest10.UseVisualStyleBackColor = true;
            this.checkBoxCrest10.Click += new System.EventHandler(this.checkBoxCrest_Click);
            // 
            // checkBoxWaterPik
            // 
            this.checkBoxWaterPik.AutoSize = true;
            this.checkBoxWaterPik.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWaterPik.Location = new System.Drawing.Point(30, 98);
            this.checkBoxWaterPik.Name = "checkBoxWaterPik";
            this.checkBoxWaterPik.Size = new System.Drawing.Size(91, 27);
            this.checkBoxWaterPik.TabIndex = 1;
            this.checkBoxWaterPik.Text = "WaterPik";
            this.checkBoxWaterPik.UseVisualStyleBackColor = true;
            // 
            // checkBoxUltrasonic
            // 
            this.checkBoxUltrasonic.AutoSize = true;
            this.checkBoxUltrasonic.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUltrasonic.Location = new System.Drawing.Point(30, 131);
            this.checkBoxUltrasonic.Name = "checkBoxUltrasonic";
            this.checkBoxUltrasonic.Size = new System.Drawing.Size(97, 27);
            this.checkBoxUltrasonic.TabIndex = 0;
            this.checkBoxUltrasonic.Text = "Ultrasonic";
            this.checkBoxUltrasonic.UseVisualStyleBackColor = true;
            // 
            // FinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(415, 325);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FinishForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cleaning Process Logging";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxCrest.ResumeLayout(false);
            this.groupBoxCrest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogFinished;
        private System.Windows.Forms.Button buttonCancel;
        private System.ComponentModel.BackgroundWorker bGWorkerLogFinished;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDishwasher;
        private System.Windows.Forms.CheckBox checkBoxDecon;
        private System.Windows.Forms.GroupBox groupBoxCrest;
        private System.Windows.Forms.CheckBox checkBoxCrestLong;
        private System.Windows.Forms.CheckBox checkBoxCrest20;
        private System.Windows.Forms.CheckBox checkBoxCrest10;
        private System.Windows.Forms.CheckBox checkBoxWaterPik;
        private System.Windows.Forms.CheckBox checkBoxUltrasonic;
    }
}