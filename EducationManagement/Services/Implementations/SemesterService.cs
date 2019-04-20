using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class SemesterService : ISemesterService
    {
        private readonly DataContext db = new DataContext();
        public List<SemesterResponseDto> GetSemesters(int id)
        {
            try
            {
                return db.Semesters.Where(s => !s.DelFlag && s.ScholasticId == id).ToList().Select(x => new SemesterResponseDto(x)).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}