using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("DayLesson")]
    public partial class DayLesson: TableHaveIdInt
    {
        public DayLesson()
        {
            ScheduleSubjects = new HashSet<ScheduleSubject>();
        }

        public int Day { get; set; }

        public int Lesson { get; set; }

        public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; }
    }
}
