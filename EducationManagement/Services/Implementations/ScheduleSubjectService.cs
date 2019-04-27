using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Implementations
{
    public class ScheduleSubjectService : IScheduleSubjectService
    {
        private readonly DataContext db = new DataContext();

        public List<ScheduleSubjectResponseDto> GetScheduleSubjectsByClassId(int id, SemesterIdDto semesterId)
        {
            try
            {
                var Class = db.Classes.FirstOrDefault(x => !x.DelFlag && x.Id == id);
                if (Class == null) return null;
                return db.ScheduleSubjects.Include(t => t.Teacher).Include(c => c.Class).Include(s => s.Subject).Include(d => d.DayOfWeekLesson)
                    .Where(x => !x.DelFlag && x.ClassId == id && x.SemesterId == semesterId.id).ToList()
                    .Select(y => new ScheduleSubjectResponseDto
                    {
                        Id = y.Id,
                        SubjectName = y.Subject.Name,
                        ClassName = y.Class.Name,
                        TeacherName = db.Teachers.Include(u => u.User).FirstOrDefault(x => !x.DelFlag && x.Id == y.TeacherId).User.FirstName,
                        DayOfWeek = y.DayOfWeekLesson.DayOfWeek,
                        Lesson = y.DayOfWeekLesson.Lesson
                    }).OrderBy(x=> x.DayOfWeek).OrderBy(x=>x.Lesson).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<ScheduleSubjectResponseDto> GetScheduleSubjectsByStudentId(int id, SemesterIdDto semesterId)
        {
            try
            {
                var student =  db.Students.FirstOrDefault(x => !x.DelFlag && x.UserId == id);
                if (student == null) return null;
                var classId =  student.ClassId;
                return GetScheduleSubjectsByClassId(classId, semesterId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<TeachingScheduleResponseDto> GetTeachingScheduleByTeacherId(int id, SemesterIdDto semesterId)
        {
            try
            {
                var teacher = db.Teachers.FirstOrDefault(x => !x.DelFlag && x.UserId == id);
                if (teacher == null) return null;
                return db.ScheduleSubjects.Include(t => t.Teacher).Include(c => c.Class).Include(s => s.Subject).Include(d => d.DayOfWeekLesson)
                    .Where(x => !x.DelFlag && x.Teacher.UserId == id && x.SemesterId == semesterId.id).ToList()
                    .Select(y => new TeachingScheduleResponseDto
                    {
                        Id = y.Id,
                        ClassName = y.Class.Name,
                        Room = db.Classes.Include(u => u.Room).FirstOrDefault(x => !x.DelFlag && x.Id == y.ClassId).Room.RoomNumber,
                        DayOfWeek = y.DayOfWeekLesson.DayOfWeek,
                        Lesson = y.DayOfWeekLesson.Lesson
                    }).OrderBy(x => x.DayOfWeek).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}