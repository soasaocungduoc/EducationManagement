﻿using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface IAuthenticationService
    {
        LoginResultDto Login(LoginDto dto);

        string GetToken();

        bool Logout(string token);
    }
}