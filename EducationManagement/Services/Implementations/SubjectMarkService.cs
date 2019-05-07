using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EducationManagement.Dtos.InputDtos;
using EM.Database.Schema;

namespace EducationManagement.Services.Implementations
{
    public class SubjectMarkService : ISubjectMarkService
    {
        private readonly DataContext db = new DataContext();

        public bool Add(SubjectMarkDto dto)
        {
            if(dto == null)
            {
                return false;
            }

            if (dto.Marks == null)
            {
                return false;
            }

            if(CheckEndMarkFromDto(dto) == false)
            {
                return false;
            }

            try
            {
                var subjectMarks = new List<SubjectMark>();

                foreach (MarkDto mark in dto.Marks)
                {
                    if (mark.TypeMarkId == 4)
                    {
                        if (CheckEndMarkFromDb(mark.StudentId, dto.SubjectId) == true)
                        {
                            return false;
                        }
                    }
                    var subjectMark = new SubjectMark()
                    {
                        SubjectId = dto.SubjectId,
                        SemesterId = dto.SemesterId,
                        StudentId = mark.StudentId,
                        TypeMarkId = mark.TypeMarkId,
                        Mark = mark.Mark
                    };

                    subjectMarks.Add(subjectMark);
                }

                db.SubjectMarks.AddRange(subjectMarks);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        private bool CheckEndMarkFromDb(int studentId, int subjectId)
        {
            var subjectMarkFromDb = db.SubjectMarks
                .FirstOrDefault(x => x.StudentId == studentId && x.TypeMarkId == 4 && x.SubjectId == subjectId && x.DelFlag == false);

            if(subjectMarkFromDb == null)
            {
                return false;
            }

            return true;
        }

        private bool CheckEndMarkFromDto(SubjectMarkDto dto)
        {
            var EndMarks = dto.Marks.Where(x => x.TypeMarkId == 4);

            var dupes = EndMarks.GroupBy(x => new { x.TypeMarkId, x.StudentId })
                   .Where(x => x.Skip(1).Any()).ToArray();
            
            if(dupes.Length == 0)
            {
                return true;
            }

            return false;
        }

        public List<SubjectMarkResponseDto> GetSubjectMarks(int userId, int semesterId)
        {
            var student = db.Students.FirstOrDefault(x => !x.DelFlag && x.UserId == userId);
            if (student == null) return null;
            var list = new List<SubjectMarkResponseDto>();

            list = db.Subjects.Where(x => !x.DelFlag && (!x.Name.Equals("Sinh hoạt") && !x.Name.Equals("Chào cờ"))).ToList()
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
                        TypeMark = x.TypeMark.Name
                    }).ToList();
        }
    }
}