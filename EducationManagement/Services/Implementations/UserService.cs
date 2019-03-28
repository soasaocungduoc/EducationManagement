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
        
        public bool UpdateAvatar(int userId, string url)
        {
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
            var data = Convert.FromBase64String(token);

            try
            {
                var base64Decoded = Encoding.ASCII.GetString(data);

                var temp = base64Decoded.Split('@');

                return int.Parse(temp[0]);
            }
            catch
            {
                return -1;
            }
        }
    }
}