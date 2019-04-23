using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class SchoolYearService : ISchoolYearService
    {
        private readonly DataContext db = new DataContext();
        public List<SchoolYearResponseDto> GetSchoolYears()
        {
            try
            {
                return db.SchoolYears.Where(y => !y.DelFlag).ToList().Select(x => new SchoolYearResponseDto(x)).ToList();
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}