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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelProgressMessage
            // 
            this.labelProgressMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgressMessage.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgressMessage.Location = new System.Drawing.Point(0, 0);
            this.labelProgressMessage.Name = "labelProgressMessage";
            this.labelProgressMessage.Size = new System.Drawing.Size(412, 21);
            this.labelProgressMessage.TabIndex = 0;
            this.labelProgressMessage.Text = "Loading...";
            this.labelProgressMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelProgressMessage.UseWaitCursor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(412, 21);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.UseWaitCursor = true;
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 21);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelProgressMessage);
            this.Name = "ProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Be Patient";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelProgressMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}