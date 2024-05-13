using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class DSTramTaiChiNhanhDL
    {
        DataTable dst;
        public DSTramTaiChiNhanhDL()
        {
            var query = "Select TTX.DiaChi as DiaChiTram, TenCN, CN.DiaChi as DiaChiCN FROM TramThueXe TTX, ChiNhanh CN WHERE TTX.MaCN=CN.MaCN";
            dst = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable LayDSTramTaiCN()
        {
            return dst;
        }
        public DataTable LayDSTramTheoCN(int macn)
        {
            var query = $"Select TTX.DiaChi as DiaChiTram, TenCN, CN.DiaChi as DiaChiCN FROM TramThueXe TTX, ChiNhanh CN WHERE TTX.MaCN=CN.MaCN and CN.MaCN={macn}";
            return DataProvider.Instance.ExecuteQuery(query); ;
        }
        public DataTable LayDSCN()
        {
            var query = "Select * From ChiNhanh ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
