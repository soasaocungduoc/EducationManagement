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

        private readonly SemesterService semesterService = new SemesterService();

        public List<SchoolYearResponseDto> GetSchoolYears()
        {
            try
            {
                return db.SchoolYears.Where(y => !y.DelFlag).ToList().Select(x => new SchoolYearResponseDto {
                    Id = x.Id,
                    StartYear = x.StartYear,
                    EndYear = x.EndYear,
                    IsCurrent = (x.StartYear <= Convert.ToInt32(DateTime.Now.Year.ToString()) && (x.EndYear >= Convert.ToInt32(DateTime.Now.Year.ToString()))),
                    SemesterInfo = semesterService.GetSemestersByYearId(x.Id)
            }).ToList();
                
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}