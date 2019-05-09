using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly DataContext db = new DataContext();

        public SubjectResponseDto AddSubject(SubjectDto subject)
        {
            try
            {
                if (!IsValidSubject(subject)) return null;
                var subjectInDB = new EM.Database.Schema.Subject
                {
                    Name = subject.SubjectName,
                    TeamId = subject.TeamId
                };
                db.Subjects.Add(subjectInDB);
                db.SaveChanges();
                return GetSubjectBySubjectId(subjectInDB.Id);
            }
            catch (Exception)
            {

                return null;
            }
            
        }
        private bool IsValidSubject(SubjectDto dto)
        {
           var subject =  db.Subjects.Include(y => y.Team).FirstOrDefault(x => !x.DelFlag && x.Name.ToLower().Equals(dto.SubjectName.ToLower()));
            return subject == null ? true : false;
        }

        public SubjectResponseDto GetSubjectBySubjectId(int SubjectId)
        {
            var subject = db.Subjects.Include(y => y.Team).FirstOrDefault(x => !x.DelFlag && x.Id == SubjectId);
            return subject == null ? null : new SubjectResponseDto(subject);
        }

        public List<SubjectResponseDto> GetSubjects()
        {
            return db.Subjects.Include(y => y.Team).Where(x => !x.DelFlag).ToList().
                    Select(x => new SubjectResponseDto(x)).ToList();
        }

        
    }
}