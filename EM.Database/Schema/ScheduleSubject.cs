using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("ScheduleSubject")]
    public partial class ScheduleSubject : TableHaveIdInt
    {

        public int IdDayLesson { get; set; }

        public int IdSubject { get; set; }

        public int IdClass { get; set; }

        public int IdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Class Class { get; set; }

        public virtual DayOfWeekLesson DayOfWeekLesson { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
