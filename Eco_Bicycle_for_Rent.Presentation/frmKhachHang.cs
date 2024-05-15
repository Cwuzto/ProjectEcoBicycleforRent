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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void lbThongTinCaNhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThongTinCaNhan frmThongTinCaNhan = new frmThongTinCaNhan();
            frmThongTinCaNhan.ShowDialog();
            this.Close();
        }

        private void pbThongTinCaNhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThongTinCaNhan frmThongTinCaNhan = new frmThongTinCaNhan();
            frmThongTinCaNhan.ShowDialog();
            this.Close();
        }

        private void lbViDienTu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLSoDu frmQLSoDu = new frmQLSoDu();  
            frmQLSoDu.ShowDialog();
            this.Close();
        }

        private void pbViDienTu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLSoDu frmQLSoDu = new frmQLSoDu();
            frmQLSoDu.ShowDialog();
            this.Close();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbLichSu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLichSuMuon frmLichSuMuon = new frmLichSuMuon();
            frmLichSuMuon.ShowDialog();
            this.Close();
        }

        private void lbDSTramXe_Click(object sender, EventArgs e)
        {
            frmDSTramThueXe frmDSTramThueXe = new frmDSTramThueXe();
            frmDSTramThueXe.ShowDialog(); 
        }

        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHomePage frmHomePage = new frmHomePage();
            frmHomePage.ShowDialog();
            this.Close();
        }

        private void pbDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHomePage frmHomePage = new frmHomePage();
            frmHomePage.ShowDialog();
            this.Close();
        }
    }
}
