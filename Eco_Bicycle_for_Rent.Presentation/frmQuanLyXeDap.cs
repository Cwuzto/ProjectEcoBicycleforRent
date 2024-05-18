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

namespace Eco_Bicycle_for_Rent.Presentation
{
    public partial class frmQuanLyXeDap : Form
    {
        XeDapBUS xeBus = new XeDapBUS();
        public frmQuanLyXeDap()
        {
            InitializeComponent();
        }

        private void frmQuanLyXeDap_Load(object sender, EventArgs e)
        {
            dgvDS.DataSource = xeBus.LayDSXeDap();
            dgvDS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbLoaiXe.DataSource = xeBus.GetDSLoaiXe();
            cmbLoaiXe.DisplayMember = "TenLoai";
            cmbLoaiXe.ValueMember = "MaLX";
            cmbCN.DataSource = xeBus.GetDSCN();
            cmbCN.DisplayMember = "TenCN";
            cmbCN.ValueMember = "MaCN";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void load_data()
        {
            XeDapBUS xeBus = new XeDapBUS();
            dgvDS.DataSource = xeBus.LayDSXeDap();
        }
        private bool validateData()
        {
            errorProvider1.SetError(txtTenXD, (txtTenXD.Text == "") ? "Hãy nhập tên xe" : "");
            errorProvider2.SetError(txtTrangThai, (txtTrangThai.Text == "") ? "Hãy nhập trạng thái xe" : "");
            return (txtTenXD.Text != "" && txtTrangThai.Text != "");
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
                int loai = Convert.ToInt32(cmbLoaiXe.SelectedValue);
                int cn = Convert.ToInt32(cmbCN.SelectedValue);

                if (xeBus.AddXD(txtTenXD.Text, txtTrangThai.Text, loai, cn))
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
        private string idxe;
        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];
                idxe = row.Cells["MaXD"].Value.ToString();
                txtTenXD.Text = row.Cells["TenXD"].Value.ToString();
                txtTrangThai.Text = row.Cells["TinhTrang"].Value.ToString();
                string maloai = row.Cells["MaLX"].Value.ToString();
                foreach (var item in cmbLoaiXe.Items)
                {
                    DataRowView drv = item as DataRowView;
                    if (drv != null)
                    {
                        if (drv.Row[cmbLoaiXe.ValueMember].ToString() == maloai)
                        {
                            cmbLoaiXe.SelectedItem = item;
                            break;
                        }
                    }
                }
                string cn = row.Cells["MaCN"].Value.ToString();
                foreach (var item in cmbCN.Items)
                {
                    DataRowView drv = item as DataRowView;
                    if (drv != null)
                    {
                        if (drv.Row[cmbCN.ValueMember].ToString() == cn)
                        {
                            cmbCN.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xeBus.DeleteXD(idxe))
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
                MessageBox.Show("Hãy chọn một xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int loai = Convert.ToInt32(cmbLoaiXe.SelectedValue);
                int cn = Convert.ToInt32(cmbCN.SelectedValue);
                if (xeBus.UpdateXD(txtTenXD.Text, txtTrangThai.Text, loai, cn, idxe))
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
