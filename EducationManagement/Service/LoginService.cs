using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EM.Database;
using EM.Database.Schema;
using EducationManagement.Models;

namespace EducationManagement.Service
{
    public class LoginService
    {
        DataContext db = new DataContext();
        public LoginResult CheckLogin(Login login)
        {
            var result = new LoginResult();
            if(login == null)
            {
                return null;
            }

            login.password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5(login.password));

            Account userFromDb = db.Accounts.FirstOrDefault(x => x.UserName == login.username && x.Password == login.password);

            if (userFromDb == null)
            {
                return null;
            }

            string token = CreateToken();

            userFromDb.Token = token;
            db.SaveChanges();

            result.Token = token;
            result.UserId = userFromDb.IdUser;

            return result;
        }
        
        public static string CreateToken()
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < 100; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            return token;
        }
    }
}