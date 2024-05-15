using Eco_Bicycle_for_Rent.Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Eco_Bicycle_for_Rent.Presentation
{
    public partial class frmQLLoaiXe : Form
    {
        LoaiXeBUS loaixeBus=new LoaiXeBUS();
        public frmQLLoaiXe()
        {
            InitializeComponent();
        }

        private void frmQLLoaiXe_Load(object sender, EventArgs e)
        {
            dgvDS.DataSource = loaixeBus.LayDSLoaiXe();
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void load_data()
        {
            LoaiXeBUS loaixeBus = new LoaiXeBUS();
            dgvDS.DataSource = loaixeBus.LayDSLoaiXe();
        }
        private bool validateData()
        {
            errorProvider1.SetError(txtLoaiTenXD, (txtLoaiTenXD.Text == "") ? "Hãy nhập tên loại xe đạp" : "");
            errorProvider2.SetError(txtDonGia, (txtDonGia.Text == "") ? "Hãy nhập đơn giá cho loại xe" : "");
            return (txtLoaiTenXD.Text != "" && txtDonGia.Text != "");
        }
        private string idloaixe;
        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];
                idloaixe = row.Cells["MaLX"].Value.ToString();
                txtLoaiTenXD.Text = row.Cells["TenLoai"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGiaChoThue"].Value.ToString();
                nbrSoluong.Value = Convert.ToInt32(row.Cells["SoLuong"].Value.ToString());
            }
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
                if (loaixeBus.AddLoaiXe(txtLoaiTenXD.Text, Convert.ToInt32(nbrSoluong.Value), Convert.ToInt32(txtDonGia.Text)))
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
                MessageBox.Show("Hãy chọn một loại xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (loaixeBus.UpdateLoaiXe(txtLoaiTenXD.Text,Convert.ToInt32(nbrSoluong.Value),Convert.ToInt32(txtDonGia.Text), Convert.ToInt32(idloaixe)))
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
                MessageBox.Show("Hãy chọn một loại xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (loaixeBus.DeleteLoaiXe(idloaixe))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                return;
            }
        }
    }
}
