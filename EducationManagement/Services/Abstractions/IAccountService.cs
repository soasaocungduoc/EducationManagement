using EducationManagement.Dtos.InputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface IAccountService
    {
        int ChangePassword(PasswordDto password, int id);
    }
}
