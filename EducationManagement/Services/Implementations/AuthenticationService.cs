using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Linq;
using System.Text;

namespace EducationManagement.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext db = new DataContext();

        public string Token { get; private set; } = "";

        public LoginResultDto Login(LoginDto dto)
        {
            var result = new LoginResultDto();

            dto.Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5(dto.Password));

            var accountFromDb = db.Accounts.FirstOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password);

            if (accountFromDb == null)
            {
                return null;
            }

            result.UserId = accountFromDb.IdUser;
            Token = GenerateToken(result.UserId);
            accountFromDb.Token = Token;

            var group = db.Groups.FirstOrDefault(g => g.Id == accountFromDb.IdGroup);
            if (group != null)
            {
                result.Group = new GroupResponseDto
                {
                    Id = group.Id,
                    Name = group.GroupName
                };
            }
            
            db.SaveChanges();
            
            return result;
        }

        public string GetToken() => Token;

        public string GenerateToken(int? userId)
        {
            var generatedToken = userId + Guid.NewGuid().ToString();
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(generatedToken));
        }
    }
}