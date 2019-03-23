using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Linq;

namespace EducationManagement.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly DataContext db = new DataContext();

        public string Token { get; private set; } = "";

        public LoginResultDto Login(LoginDto dto)
        {
            var result = new LoginResultDto();

            dto.Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5(dto.Password));

            var userFromDb = db.Accounts.FirstOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password);

            if (userFromDb == null)
            {
                return null;
            }

            result.UserId = userFromDb.IdUser;
            Token = GenerateToken(result.UserId);
            userFromDb.Token = Token;
            db.SaveChanges();
            
            return result;
        }

        public string GetToken() => Token;

        public string GenerateToken(int? userId)
        {
            var generatedToken = userId.ToString();
            var ran = new Random();
            const string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (var i = 0; i < 100 - userId.ToString().Length; i++)
            {
                generatedToken += tmp.Substring(ran.Next(0, 63), 1);
            }
            return generatedToken;
        }
    }
}