namespace Cleaning_Scheduler_Interface
{
    partial class ColumnGunPartListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnGunPartListForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.bGWGunParts = new System.ComponentModel.BackgroundWorker();
            this.panelTLP = new System.Windows.Forms.Panel();
            this.toolTipPartsList = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCancel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(704, 698);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 35);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "OK";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // bGWGunParts
            // 
            this.bGWGunParts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bGWGunParts_DoWork);
            this.bGWGunParts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bGWGunParts_RunWorkerCompleted);
            // 
            // panelTLP
            // 
            this.panelTLP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTLP.AutoScroll = true;
            this.panelTLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTLP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.panelTLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTLP.Location = new System.Drawing.Point(12, 12);
            this.panelTLP.Name = "panelTLP";
            this.panelTLP.Size = new System.Drawing.Size(812, 672);
            this.panelTLP.TabIndex = 16;
            // 
            // ColumnGunPartListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(838, 745);
            this.Controls.Add(this.panelTLP);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(854, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(854, 400);
            this.Name = "ColumnGunPartListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cleaning Scheduler Interface - Detailed Parts List";
            this.Load += new System.EventHandler(this.ColumnGunPartListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.ComponentModel.BackgroundWorker bGWGunParts;
        private System.Windows.Forms.Panel panelTLP;
        private System.Windows.Forms.ToolTip toolTipPartsList;
    }
}