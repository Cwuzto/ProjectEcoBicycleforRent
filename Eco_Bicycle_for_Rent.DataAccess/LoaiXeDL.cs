using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class LoaiXeDL
    {
        DataTable loaixe;
        public LoaiXeDL()
        {
            var query = "SELECT * FROM [LoaiXe]";
            loaixe = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllLoaiXe()
        {
            return loaixe;
        }
        public int AddLoaiXe(string TenLoai,int SoLuong,int DonGia)
        {
            int count = 0;

            string query = $"INSERT INTO LoaiXe ( TenLoai, SoLuong, DonGiaChoThue) VALUES ( @TenLoai , {SoLuong}, {DonGia} )";

            object[] parameters = { TenLoai};

            count = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return count;
        }
        public bool UpdateLoaiXe(string TenLoai, int SoLuong, int DonGia, int ma)
        {
            var query = $"UPDATE [LoaiXe] SET TenLoai= @tenloai , SoLuong= {SoLuong}, DonGiaChoThue= {DonGia} WHERE MaLX = {ma} ";
            object[] parameters = { TenLoai };
            var result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool DeleteLoaiXe(string ma)
        {
            var query = $"DELETE [LoaiXe] WHERE MaLX = '{ma}' ";
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
