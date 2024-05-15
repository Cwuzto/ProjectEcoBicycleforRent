using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco_Bicycle_for_Rent.Presentation
{
    public partial class frmQLSoDu : Form
    {
        public frmQLSoDu()
        {
            InitializeComponent();
        }

        private void btnNapTien_Click(object sender, EventArgs e)
        {
            frmNapTien frmNapTien = new frmNapTien();
            frmNapTien.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKhachHang frmKhachHang = new frmKhachHang(); 
            frmKhachHang.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHoanTraThe frmHoanTraThe = new frmHoanTraThe();
            frmHoanTraThe.ShowDialog();
        }
    }
}
