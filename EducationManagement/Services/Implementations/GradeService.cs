using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly DataContext db = new DataContext();
        public List<GradeResponseDto> GetGrades()
        {
            return db.Grades.Where(x => !x.DelFlag).ToList()
                .Select(x => new GradeResponseDto(x)).ToList();
        }
    }
}