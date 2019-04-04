using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationManagement.Dtos.OutputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface ISchoolInformationService
    {
        SchoolInformationDto GetSchoolInformation();
    }
}
