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
    public partial class FixtureForm : Form
    {
        public FixtureForm()
        {
            InitializeComponent();
        }
        public bool okButton = false;
        public bool OKButtonClicked
        {
            get { return okButton; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            okButton = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            okButton = false;
            this.Close();
        }

    }
}
