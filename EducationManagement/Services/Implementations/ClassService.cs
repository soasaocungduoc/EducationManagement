using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using MoreLinq;

namespace EducationManagement.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly DataContext db = new DataContext();

        private readonly TeacherService _teacherService = new TeacherService();


        public ClassResponseDto GetClassByClassid(int id)
        {
            var Class = db.Classes.Include(t => t.Teacher).Include(g => g.Grade).Include(r => r.Room).FirstOrDefault(x => !x.DelFlag && x.Id == id);
            return Class == null ? null :
             new ClassResponseDto
            {
                Id = Class.Id,
                Name = Class.Name,
                GradeName = Class.Grade.Name,
                NumberOfStudents = Class.NumberOfStudents,
                RoomNumber = GetRoomNumber(Class.Id),
                 TeacherName = _teacherService.GetTeacherName(Class.TeacherId)
            };
        }

        public List<ClassResponseDto> GetClasses()
        {
            var list = db.Classes.Include(t => t.Teacher).Include(g => g.Grade).Include(r => r.Room)
                 .Where(x => !x.DelFlag).OrderBy(x=>x.GradeId).ToList();
            return list == null ? new List<ClassResponseDto>() :
            list.Select(x => new ClassResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                GradeName = x.Grade.Name,
                NumberOfStudents = x.NumberOfStudents,
                RoomNumber = GetRoomNumber(x.Id),
                TeacherName = _teacherService.GetTeacherName(x.TeacherId)
            }).ToList();
        }

        public List<ClassResponseDto> GetClassesByGradeId(int gradeId)
        {
            var grade = db.Grades.FirstOrDefault(x => !x.DelFlag && x.Id == gradeId);
            if (grade == null) return null;
            var list = db.Classes.Include(t => t.Teacher).Include(g => g.Grade).Include(r => r.Room)
                 .Where(x => !x.DelFlag && x.GradeId == gradeId).ToList();
           return list == null ? new List<ClassResponseDto>() :
             list.Select(x => new ClassResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                GradeName = x.Grade.Name,
                NumberOfStudents = x.NumberOfStudents,
                RoomNumber = GetRoomNumber(x.Id),
                TeacherName = _teacherService.GetTeacherName(x.TeacherId)
            }).ToList();
        }

        public List<ClassResponseDto> GetClassesByHomeroomTeacherId(int id)
        {

            var teacher = db.Teachers.FirstOrDefault(x => !x.DelFlag && x.UserId == id);
            if (teacher == null) return null;

            var list = db.Classes.Include(t => t.Teacher).Include(g => g.Grade).Include(r => r.Room)
                 .Where(x => !x.DelFlag && x.TeacherId == teacher.Id).ToList();

            return list == null ? new List<ClassResponseDto>() :
              list.Select(x => new ClassResponseDto
              {
                  Id = x.Id,
                  Name = x.Name,
                  GradeName = x.Grade.Name,
                  NumberOfStudents = x.NumberOfStudents,
                  RoomNumber = GetRoomNumber(x.Id),
                  TeacherName = _teacherService.GetTeacherName(x.TeacherId)
              }).ToList();
        }

        public string GetRoomNumber(int classId)
        {
            try
            {
                return db.Classes.Include(u => u.Room).FirstOrDefault(x => !x.DelFlag && x.Id == classId).Room.RoomNumber;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public string GetGradeName(int classId)
        {
            try
            {
                return db.Classes.Include(u => u.Grade).FirstOrDefault(x => !x.DelFlag && x.Id == classId).Grade.Name;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public List<ClassResponseDto> GetTeachingClassesByTeacherId(int id)
        {
            var teacher = db.Teachers.FirstOrDefault(x => !x.DelFlag && x.UserId == id);
            if (teacher == null) return null;

            var list = db.ScheduleSubjects.Include(t => t.Teacher).Include(c => c.Class).Include(c => c.Subject)
                .Where(x => !x.DelFlag && x.TeacherId == teacher.Id && (!x.Subject.Name.Equals("Sinh hoạt") && !x.Subject.Name.Equals("Chào cờ"))).ToList();

            return list == null ? new List<ClassResponseDto>() :
              list.Select(x => new ClassResponseDto
              {
                  Id = x.ClassId,
                  Name = x.Class.Name,
                  GradeName = GetGradeName(x.ClassId),
                  NumberOfStudents = x.Class.NumberOfStudents,
                  RoomNumber = GetRoomNumber(x.ClassId),
                  TeacherName = _teacherService.GetTeacherName(x.TeacherId)
              }).DistinctBy(i => i.Id).ToList();
        }
    }
}