using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly DataContext db = new DataContext();

        public List<ClassResponseDto> GetClasses()
        {
            var list = db.Classes.Include(t => t.Teacher).Include(g => g.Grade).Include(r => r.Room)
                 .Where(x => !x.DelFlag).OrderBy(x=>x.GradeId).ToList();
            if (list == null) return new List<ClassResponseDto>();
            return list.Select(x => new ClassResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                GradeName = x.Grade.Name,
                NumberOfStudents = x.NumberOfStudents,
                RoomNumber = x.Room.RoomNumber,
                TeacherName = db.Teachers.Include(u => u.User).FirstOrDefault(p => !p.DelFlag && p.Id == x.TeacherId).User.FirstName
            }).ToList();
        }

        public List<ClassResponseDto> GetClassesByGradeId(int gradeId)
        {
            var grade = db.Grades.FirstOrDefault(x => !x.DelFlag && x.Id == gradeId);
            if (grade == null) return null;
            var list = db.Classes.Include(t => t.Teacher).Include(g => g.Grade).Include(r => r.Room)
                 .Where(x => !x.DelFlag && x.GradeId == gradeId).ToList();
            if (list == null) return new List<ClassResponseDto>();
            return list.Select(x => new ClassResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                GradeName = x.Grade.Name,
                NumberOfStudents = x.NumberOfStudents,
                RoomNumber = x.Room.RoomNumber,
                TeacherName = db.Teachers.Include(u => u.User).FirstOrDefault(p => !p.DelFlag && p.Id == x.TeacherId).User.FirstName
            }).ToList();
        }
    }
}