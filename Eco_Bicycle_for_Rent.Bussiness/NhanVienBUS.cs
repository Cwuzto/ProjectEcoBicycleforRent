using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class NhanVienBUS
    {
        NhanVienDL nv = new NhanVienDL();
        public DataTable LayDSNhanVien()
        {
            return nv.GetAllNhanVien();
        }
        public DataTable GetDSLoaiNV()
        {
            return nv.LayDSLoaiNV();
        }
        public DataTable GetDSTramTX()
        {
            return nv.LayDSTram();
        }
        public bool AddEmployee(string hoten, string sdt, string diachi, string pass, string user, string gt, int maloainv, string email, string matttx)
        {
            if (maloainv != 1 && matttx.Equals("") )
                return false;
            if (maloainv == 1)
                matttx = "NULL";
            if (nv.AddNhanVien(hoten, sdt, diachi, pass,user,gt,maloainv,email,matttx) > 0)
                return true;
            return false;
        }
        public bool UpdateNV(string manv, string hoten, string sdt, string diachi, string pass, string user, string gt, int maloainv, string email, string matttx)
        {
            if (maloainv != 1 && matttx.Equals(""))
                return false;
            if (maloainv == 1)
                matttx = "NULL";
            return nv.UpdateNhanVien(manv,hoten, sdt, diachi, pass, user, gt, maloainv, email, matttx);
        }
        public bool DeleteNV(string manv)
        {
            return nv.DeleteNhanVien(manv);
        }
    }
}
