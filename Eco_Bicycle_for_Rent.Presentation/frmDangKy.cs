using DevExpress.Export;
using DevExpress.Utils.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string email = txtEmail.Text;
            string sdt = txtSDT.Text;
            string tratruoc = txtTraTruoc.Text;
            string trasau = txtTraSau.Text;

            bool isEmailValid = email.EndsWith("@gmail.com");
            bool isSDTValid = Regex.IsMatch(sdt, @"^0\d{9}$");
            bool isPaymentMethodSelected = checkboxTraTruoc.Checked || checkboxTraSau.Checked;
            bool isNumberAccountNull = string.IsNullOrWhiteSpace(txtTraSau.Text);

            if (!isEmailValid)
            {
                MessageBox.Show("Email phải có dạng @gmail.com");
            }
            else if (!isSDTValid)
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0");
            }
            else if (!isPaymentMethodSelected)
            {
                MessageBox.Show("Yêu cầu chọn phương thức nạp");
            }
            else if (string.IsNullOrWhiteSpace(tratruoc) && checkboxTraTruoc.Checked)
            {
                MessageBox.Show("Yêu cầu nhập số tiền nạp");
            }
            else if (!decimal.TryParse(tratruoc, out decimal amount) && checkboxTraTruoc.Checked || amount < 1000000 && checkboxTraTruoc.Checked)
            {
                MessageBox.Show("Số tiền nạp phải lớn hơn hoặc bằng 1,000,000");
            }
            else if (isNumberAccountNull && checkboxTraSau.Checked)
            {
                MessageBox.Show("Yêu cầu nhập số thẻ ngân hàng");
            }
            else
            {
                MessageBox.Show("Đăng ký Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Đăng ký Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmHomePage frmHomePage = new frmHomePage();
                frmHomePage.ShowDialog();
                this.Close();
            }
        }

    }
}
