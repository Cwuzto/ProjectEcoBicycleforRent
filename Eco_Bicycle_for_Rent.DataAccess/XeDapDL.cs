using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class XeDapDL
    {
        DataTable xe;
        public XeDapDL()
        {
            var query = "SELECT * FROM [XeDap]";
            xe = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllXeDap()
        {
            return xe;
        }
        public DataTable LayDSLoaiXe()
        {
            string query = "SELECT * FROM LoaiXe ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LayDSCN()
        {
            string query = "SELECT * FROM ChiNhanh ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public int AddXe(string tenxe, string tinhtrang, int maloai, int macn)
        {
            int count = 0;

            string query = $"INSERT INTO XeDap ( TenXD, TinhTrang, MaLX, MaCN) VALUES ( @TenXD , @TinhTrang , @MaLX , @MaCN )";

            object[] parameters = { tenxe, tinhtrang, maloai, macn };

            count = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return count;
        }
        public bool UpdateXeDap(string tenxe, string tinhtrang, int maloai, int macn, string ma)
        {
            var query = $"UPDATE [XeDap] SET TenXD= @ten , TinhTrang= @tt , MaLX= @loai , MaCN= @macn  WHERE MaXD = @ma ";
            object[] parameters = { tenxe, tinhtrang, maloai, macn, ma };
            var result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool DeleteXaDap(string maxe)
        {
            var query = $"DELETE [XeDap] WHERE MaXD = '{maxe}' ";
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
