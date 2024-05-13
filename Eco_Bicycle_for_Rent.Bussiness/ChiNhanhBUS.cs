using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class ChiNhanhBUS
    {
        ChiNhanhDL cn = new ChiNhanhDL();
        public DataTable LayDSChiNhanh()
        {
            return cn.GetAllChiNhanh();
        }
        public bool AddChiNhanh(string TenCN, string DiaChi)
        {
            if (cn.AddChiNhanh(TenCN, DiaChi) > 0)
                return true;
            return false;
        }
        public bool UpdateChiNhanh(string TenCN, string DiaChi, int ma)
        {
            return cn.UpdateChiNhanh(TenCN, DiaChi, ma);
        }
        public bool DeleteChiNhanh(string ma)
        {
            return cn.DeleteChiNhanh(ma);
        }
    }
}
