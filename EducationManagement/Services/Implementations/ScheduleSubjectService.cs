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
    public class ScheduleSubjectService : IScheduleSubjectService
    {
        private readonly DataContext db = new DataContext();

        public List<ScheduleSubjectResponseDto> GetScheduleSubjectsByClassId(int id)
        {
            try
            {
                return db.ScheduleSubjects.Include(t => t.Teacher).Include(c => c.Class).Include(s => s.Subject).Include(d => d.DayOfWeekLesson)
                    .Where(x => !x.DelFlag && x.ClassId == id).ToList()
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
    }
}