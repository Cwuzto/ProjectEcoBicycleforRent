using Eco_Bicycle_for_Rent.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_Sản_Phẩm
{
    public partial class frmDMKhachHang : Form
    {
        KhachHangBUS khBus=new KhachHangBUS();
        public frmDMKhachHang()
        {
            InitializeComponent();
        }

        private void frmDMKhachHang_Load(object sender, EventArgs e)
        {
            dgvQLKH.DataSource = khBus.LayDSKH();
            cmbLoaiKH.DataSource=khBus.GetDSLoaiKH();
            cmbLoaiKH.DisplayMember= "TenLKH";
            cmbLoaiKH.ValueMember = "MaLKH";
        }
        private void load_data()
        {
            KhachHangBUS khBus = new KhachHangBUS();
            dgvQLKH.DataSource = khBus.LayDSKH();
        }
        private bool validateData()
        {
            errorProvider1.SetError(txtTenKhachHang, (txtTenKhachHang.Text == "") ? "Hãy nhập tên khách hàng" : "");
            errorProvider2.SetError(txtCCCD, (txtCCCD.Text == "") ? "Hãy nhập căn cước công dân" : "");
            errorProvider3.SetError(txtDiaChi, (txtDiaChi.Text == "") ? "Hãy nhập địa chỉ" : "");
            errorProvider4.SetError(txtTrangThai, (txtTrangThai.Text == "") ? "Hãy nhập trạng thái thẻ" : "");
            errorProvider5.SetError(txtemail, (txtemail.Text == "") ? "Hãy nhập email khách hàng" : "");
            errorProvider6.SetError(txtPass, (txtPass.Text == "") ? "Hãy nhập password" : "");
            errorProvider7.SetError(txtUser, (txtUser.Text == "") ? "Hãy nhập username" : "");
            errorProvider8.SetError(mtbDienThoai, (mtbDienThoai.Text == "") ? "Hãy nhập số điện thoại" : "");
            return (txtTenKhachHang.Text != "" && txtTrangThai.Text != "" && txtCCCD.Text != "" && txtDiaChi.Text != "" && txtemail.Text != "" && txtPass.Text != "" && txtUser.Text != "" && mtbDienThoai.Text != "");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (!validateData())
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int loaikh = Convert.ToInt32(cmbLoaiKH.SelectedValue);
                string gt;
                int sodu;
                if (chkGioiTinh.Checked)
                    gt = "Nam";
                else if (chkNu.Checked)
                    gt = "Nữ";
                else
                {
                    MessageBox.Show("Hãy chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (loaikh == 1)
                    sodu = 1000000;
                else
                    sodu = 0;
                if (khBus.AddKH(txtTenKhachHang.Text, mtbDienThoai.Text, txtCCCD.Text,gt,txtemail.Text,txtDiaChi.Text,sodu, dtpNgayDky.Value, txtTrangThai.Text, txtUser.Text,txtPass.Text, loaikh))
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
        private string idkh;
        private void dgvQLKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvQLKH.Rows[e.RowIndex];
                idkh = row.Cells["MaKH"].Value.ToString();
                txtTenKhachHang.Text = row.Cells["HoTen"].Value.ToString();
                txtTrangThai.Text = row.Cells["TrangThaiThe"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtemail.Text = row.Cells["Email"].Value.ToString();
                txtPass.Text = row.Cells["Password"].Value.ToString();
                txtUser.Text = row.Cells["UserName"].Value.ToString();
                dtpNgayDky.Value = DateTime.Parse(row.Cells["NgayDangKy"].Value.ToString());
                mtbDienThoai.Text = row.Cells["SDT"].Value.ToString();
                string gt= row.Cells["GioiTinh"].Value.ToString();
                if (gt.Equals("Nam"))
                {
                    chkGioiTinh.Checked = true;
                    chkNu.Checked = false;
                }
                else
                {
                    chkGioiTinh.Checked = false;
                    chkNu.Checked = true;
                }
                string maloai = row.Cells["MaLKH"].Value.ToString();
                foreach (var item in cmbLoaiKH.Items)
                {
                    DataRowView drv = item as DataRowView;
                    if (drv != null)
                    {
                        if (drv.Row[cmbLoaiKH.ValueMember].ToString() == maloai)
                        {
                            cmbLoaiKH.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int passwordLength = 8;
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < passwordLength; i++)
            {

                int randomIndex = random.Next(0, allowedChars.Length);
                char randomChar = allowedChars[randomIndex];
                password.Append(randomChar);
            }
            txtPass.Text = password.ToString();
        }

        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if(chkGioiTinh.Checked)
            {
                chkNu.Checked = false;
            }    
        }

        private void chkNu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNu.Checked)
            {
                chkGioiTinh.Checked = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (khBus.DeleteKH(idkh))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int loaikh = Convert.ToInt32(cmbLoaiKH.SelectedValue);
                string gt;
                int sodu;
                if (chkGioiTinh.Checked)
                    gt = "Nam";
                else if (chkNu.Checked)
                    gt = "Nữ";
                else
                {
                    MessageBox.Show("Hãy chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (loaikh == 1)
                    sodu = 1000000;
                else
                    sodu = 0;
                if (khBus.UpdateKH(txtTenKhachHang.Text, mtbDienThoai.Text, txtCCCD.Text, gt, txtemail.Text, txtDiaChi.Text, sodu, dtpNgayDky.Value, txtTrangThai.Text, txtUser.Text, txtPass.Text, loaikh, Convert.ToInt32(idkh)))
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
    }
}
