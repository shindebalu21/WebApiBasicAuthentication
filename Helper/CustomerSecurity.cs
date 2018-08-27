using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBasicAuthentication.Helper
{
    public static class CustomerSecurity
    {
        public static bool Login(string Username,string Password)
        {
            using (NORTHWNDEntities1 db =new NORTHWNDEntities1())
            {
                return db.Customers1.Any(user => user.UserName.Equals(Username, StringComparison.OrdinalIgnoreCase) && user.PassWord.Equals(Password, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}