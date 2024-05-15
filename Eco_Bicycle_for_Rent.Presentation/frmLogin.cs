using Eco_Bicycle_for_Rent.Bussiness;
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
    public partial class frmLogin : Form
    {
        public static string UserID { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;

            LoginBUS loginBUS = new LoginBUS();

            if (loginBUS.Login(userName, passWord))
            {
                if (loginBUS.IsEmployee(userName))
                {
                    // Mở form nhân viên
                    frmQuanLy frmQL = new frmQuanLy();
                    this.Hide();
                    frmQL.ShowDialog();
                    this.Close();
                }
                else if (loginBUS.IsCustomer(userName))
                {
                    // Mở form khách hàng
                    frmKhachHang frmKH = new frmKhachHang();
                    this.Hide();
                    frmKH.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản không thuộc nhân viên hoặc khách hàng!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sai Username hoặc Password!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Clear();
                txtUsername.Focus();
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Gọi phương thức xử lý đăng nhập
                btnLogin_Click(sender, e); // Gọi phương thức xử lý đăng nhập khi nhấn Enter
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Ngăn chặn kí tự Enter được hiển thị trong ô mật khẩu
                              // Gọi phương thức xử lý đăng nhập
            btnLogin_Click(sender, e);// Gọi phương thức xử lý đăng nhập khi nhấn Enter
                                      // Xóa kí tự xuống dòng (\n) từ chuỗi mật khẩu
            txtPassword.Text = txtPassword.Text.Replace("\n", ""); 
        }
    }
}
