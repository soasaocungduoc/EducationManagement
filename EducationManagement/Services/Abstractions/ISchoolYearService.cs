﻿using EducationManagement.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface ISchoolYearService
    {
        List<SchoolYearResponseDto> GetSchoolYears();
    }
}
