using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface ILoginService
    {
        LoginResultDto Login(LoginDto dto);

        string GetToken();
    }
}
