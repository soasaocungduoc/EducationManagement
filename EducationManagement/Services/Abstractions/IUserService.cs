using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface IUserService
    {
        User GetUserInfoById(int id);

        bool UpdateAvatar(int userId, string url);

        int GetCurrentUserId(string token);

        bool UpdateUser(UserDto user, int id);
    }
}
