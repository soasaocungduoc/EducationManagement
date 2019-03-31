using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EducationManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataContext db = new DataContext();

        public User GetUserInfoById(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            return user == null ? null : new User(user);
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

        public bool UpdateUser(UserDto user, int id)
        {
            DbContextTransaction transaction = db.Database.BeginTransaction();
            var u = db.Users.FirstOrDefault(x => x.Id == id && !x.DelFlag);
            if (u == null) return false;
            u.Address = user.Address;
            u.PhoneNumber = user.PhoneNumber;
            db.SaveChanges();
            transaction.Commit();
            return true;
        }
    }
}