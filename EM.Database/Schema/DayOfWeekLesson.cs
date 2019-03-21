using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("DayOfWeekLesson")]
    public sealed class DayOfWeekLesson: TableHaveIdInt
    {
        public DayOfWeekLesson()
        {
            ScheduleSubjects = new HashSet<ScheduleSubject>();
        }

        public int DayOfWeek { get; set; }

        public int Lesson { get; set; }

        public ICollection<ScheduleSubject> ScheduleSubjects { get; set; }
    }
}
