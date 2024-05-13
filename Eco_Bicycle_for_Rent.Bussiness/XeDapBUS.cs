using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class XeDapBUS
    {
        XeDapDL xe = new XeDapDL();
        public DataTable LayDSXeDap()
        {
            return xe.GetAllXeDap();
        }
        public DataTable GetDSLoaiXe()
        {
            return xe.LayDSLoaiXe();
        }
        public DataTable GetDSCN()
        {
            return xe.LayDSCN();
        }
        public bool AddXD(string tenxe, string tinhtrang, int maloai, int macn)
        {
            if (xe.AddXe(tenxe,tinhtrang,maloai,macn) > 0)
                return true;
            return false;
        }
        public bool UpdateXD(string tenxe, string tinhtrang, int maloai, int macn, string ma)
        {
            return xe.UpdateXeDap(tenxe, tinhtrang, maloai, macn, ma);
        }
        public bool DeleteXD(string ma)
        {
            return xe.DeleteXaDap(ma);
        }
    }
}
