using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class NhanVienDL
    {
        DataTable NV;
        public NhanVienDL()
        {
            var query = "SELECT * FROM [NhanVien]";
            NV = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllNhanVien()
        {
            return NV;
        }
        public DataTable LayDSLoaiNV()
        {
            string query = "SELECT * FROM LoaiNhanVien ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LayDSTram()
        {
            string query = "SELECT * FROM TramThueXe ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public int AddNhanVien(string hoten, string sdt, string diachi, string pass, string user, string gt, int maloainv, string email, string matttx)
        {
            int count = 0;

            string query = $"INSERT INTO NhanVien ( HoTenNV, DiaChiNV, SDT, Email, GioiTinh,  MaLNV, MaTTX, UserName, Password) VALUES ( @HoTenNV , @DiaChiNV , @SDT , @Email , @GioiTinh , @MaLNV , {matttx} , @UserName , @Password )";

            object[] parameters = { hoten , diachi , sdt , email , gt , maloainv , user , pass };

            count = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return count;
        }
        public bool UpdateNhanVien(string manv, string hoten, string sdt, string diachi, string pass, string user, string gt, int maloainv, string email, string matttx)
        {
            var query = $"UPDATE [NhanVien] SET HoTenNV= @hotennv , DiaChiNV= @diachi , SDT= @sdt , Email= @email , GioiTinh= @gt ,  MaLNV= @maloai , MaTTX= {matttx}, UserName= @user , Password= @pass  WHERE MaNV = @manv ";
            object[] parameters = { hoten, diachi, sdt, email, gt, maloainv, user, pass, manv };
            var result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool DeleteNhanVien(string manv)
        {
            var query = $"DELETE [NhanVien] WHERE MaNV = '{manv}' ";
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
