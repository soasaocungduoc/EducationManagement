using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("Class")]
    public partial class Class: TableHaveIdInt
    {
        public Class()
        {
            Notifications = new HashSet<Notification>();
            ScheduleSubjects = new HashSet<ScheduleSubject>();
            Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(50)]
        public string NameClass { get; set; }

        public int NumberStudent { get; set; }

        public int IdGrade { get; set; }

        public int IdRoom { get; set; }

        public int IdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
