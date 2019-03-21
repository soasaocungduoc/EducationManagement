using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Teacher")]
    public sealed class Teacher : TableHaveIdInt
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();

            ScheduleSubjects = new HashSet<ScheduleSubject>();
        }

        public int IdUser { get; set; }

        public int IdTeam { get; set; }

        public User User { get; set; }

        public Team Team { get; set; }

        public ICollection<Class> Classes { get; set; }

        public ICollection<ScheduleSubject> ScheduleSubjects { get; set; }
    }
}
