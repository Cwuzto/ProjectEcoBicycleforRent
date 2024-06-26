﻿using Eco_Bicycle_for_Rent.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnPTTKOOP
{
    public partial class frmQLChiNhanh : Form
    {
        ChiNhanhBUS cnBus=new ChiNhanhBUS();
        public frmQLChiNhanh()
        {
            InitializeComponent();
        }

        private void frmQLChiNhanh_Load(object sender, EventArgs e)
        {
            dgvQLChiNhanh.DataSource = cnBus.LayDSChiNhanh();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void load_data()
        {
            ChiNhanhBUS cnBus = new ChiNhanhBUS();
            dgvQLChiNhanh.DataSource = cnBus.LayDSChiNhanh();
        }
        private bool validateData()
        {
            errorProvider1.SetError(txtTenCN, (txtTenCN.Text == "") ? "Hãy nhập tên chi nhánh" : "");
            errorProvider2.SetError(txtDiaChi, (txtDiaChi.Text == "") ? "Hãy nhập địa chỉ chi nhánh" : "");
            return (txtTenCN.Text != "" && txtDiaChi.Text != "");
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (cnBus.AddChiNhanh(txtTenCN.Text, txtDiaChi.Text))
                {
                    load_data();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    MessageBox.Show("Thêm không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một chi nhánh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (cnBus.UpdateChiNhanh(txtTenCN.Text, txtDiaChi.Text, Convert.ToInt32(idCN)))
                {

                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                    return;
                }
                else
                    MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một chi nhánh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cnBus.DeleteChiNhanh(idCN))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                return;
            }
        }
        private string idCN;
        private void dgvQLChiNhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvQLChiNhanh.Rows[e.RowIndex];
                idCN = row.Cells["MaCN"].Value.ToString();
                txtTenCN.Text = row.Cells["TenCN"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }
    }
}
