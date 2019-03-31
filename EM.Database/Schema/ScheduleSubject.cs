using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("ScheduleSubject")]
    public partial class ScheduleSubject : TableHaveIdInt
    {

        public int DayLessonId { get; set; }

        public int SubjectId { get; set; }

        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Class Class { get; set; }

        public virtual DayOfWeekLesson DayOfWeekLesson { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
