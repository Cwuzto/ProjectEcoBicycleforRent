using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class ChiNhanhDL
    {
        DataTable cn;
        public ChiNhanhDL()
        {
            var query = "SELECT * FROM [ChiNhanh]";
            cn = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllChiNhanh()
        {
            return cn;
        }
        public int AddChiNhanh(string TenCN, string DiaChi)
        {
            int count = 0;

            string query = $"INSERT INTO ChiNhanh ( TenCN, DiaChi) VALUES ( @TenCN , @DiaChi )";

            object[] parameters = { TenCN, DiaChi };

            count = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return count;
        }
        public bool UpdateChiNhanh(string TenCN, string DiaChi, int ma)
        {
            var query = $"UPDATE [ChiNhanh] SET TenCN= @tencn , DiaChi= @diachi WHERE MaCN = {ma} ";
            object[] parameters = { TenCN, DiaChi };
            var result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool DeleteChiNhanh(string ma)
        {
            var query = $"DELETE [ChiNhanh] WHERE MaCN = '{ma}' ";
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
