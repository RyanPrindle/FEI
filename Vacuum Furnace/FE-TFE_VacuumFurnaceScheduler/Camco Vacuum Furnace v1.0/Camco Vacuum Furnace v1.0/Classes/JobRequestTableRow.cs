using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Vacuum_Furnace_Scheduler_v1._0
{
    class JobRequestTableRow : IDisposable
    {
        public bool mDisposed { get; set; }
        public Panel qtyPanel { get; set; }
        public Panel partPanel { get; set; }
        public Panel contactPanel { get; set; }
        public Panel locationPanel { get; set; }
        public Panel addRowPanel { get; set; }

        public NumericUpDown qtyNumericUpDown { get; set; }
        public ComboBox partComboBox { get; set; }
        public ComboBox contactComboBox { get; set; }
        public ComboBox locationComboBox { get; set; }
        public Button addRowButton { get; set; }

        public JobRequestTableRow()
        {
            Font tableFont = new Font("Arial Narrow", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            // 
            // jobQtyDefault
            // 
            qtyNumericUpDown = new NumericUpDown();
            qtyNumericUpDown.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            qtyNumericUpDown.Font = tableFont;
            qtyNumericUpDown.Location = new Point(20, 15);
            qtyNumericUpDown.Size = new Size(61, 34);
            qtyNumericUpDown.Value = 1;
            qtyNumericUpDown.Minimum = 1;
            qtyNumericUpDown.TabIndex = 1;
            // 
            // panelUpDownDefault
            // 
            qtyPanel = new Panel();
            qtyPanel.Dock = DockStyle.Fill;
            qtyPanel.Location = new Point(6, 34);
            qtyPanel.Name = "panelQty";
            qtyPanel.Size = new Size(101, 64);
            qtyPanel.TabIndex = 0;
            qtyPanel.Controls.Add(qtyNumericUpDown);      
            // 
            // jobPartComboBoxDefault
            // 
            partComboBox = new ComboBox();
            partComboBox.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            partComboBox.Font = tableFont;
            partComboBox.FormattingEnabled = true;
            partComboBox.Location = new Point(24, 15);
            partComboBox.Dock = DockStyle.Fill;
            partComboBox.Name = "jobPartComboBox";
            partComboBox.Size = new Size(557, 34);
            partComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            partComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            partComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            partComboBox.TabIndex = 2;
            // 
            // panelPartsDefault
            // 
            partPanel = new Panel();
            partPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            partPanel.AutoSize = true;
            partPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            partPanel.Location = new Point(116, 34);
            partPanel.Name = "panelParts";
            partPanel.Padding = new Padding(20,15,20,15);
            partPanel.TabIndex = 0;
            partPanel.Controls.Add(partComboBox);
            // 
            // notifyComboBoxDefault
            // 
            contactComboBox = new ComboBox();
            contactComboBox.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            contactComboBox.Font = tableFont;
            contactComboBox.FormattingEnabled = true;
            contactComboBox.Location = new Point(24, 15);
            contactComboBox.Name = "notifyComboBox";
            contactComboBox.Size = new Size(380, 34);
            contactComboBox.Dock = DockStyle.Fill;
            contactComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            contactComboBox.TabIndex = 4;
            // 
            // panelNotifyDefault
            // 
            contactPanel = new Panel();
            contactPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            contactPanel.AutoSize = true;
            contactPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            contactPanel.Location = new Point(729, 34);
            contactPanel.Name = "panelNotify";            
            contactPanel.TabIndex = 0;
            contactPanel.Padding = new Padding(20,15,20,15);
            contactPanel.Controls.Add(contactComboBox);
            // 
            // LocationDefault
            // 
            locationComboBox = new ComboBox();
            locationComboBox.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            locationComboBox.FormattingEnabled = true;
            locationComboBox.Font = tableFont;
            locationComboBox.Location = new Point(24, 15);
            locationComboBox.Name = "locationComboBox";
            locationComboBox.Dock = DockStyle.Fill;
            locationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            locationComboBox.TabIndex = 5;
            // 
            // panelLocationDefault
            // 
            locationPanel = new Panel();
            locationPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            locationPanel.AutoSize = true;
            locationPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            locationPanel.Location = new Point(116, 34);
            locationPanel.Padding = new Padding(20,15,20,15);
            locationPanel.Name = "panelLocation";            
            locationPanel.TabIndex = 0;
            locationPanel.Controls.Add(locationComboBox);
            // 
            // addPartSelectionRowButton
            // 
            addRowButton = new Button();
            addRowButton.AutoSize = true;
            addRowButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addRowButton.Enabled = false;
            addRowButton.Font = tableFont;
            addRowButton.Location = new Point(32, 16);
            addRowButton.Margin = new Padding(0);
            addRowButton.Name = "addPartSelectionRowButton";
            addRowButton.Size = new Size(37, 35);
            addRowButton.TabIndex = 100;
            addRowButton.Text = "+";
            addRowButton.UseVisualStyleBackColor = true;
            // 
            // addPartSelectionRowPanel
            // 
            addRowPanel = new Panel();
            addRowPanel.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            addRowPanel.AutoSize = true;
            addRowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addRowPanel.Controls.Add(addRowButton);
            addRowPanel.Location = new Point(6, 107);
            addRowPanel.Name = "addPartSelectionRowPanel";            
            addRowPanel.TabIndex = 0;            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!mDisposed)
            {
                if (disposing)
                {
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                    qtyPanel.Dispose();
                    partPanel.Dispose();
                    contactPanel.Dispose();
                    locationPanel.Dispose();
                    addRowPanel.Dispose();
                    qtyNumericUpDown.Dispose();
                    partComboBox.Dispose();
                    contactComboBox.Dispose();
                    locationComboBox.Dispose();
                    addRowButton.Dispose();
                }
                // Indicate that the instance has been disposed.
                mDisposed = true;
            }
        }

    }
}
