using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class TramXeBUS
    {
        TramXeDL tr_xe = new TramXeDL();
        public DataTable LayDSTramXe()
        {
            return tr_xe.GetAllTramThueXe();
        }
        public DataTable LayDSChiNhanh()
        {
            return tr_xe.GetDSCN();
        }
        public bool AddTramXe(string DiaChi,int MaCN)
        {
            if (tr_xe.AddTramThueXe(DiaChi,MaCN) > 0)
                return true;
            return false;
        }
        public bool UpdateTramXe(string DiaChi,int MaCN, int ma)
        {
            return tr_xe.UpdateTramThueXe(DiaChi, MaCN, ma);
        }
        public bool DeleteTramXe(string ma)
        {
            return tr_xe.DeleteTramThueXe(ma);
        }
    }
}
