using EducationManagement.Commons;
using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
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
        
        public bool UpdateAvatar(int userId, UrlDto dto)
        {
            var userFromDb = db.Users.FirstOrDefault(x => x.Id == userId && !x.DelFlag);

            if(userFromDb == null)
            {
                return false;
            }

            userFromDb.Avatar = dto.Url;

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

        public User UpdateUser(UserDto user, int id)
        {
            try
            {
                DbContextTransaction transaction = db.Database.BeginTransaction();
                var u = db.Users.FirstOrDefault(x => x.Id == id && !x.DelFlag);
                if (u == null) return null;
                u.Address = user.Address;
                u.PhoneNumber = user.PhoneNumber;
                db.SaveChanges();
                transaction.Commit();
                return GetUserInfoById(id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<UserResponseDto> GetUsers()
        {
            return db.Users.Where(x => !x.DelFlag).ToList().
                Select(x => new UserResponseDto(x)).ToList();
        }

        public bool DeleteUser(int id)
        {
            var user = db.Users.FirstOrDefault(x => !x.DelFlag && x.Id == id);
            if (user == null) return false;
            var account = db.Accounts.FirstOrDefault(x => !x.DelFlag && x.UserId == user.Id);
            if (account == null) return false;
            user.DelFlag = true;
            account.DelFlag = true;
            db.SaveChanges();
            return true;
        }

        public bool AddUser(UserInfoDto userInfo)
        {
            try
            {
                var user = new EM.Database.Schema.User();
                var account = new EM.Database.Schema.Account();

                user.FirstName = userInfo.FirstName;
                user.LastName = userInfo.LastName;
                user.Gender = userInfo.Gender;
                user.Birthday = userInfo.Birthday;
                user.Address = userInfo.Address;
                user.PhoneNumber = userInfo.PhoneNumber;
                user.IdentificationNumber = userInfo.IdentificationNumber;
                user.Avatar = userInfo.Avatar;
                db.Users.Add(user);
                db.SaveChanges();

                account.UserName = userInfo.Username;
                account.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(userInfo.Password));
                account.UserId = user.Id;
                account.GroupId = userInfo.IsAdmin ? db.Groups.FirstOrDefault(x => !x.DelFlag && x.Name.Equals("Admin")).Id :
                                    db.Groups.FirstOrDefault(x => !x.DelFlag && x.Name.Equals("Mod")).Id;
                db.Accounts.Add(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            

        }
    }
}