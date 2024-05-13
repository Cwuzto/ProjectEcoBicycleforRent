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
    public partial class frmQLTramXe : Form
    {
        TramXeBUS tramBus=new TramXeBUS();
        public frmQLTramXe()
        {
            InitializeComponent();
        }

        private void frmQLTramXe_Load(object sender, EventArgs e)
        {
            dgvDS.DataSource = tramBus.LayDSTramXe();
            cmbChiNhanh.DataSource=tramBus.LayDSChiNhanh();
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "MaCN";
        }
        private void load_data()
        {
            TramXeBUS tramBus = new TramXeBUS();
            dgvDS.DataSource = tramBus.LayDSTramXe();
        }
        private bool validateData()
        {
            errorProvider1.SetError(txtDiaChi, (txtDiaChi.Text == "") ? "Hãy nhập địa chỉ trạm thuê xe" : "");
            return (txtDiaChi.Text != "");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!validateData())
            {
                MessageBox.Show("Hãy chọn một trạm xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int cn = Convert.ToInt32(cmbChiNhanh.SelectedValue);
                if (tramBus.UpdateTramXe(txtDiaChi.Text,cn,Convert.ToInt32(idTram)))
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
                MessageBox.Show("Hãy chọn một trạm thuê xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tramBus.DeleteTramXe(idTram))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_data();
                return;
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
                int cn = Convert.ToInt32(cmbChiNhanh.SelectedValue);
                if (tramBus.AddTramXe(txtDiaChi.Text,cn ))
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
        private string idTram;
        private void dgvDS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];
                idTram = row.Cells["MaTTX"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                string cn = row.Cells["MaCN"].Value.ToString();
                foreach (var item in cmbChiNhanh.Items)
                {
                    DataRowView drv = item as DataRowView;
                    if (drv != null)
                    {
                        if (drv.Row[cmbChiNhanh.ValueMember].ToString() == cn)
                        {
                            cmbChiNhanh.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
    }
}
