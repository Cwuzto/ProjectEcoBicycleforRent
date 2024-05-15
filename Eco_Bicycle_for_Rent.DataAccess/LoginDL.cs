using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Bicycle_for_Rent.DataAccess
{
    public class LoginDL
    {
        private static LoginDL instance;

        public static LoginDL Instance
        {
            get { if (instance == null) instance = new LoginDL(); return instance; }
            private set { instance = value; }
        }

        private LoginDL() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Logins @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }
        public bool IsEmployee(string userName)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE UserName = @userName";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { userName }));
            return count > 0;
        }

        public bool IsCustomer(string userName)
        {
            string query = "SELECT COUNT(*) FROM KhachHang WHERE UserName = @userName";
            int count = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { userName }));
            return count > 0;
        }
    }
}
