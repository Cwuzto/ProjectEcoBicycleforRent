using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class TramXeDL
    {
        DataTable tramxe;
        public TramXeDL()
        {
            var query = "SELECT * FROM [TramThueXe]";
            tramxe = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetAllTramThueXe()
        {
            return tramxe;
        }
        public DataTable GetDSCN() 
        {
            var query = "SELECT * FROM [ChiNhanh]";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public int AddTramThueXe(string DiaChi,int MaCN)
        {
            int count = 0;

            string query = $"INSERT INTO TramThueXe ( DiaChi, MaCN) VALUES ( @DiaChi , {MaCN} )";

            object[] parameters = { DiaChi };

            count = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            return count;
        }
        public bool UpdateTramThueXe(string DiaChi,int MaCN, int ma)
        {
            var query = $"UPDATE [TramThueXe] SET DiaChi= @diachi , MaCN= {MaCN} WHERE MaTTX = {ma} ";
            object[] parameters = { DiaChi };
            var result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
        public bool DeleteTramThueXe(string ma)
        {
            var query = $"DELETE [TramThueXe] WHERE MaTTX = '{ma}' ";
            var result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
