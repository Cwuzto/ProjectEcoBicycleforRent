using Eco_Bicycle_for_Rent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class LoaiXeBUS
    {
        LoaiXeDL loaixe = new LoaiXeDL();
        public DataTable LayDSLoaiXe()
        {
            return loaixe.GetAllLoaiXe();
        }
        public bool AddLoaiXe(string TenLoai, int SoLuong, int DonGia)
        {
            if (loaixe.AddLoaiXe(TenLoai, SoLuong, DonGia) > 0)
                return true;
            return false;
        }
        public bool UpdateLoaiXe(string TenLoai, int SoLuong, int DonGia, int ma)
        {
            return loaixe.UpdateLoaiXe(TenLoai, SoLuong, DonGia, ma);
        }
        public bool DeleteLoaiXe(string ma)
        {
            return loaixe.DeleteLoaiXe(ma);
        }
    }
}
