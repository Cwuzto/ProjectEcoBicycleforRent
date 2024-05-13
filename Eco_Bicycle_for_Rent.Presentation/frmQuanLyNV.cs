using Eco_Bicycle_for_Rent.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco_Bicycle_for_Rent.Presentation
{
    public partial class frmQuanLyNV : Form
    {
        NhanVienBUS nvBus=new NhanVienBUS();
        public frmQuanLyNV()
        {
            InitializeComponent();
        }

        private void frmQuanLyNV_Load(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = nvBus.LayDSNhanVien();
            cmbLoaiNV.DataSource=nvBus.GetDSLoaiNV();
            cmbLoaiNV.DisplayMember = "TenLNV";
            cmbLoaiNV.ValueMember = "MaLNV";
            DataTable dataTable = nvBus.GetDSTramTX();
            DataRow nullRow = dataTable.NewRow();
            nullRow["DiaChi"] = "None";
            nullRow["MaTTX"] = DBNull.Value;
            dataTable.Rows.InsertAt(nullRow, 0);
            cmbTram.DataSource = dataTable;
            cmbTram.DisplayMember = "DiaChi";
            cmbTram.ValueMember = "MaTTX";
        }
        private void load_data()
        {
            NhanVienBUS nvBUS = new NhanVienBUS();
            dgvDanhSach.DataSource = nvBUS.LayDSNhanVien();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private bool validateData()
        {
            errorProvider1.SetError(txtHoTen, (txtHoTen.Text == "") ? "Hãy nhập họ tên" : "");
            errorProvider2.SetError(txtSoDienThoai, (txtSoDienThoai.Text == "") ? "Hãy nhập số điện thoại" : "");
            errorProvider3.SetError(txtEmail, (txtEmail.Text == "") ? "Hãy nhập email" : "");
            errorProvider4.SetError(txtDiaChi, (txtDiaChi.Text == "") ? "Hãy nhập đia chỉ" : "");
            errorProvider5.SetError(txtUser, (txtUser.Text == "") ? "Hãy nhập username" : "");
            errorProvider6.SetError(txtPass, (txtPass.Text == "") ? "Hãy nhập password" : "");
            return (txtHoTen.Text != "" && txtSoDienThoai.Text != "" && txtEmail.Text != "" && txtPass.Text != "" && txtUser.Text != "" && txtDiaChi.Text != "");
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string gt;
            if (cbGioiTinh.Checked)
                gt = "Nam";
            else
                gt = "Nữ";
            if (!validateData())
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int loaiNV = Convert.ToInt32(cmbLoaiNV.SelectedValue);
                string matram = cmbTram.SelectedValue.ToString();

                if (nvBus.AddEmployee(txtHoTen.Text, txtSoDienThoai.Text, txtDiaChi.Text, txtPass.Text, txtUser.Text, gt, loaiNV, txtEmail.Text, matram))
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
                MessageBox.Show("Hãy chọn một nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string gt;
            if (cbGioiTinh.Checked)
                gt = "Nam";
            else
                gt = "Nữ";
            try
            {
                int loaiNV = Convert.ToInt32(cmbLoaiNV.SelectedValue);
                string matram = cmbTram.SelectedValue.ToString();
                if (nvBus.UpdateNV(idNV, txtHoTen.Text, txtSoDienThoai.Text, txtDiaChi.Text, txtPass.Text, txtUser.Text, gt, loaiNV, txtEmail.Text, matram))
                {

                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_data();
                    return;
                }
                else
                    MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex) { MessageBox.Show("Lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private string idNV;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nvBus.DeleteNV(idNV))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                return;
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];
                idNV = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTenNV"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChiNV"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPass.Text = row.Cells["Password"].Value.ToString();
                txtUser.Text = row.Cells["UserName"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SDT"].Value.ToString();
                string maloai = row.Cells["MaLNV"].Value.ToString();
                foreach (var item in cmbLoaiNV.Items) 
                {
                    DataRowView drv = item as DataRowView;
                    if (drv != null)
                    {
                        if (drv.Row[cmbLoaiNV.ValueMember].ToString() == maloai)
                        {
                            cmbLoaiNV.SelectedItem = item; 
                            break; 
                        }
                    }
                }
                string tram = row.Cells["MaTTX"].Value.ToString();
                foreach (var item in cmbTram.Items)
                {
                    DataRowView drv = item as DataRowView;
                    if (drv != null)
                    {
                        if (drv.Row[cmbTram.ValueMember].ToString() == tram)
                        {
                            cmbTram.SelectedItem = item;
                            break;
                        }
                    }
                }
                string gtinh = row.Cells["GioiTinh"].Value.ToString();
                if(gtinh.Equals("Nam"))
                    cbGioiTinh.Checked = true;
            }
        }
    }
}
