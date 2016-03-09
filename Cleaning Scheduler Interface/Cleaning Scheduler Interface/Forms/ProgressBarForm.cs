using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cleaning_Scheduler_Interface
{
    public partial class ProgressBarForm : Form
    {
        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }
        
        public ProgressBarForm()
        {
            InitializeComponent();
        }
  
    }
}
