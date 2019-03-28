using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System.Linq;

namespace EducationManagement.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly DataContext db = new DataContext();

        public LoginResultDto Login(LoginDto dto)
        {
            var result = new LoginResultDto();

            dto.Password = DatabaseCreation.GetMd5(DatabaseCreation.GetSimpleMd5(dto.Password));

            var accountFromDb = db.Accounts.FirstOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password && !x.DelFlag);

            if (accountFromDb == null)
            {
                return null;
            }

            var user = db.Users.FirstOrDefault(u => u.Id == accountFromDb.IdUser && !u.DelFlag);
            if (user != null)
            {
                result.User = new UserInformationResponseDto(user, accountFromDb.UserName);
            }

            var group = db.Groups.FirstOrDefault(g => g.Id == accountFromDb.IdGroup && !g.DelFlag);
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
    }
}