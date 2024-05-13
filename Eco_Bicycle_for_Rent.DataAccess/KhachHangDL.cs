using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class KhachHangDL
    {
        DataTable kh;
        public KhachHangDL()
        {
            var query = "SELECT * FROM [KhachHang]";
            kh = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllKhachHang()
        {
            return kh;
        }
        public DataTable LayDSLoaiKhach()
        {
            string query = "SELECT * FROM LoaiKhachHang ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public int AddKhachHang(string HoTen,string SDT,string CCCD,string GioiTinh,string Email,string DiaChi,int SoDu,DateTime NgayDangKy,string TrangThaiThe,string UserName,string Password,int MaLKH)
        {
            int count = 0;

            string query = $"INSERT INTO KhachHang ( HoTen, SDT, CCCD, GioiTinh, Email, DiaChi, SoDu, NgayDangKy, TrangThaiThe, UserName, Password, MaLKH) VALUES ( @HoTen , @SDT , @CCCD , @GioiTinh , @Email , @DiaChi , {SoDu} , @NgayDangKy , @TrangThaiThe , @UserName , @Password , {MaLKH} )";

            object[] parameters = { HoTen, SDT, CCCD, GioiTinh, Email, DiaChi, NgayDangKy, TrangThaiThe, UserName, Password };

            count = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return count;
        }
        public bool UpdateKhachHang(string HoTen, string SDT, string CCCD, string GioiTinh, string Email, string DiaChi, int SoDu, DateTime NgayDangKy, string TrangThaiThe, string UserName, string Password, int MaLKH, int ma)
        {
            var query = $"UPDATE [KhachHang] SET HoTen= @ho , SDT= @sdt , CCCD= @cccd , GioiTinh= @gt , Email= @email , DiaChi= @diachi , SoDu= {SoDu}, NgayDangKy= CONVERT(date, @ngaydky ), TrangThaiThe= @trangthai , UserName= @user , Password= @pass , MaLKH= {MaLKH}  WHERE MaKH = {ma} ";
            object[] parameters = { HoTen, SDT, CCCD, GioiTinh, Email, DiaChi, NgayDangKy, TrangThaiThe, UserName, Password };
            var result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool DeleteKH(string ma)
        {
            var query = $"DELETE [KhachHang] WHERE MaKH = '{ma}' ";
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
