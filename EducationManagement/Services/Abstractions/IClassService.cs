﻿using EducationManagement.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface IClassService
    {
        List<ClassResponseDto> GetClasses();
        List<ClassResponseDto> GetClassesByGradeId(int gradeId);
        ClassResponseDto GetClassByClassid(int id);
        List<ClassResponseDto> GetClassesByHomeroomTeacherId(int id);
        List<ClassResponseDto> GetTeachingClassesByTeacherId(int id);

    }
}
