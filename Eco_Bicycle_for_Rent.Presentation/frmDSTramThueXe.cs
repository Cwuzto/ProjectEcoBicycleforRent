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
    public partial class frmDSTramThueXe : Form
    {
        DSTramTaiChiNhanhBUS dstram=new DSTramTaiChiNhanhBUS();
        public frmDSTramThueXe()
        {
            InitializeComponent();
        }

        private void frmDSTramThueXe_Load(object sender, EventArgs e)
        {
            dgvDSTram.DataSource= dstram.DSTramTaiCN();
            cmbCN.DataSource= dstram.DSCN();
            cmbCN.DisplayMember = "TenCN";
            cmbCN.ValueMember = "MaCN";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maCN =cmbCN.SelectedValue.ToString();
            if (int.TryParse(maCN, out int cnValue))
            {
                DataTable dt = dstram.LayDSTramTheoCN(cnValue);
                dgvDSTram.DataSource = dt;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
