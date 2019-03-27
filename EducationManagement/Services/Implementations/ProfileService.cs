using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Linq;
using System.Text;

namespace EducationManagement.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext db = new DataContext();

        public bool CheckExistToken(string token) => db.Accounts.FirstOrDefault(x => x.Token.Equals(token)) == null;

        public ProfileResultDto GetUserInfoBbyId(int id)
        {
            return db.Users.Select(u => new ProfileResultDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Avatar = u.Avatar,
                Gender = u.Gender,
                Birthday = u.Birthday,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                IdentificationNumber = u.IdentificationNumber
            }).FirstOrDefault(x => x.Id == id);
        }


    }
}