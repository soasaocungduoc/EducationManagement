using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using EducationManagement.Dtos.InputDtos;
using EM.Database.Schema;

namespace EducationManagement.Services.Implementations
{
    public class ScheduleSubjectService : IScheduleSubjectService
    {
        private readonly DataContext db = new DataContext();
        private readonly TeacherService _teacherService = new TeacherService();

        public List<ScheduleSubjectResponseDto> GetScheduleSubjectsByClassId(int id, SemesterIdDto semesterId)
        {
            try
            {
                var Class = db.Classes.FirstOrDefault(x => !x.DelFlag && x.Id == id);
                if (Class == null) return null;
                var list = db.ScheduleSubjects.Include(t => t.Teacher).Include(c => c.Class).Include(s => s.Subject).Include(d => d.DayOfWeekLesson)
                    .Where(x => !x.DelFlag && x.ClassId == id && x.SemesterId == semesterId.id).ToList()
                    .Select(y => new ScheduleSubjectResponseDto
                    {
                        Id = y.Id,
                        SubjectName = y.Subject.Name,
                        ClassName = y.Class.Name,
                        TeacherName = _teacherService.GetTeacherName(y.TeacherId),
                        DayOfWeek = y.DayOfWeekLesson.DayOfWeek,
                        Lesson = y.DayOfWeekLesson.Lesson
                    }).OrderBy(x=> x.DayOfWeek).OrderBy(x=>x.Lesson).ToList();
                return list ?? new List<ScheduleSubjectResponseDto>();
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
                var list = db.ScheduleSubjects.Include(t => t.Teacher).Include(c => c.Class).Include(s => s.Subject).Include(d => d.DayOfWeekLesson)
                    .Where(x => !x.DelFlag && x.Teacher.UserId == id && x.SemesterId == semesterId.id).ToList()
                    .Select(y => new TeachingScheduleResponseDto
                    {
                        Id = y.Id,
                        ClassName = y.Class.Name,
                        Room = GetRoomNumber(y.ClassId),
                        DayOfWeek = y.DayOfWeekLesson.DayOfWeek,
                        Lesson = y.DayOfWeekLesson.Lesson
                    }).OrderBy(x => x.DayOfWeek).ToList();
                return list ?? new List<TeachingScheduleResponseDto>();

            }
            catch (Exception e)
            {

                throw e;
            }
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

        public bool AddScheduleSubjectsByClassId(ScheduleSubjectOfClassDto dto)
        {
            try
            {
                foreach (var item in dto.ScheduleSubjects)
                {
                    var schedule = new ScheduleSubject
                    {
                        TeacherId = item.TeacherId,
                        ClassId = dto.ClassId,
                        SubjectId = item.SubjectId,
                        SemesterId = dto.SemesterId,
                        DayLessonId = GetDayLessonId(item.DayOfWeek, item.Lesson)
                    };
                    db.ScheduleSubjects.Add(schedule);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private int GetDayLessonId(int day, int lesson)
        {
            var dayLesson = db.DayLessons.FirstOrDefault(x => !x.DelFlag && x.DayOfWeek == day && x.Lesson == lesson);
            return dayLesson == null ? 0 : dayLesson.Id;
        }
    }
}