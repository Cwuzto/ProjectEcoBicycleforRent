using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class DSTramTaiChiNhanhBUS
    {
        DSTramTaiChiNhanhDL dst=new DSTramTaiChiNhanhDL();
        public DataTable DSTramTaiCN()
        {
          return dst.LayDSTramTaiCN();
        }
        public DataTable DSCN()
        {
            return dst.LayDSCN();
        }
        public DataTable LayDSTramTheoCN(int macn)
        {
            return dst.LayDSTramTheoCN(macn);
        }
    }
}
