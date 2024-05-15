using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eco_Bicycle_for_Rent.DataAccess;

namespace Eco_Bicycle_for_Rent.Bussiness
{
    public class LoginBUS
    {
        private LoginDL loginDL;
        public LoginBUS()
        {
            loginDL = LoginDL.Instance;
        }
        public bool Login(string userName, string passWord)
        {
            return LoginDL.Instance.Login(userName, passWord);
        }

        public bool IsEmployee(string userName)
        {
            return loginDL.IsEmployee(userName);
        }

        public bool IsCustomer(string userName)
        {
            return loginDL.IsCustomer(userName);
        }
    }
}
