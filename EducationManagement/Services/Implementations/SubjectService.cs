using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace EducationManagement.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly DataContext db = new DataContext();

        public List<SubjectResponseDto> GetSubjects()
        {
            try
            {
                return db.Subjects.Include(y => y.Team).Where(x => !x.DelFlag).ToList().
                    Select(x => new SubjectResponseDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        TeamInfo = new TeamResponseDto(x.Team)
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}