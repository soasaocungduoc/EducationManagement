using EducationManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface ITeacherService
    {
        List<Teacher> GetListOfTeachers();
    }
}
