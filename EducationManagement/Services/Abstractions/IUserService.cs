using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;

namespace EducationManagement.Services.Abstractions
{
    public interface IUserService
    {

        User GetUserInfoById(int id);

        bool UpdateAvatar(int userId, UrlDto dto);

        int GetCurrentUserId(string token);

        User UpdateUser(UserDto user, int id);

        List<UserResponseDto> GetUsers();

    }
}
