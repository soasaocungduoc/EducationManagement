using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationManagement.Dtos;
using EducationManagement.Dtos.OutputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface IUserService
    {
        User GetUserInfoById(int id);

        bool UpdateAvatar(string token, string url);

        int GetCurrentUserId(string token);
    }
}
