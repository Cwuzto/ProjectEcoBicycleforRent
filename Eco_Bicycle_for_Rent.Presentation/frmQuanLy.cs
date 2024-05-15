﻿using DoAnPTTKOOP;
using Quản_lý_Sản_Phẩm;
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
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void ShowChildFormInPanel(Form childForm)
        {
            // Thiết lập MDI parent của child form là panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelQL.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frmQLKH = new frmDMKhachHang();
            ShowChildFormInPanel(frmQLKH);
        }

        private void btnQLCN_Click(object sender, EventArgs e)
        {
           frmQLChiNhanh frmChiNhanh = new frmQLChiNhanh();
            ShowChildFormInPanel(frmChiNhanh);
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNV frmQLNV = new frmQuanLyNV();
            ShowChildFormInPanel(frmQLNV);
        }

        private void btnQLTX_Click(object sender, EventArgs e)
        {
            frmQLTramXe frmQLTramXe = new frmQLTramXe();
            ShowChildFormInPanel(frmQLTramXe);
        }

        private void btnQLLX_Click(object sender, EventArgs e)
        {
            frmQLLoaiXe frmQLLoaiXe = new frmQLLoaiXe();
            ShowChildFormInPanel(frmQLLoaiXe);
        }

        private void btnQLXD_Click(object sender, EventArgs e)
        {
            frmQuanLyXeDap frmQuanLyXeDap = new frmQuanLyXeDap();   
            ShowChildFormInPanel(frmQuanLyXeDap);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe frmThongKe = new frmThongKe();
            ShowChildFormInPanel(frmThongKe);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
