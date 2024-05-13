using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class KhachHangBUS
    {
        KhachHangDL kh = new KhachHangDL();
        public DataTable LayDSKH()
        {
            return kh.GetAllKhachHang();
        }
        public DataTable GetDSLoaiKH()
        {
            return kh.LayDSLoaiKhach();
        }
        public bool AddKH(string HoTen, string SDT, string CCCD, string GioiTinh, string Email, string DiaChi, int SoDu, DateTime NgayDangKy, string TrangThaiThe, string UserName, string Password, int MaLKH)
        {
            if (kh.AddKhachHang(HoTen, SDT, CCCD, GioiTinh, Email, DiaChi, SoDu, NgayDangKy, TrangThaiThe, UserName, Password, MaLKH) > 0)
                return true;
            return false;
        }
        public bool UpdateKH(string HoTen, string SDT, string CCCD, string GioiTinh, string Email, string DiaChi, int SoDu, DateTime NgayDangKy, string TrangThaiThe, string UserName, string Password, int MaLKH, int ma)
        {
            return kh.UpdateKhachHang(HoTen, SDT, CCCD, GioiTinh, Email, DiaChi, SoDu, NgayDangKy, TrangThaiThe, UserName, Password, MaLKH, ma);
        }
        public bool DeleteKH(string ma)
        {
            return kh.DeleteKH(ma);
        }
    }
}
