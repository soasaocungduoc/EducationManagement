using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface IUserService
    {
        User GetUserInfoById(int id);

        bool UpdateAvatar(int userId, string url);

        int GetCurrentUserId(string token);

        User UpdateUser(UserDto user, int id);
    }
}
