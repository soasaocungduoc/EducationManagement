using EducationManagement.Dtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Linq;
using System.Text;

namespace EducationManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataContext db = new DataContext();

        public User GetUserInfoById(int id)
        {
            return new User(db.Users.FirstOrDefault(x => x.Id == id && !x.DelFlag));
        }
        
        public bool UpdateAvatar(string token, string url)
        {
            var userId = GetCurrentUserId(token);

            if(userId == -1)
            {
                return false;
            }

            var userFromDb = db.Users.FirstOrDefault(x => x.Id == userId && !x.DelFlag);

            if(userFromDb == null)
            {
                return false;
            }

            userFromDb.Avatar = url;

            db.SaveChanges();

            return true;
        }
        public int GetCurrentUserId(string token)
        {
            string base64Decoded;

            byte[] data = Convert.FromBase64String(token);

            try
            {
                base64Decoded = ASCIIEncoding.ASCII.GetString(data);

                string[] temp = base64Decoded.Split('@');

                int userId;

                if (!int.TryParse(temp[0], out userId))
                {
                    return -1;
                }

                userId = int.Parse(temp[0]);

                return userId;
            }
            catch
            {
                return -1;
            }
        }
    }
}