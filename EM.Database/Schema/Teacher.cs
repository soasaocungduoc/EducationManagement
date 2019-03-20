using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Teacher")]
    public partial class Teacher : TableHaveIdInt
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();

            ScheduleSubjects = new HashSet<ScheduleSubject>();
        }

        public int IdUser { get; set; }

        public int IdTeam { get; set; }

        public virtual User User { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

        public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; }
    }
}
