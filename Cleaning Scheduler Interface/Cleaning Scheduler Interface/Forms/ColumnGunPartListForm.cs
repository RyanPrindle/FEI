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
    public partial class ColumnGunPartListForm : Form
    {
        private DataTable gunPartTable;
        private RequestsDB requestDB;
        private String mGun;
        public ColumnGunPartListForm(String gun)
        {
            mGun = gun;
            InitializeComponent();
        }        

        private void ColumnGunPartListForm_Load(object sender, EventArgs e)
        {
            int index;
            lblTitle.Text = mGun + " Parts";
            requestDB = new RequestsDB();
            gunPartTable = requestDB.GetGunParts(mGun);
            Image image;            
            foreach (DataRow row in gunPartTable.Rows)
            {
                Label lblPartNumber = new Label();
                Label lblDescription = new Label();
                PictureBox pBPartDrawing = new PictureBox();
                image = (Image)Cleaning_Scheduler_Interface.Properties.Resources.ResourceManager.GetObject(row["Image"].ToString());
                pBPartDrawing.Image = image;
                pBPartDrawing.SizeMode = PictureBoxSizeMode.Zoom;
                pBPartDrawing.Height = 156;
                pBPartDrawing.Width = 256;
                lblPartNumber.Dock = DockStyle.Fill;
                lblPartNumber.BorderStyle = BorderStyle.Fixed3D;
                lblPartNumber.TextAlign = ContentAlignment.MiddleCenter;
                lblDescription.Dock = DockStyle.Fill;
                lblDescription.BorderStyle = BorderStyle.Fixed3D;
                lblDescription.TextAlign = ContentAlignment.MiddleCenter;
                index = gunPartTable.Rows.IndexOf(row) + 3;
                lblPartNumber.Text = row["PartNumber"].ToString();
                lblDescription.Text = row["Description"].ToString();
                tLPGun.Controls.Add(lblPartNumber, 0, index);
                tLPGun.Controls.Add(lblDescription, 1, index);
                tLPGun.Controls.Add(pBPartDrawing, 2, index);
            }
        }
    }
}
