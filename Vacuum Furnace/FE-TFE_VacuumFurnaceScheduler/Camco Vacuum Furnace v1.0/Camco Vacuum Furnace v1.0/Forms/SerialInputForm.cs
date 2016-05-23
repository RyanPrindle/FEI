using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vacuum_Furnace_Scheduler_v1._0
{
    public partial class SerialInputForm : Form
    {
        private BindingList<string> serialList;
        private int qty;
        private int serialCounter;
        private string part;

        public SerialInputForm()
        {
            part = "";
            serialCounter = 0;
            qty = 0;
            serialList = new BindingList<string>();
            InitializeComponent();
        }

        public void SetQuantity(int q)
        {
            qty = q;
        }

        public void SetPart(string p)
        {
            part = p;
        }

        public List<string> GetSerialList()
        {
            return (serialList.ToList());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonOK.Visible = true;
            if(string.IsNullOrWhiteSpace(textBoxSerial.Text)|| string.IsNullOrEmpty(textBoxSerial.Text))
            {
                MessageBox.Show("Error","Serial Number cannot be blank. \nPlease enter a serial number.");
            }
            else
            {                
                serialCounter++;
                serialList.Add(textBoxSerial.Text);
                labelSerialCounter.Text = serialCounter + " of " + qty;
                textBoxSerial.Text = "";
                if (serialCounter == qty)
                {
                    buttonAdd.Visible = false;
                    buttonOK.Focus();
                    textBoxDone.Visible = true;
                    labelEnter.Visible = false;
                    textBoxSerial.Visible = false;
                }
                else
                {
                    textBoxSerial.Focus();
                }
            }
        }

        private void SerialInputForm_Load(object sender, EventArgs e)
        {            
            listBoxSerial.DataSource = serialList;
            labelPart.Text = part;
            labelSerialCounter.Text = serialCounter + " of " + qty;
            textBoxSerial.Focus();
        }
    }
}
