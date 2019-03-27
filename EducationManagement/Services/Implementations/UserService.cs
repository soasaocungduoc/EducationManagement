using EducationManagement.Dtos;
using EducationManagement.Dtos.OutputDtos;
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

        public User GetUserInfoBbyId(int id)
        {
            return new User(db.Users.FirstOrDefault(x => x.Id == id && !x.DelFlag));
        }
    }
}