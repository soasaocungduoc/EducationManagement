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
    public class SubjectMarkService : ISubjectMarkService
    {
        private readonly DataContext db = new DataContext();

        public List<SubjectMarkResponseDto> GetSubjectMarks(int userId, int semesterId)
        {
            var student = db.Students.FirstOrDefault(x => !x.DelFlag && x.UserId == userId);
            if (student == null) return null;
            var list = new List<SubjectMarkResponseDto>();

            list = db.Subjects.Where(x => !x.DelFlag && (!x.Name.Equals("Sinh hoạt") || !x.Name.Equals("Chào cờ"))).ToList()
               .Select(x => new SubjectMarkResponseDto
                {
                    SubjectName = x.Name,
                    ListMark = GetMarkList(student.Id, x.Id, semesterId)
                }).ToList();
            return list;
        }

        private List<MarkResponseDto> GetMarkList(int studentId, int subjectId, int semesterId)
        {
            return db.SubjectMarks.Include(u => u.TypeMark)
                    .Where(x => !x.DelFlag && x.StudentId == studentId && x.SubjectId == subjectId && x.SemesterId == semesterId)
                    .OrderBy(x => x.TypeMarkId).Select(x => new MarkResponseDto
                    {
                        Id = x.Id,
                        Mark = x.Mark,
                        TypeMark = x.TypeMark.Id
                    }).ToList();
        }
    }
}