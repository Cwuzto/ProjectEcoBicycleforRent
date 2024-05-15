using DevExpress.Export;
using DevExpress.Utils.Drawing;
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
    public partial class frmDangKy : Form
    {
        private Size savedSize;
        public frmDangKy()
        {
            InitializeComponent();

            // Ẩn các groupbox ban đầu
            groupboxTienMat.Visible = false;
            groupboxNganHang.Visible = false;
            savedSize = this.Size;

            // Thêm sự kiện CheckedChanged cho các checkbox
            checkboxTraTruoc.CheckedChanged += new EventHandler(Checkbox_CheckedChanged);
            checkboxTraSau.CheckedChanged += new EventHandler(Checkbox_CheckedChanged);
        }
        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem checkbox nào đã kích hoạt sự kiện
            CheckBox currentCheckbox = sender as CheckBox;

            if (currentCheckbox == checkboxTraTruoc && checkboxTraTruoc.Checked)
            {
                // Khi checkbox Trả trước được chọn
                checkboxTraSau.Checked = false;
                groupboxTienMat.Visible = true;
                groupboxTienMat.BringToFront();
                groupboxNganHang.Visible = false;
                // Thay đổi kích thước form
                this.Size = new Size(600, 453); // Thay đổi kích thước form theo yêu cầu
            }
            else if (currentCheckbox == checkboxTraSau && checkboxTraSau.Checked)
            {
                // Khi checkbox Trả sau được chọn
                checkboxTraTruoc.Checked = false;
                groupboxNganHang.Visible = true;
                groupboxNganHang.BringToFront();
                groupboxTienMat.Visible = false;
                // Thay đổi kích thước form
                this.Size = new Size(600, 453); // Thay đổi kích thước form theo yêu cầu
            }
            else if (!checkboxTraTruoc.Checked && !checkboxTraSau.Checked)
            {
                // Khi không có checkbox nào được chọn
                groupboxTienMat.Visible = false;
                groupboxNganHang.Visible = false;
                // Thay đổi kích thước form
                this.Size = savedSize; // Thay đổi kích thước form theo yêu cầu
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHomePage frmHomePage = new frmHomePage(); 
            frmHomePage.ShowDialog();  
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            frmHomePage frmHomePage = new frmHomePage();
            frmHomePage.ShowDialog();
            this.Close();
        }
    }
}
