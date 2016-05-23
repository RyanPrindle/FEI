namespace Vacuum_Furnace_Scheduler_v1._0
{
    partial class ProgressBarForm
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
            this.labelProgressMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProgressMessage
            // 
            this.labelProgressMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelProgressMessage.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgressMessage.Location = new System.Drawing.Point(0, 160);
            this.labelProgressMessage.Name = "labelProgressMessage";
            this.labelProgressMessage.Size = new System.Drawing.Size(162, 21);
            this.labelProgressMessage.TabIndex = 0;
            this.labelProgressMessage.Text = "Loading...";
            this.labelProgressMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelProgressMessage.UseWaitCursor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vacuum_Furnace_Scheduler_v1._0.Properties.Resources.FEI_Logo_dual_Spinner;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(162, 181);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelProgressMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Be Patient";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelProgressMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}