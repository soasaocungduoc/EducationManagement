using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using EM.Database.Schema;
using System;
using System.Linq;

namespace EducationManagement.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly DataContext db = new DataContext();
        public LoginResultDto Login(LoginDto dto)
        {
            var result = new LoginResultDto();
            if (dto == null)
            {
                return null;
            }

            dto.Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5(dto.Password));

            Account userFromDb = db.Accounts.FirstOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password);

            if (userFromDb == null)
            {
                return null;
            }

            string token = CreateToken();

            userFromDb.Token = token;
            db.SaveChanges();

            result.UserId = userFromDb.IdUser;

            return result;
        }

        public string CreateToken()
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