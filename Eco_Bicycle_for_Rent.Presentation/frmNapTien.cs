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
    public partial class frmNapTien : Form
    {
        public frmNapTien()
        {
            InitializeComponent();

            // Thêm sự kiện CheckedChanged cho các checkbox
            cbTienMat.CheckedChanged += new EventHandler(cbTienMat_CheckedChanged);
            cbNganHang.CheckedChanged += new EventHandler(cbNganHang_CheckedChanged);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nạp tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbNganHang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNganHang.Checked)
            {
                cbTienMat.Checked = false;
            }
        }

        private void cbTienMat_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTienMat.Checked)
            {
                cbNganHang.Checked = false;
            }
        }
    }
}
