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
    public partial class frmHomePage : Form
    {
        public frmHomePage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin(); 
            frmLogin.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangKy frmDangKy = new frmDangKy();
            frmDangKy.ShowDialog();
            this.Close();
        }

        private void btnTramXeDap_Click(object sender, EventArgs e)
        {
            frmDSTramThueXe frmDSTramThueXe = new frmDSTramThueXe();
            frmDSTramThueXe.ShowDialog();
        }
    }
}
