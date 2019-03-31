using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("Class")]
    public sealed class Class: TableHaveIdInt
    {
        public Class()
        {
            Notifications = new HashSet<Notification>();
            ScheduleSubjects = new HashSet<ScheduleSubject>();
            Students = new HashSet<Student>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int NumberOfStudents { get; set; }

        public int GradeId { get; set; }

        public int RoomId { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public Grade Grade { get; set; }

        public Room Room { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<ScheduleSubject> ScheduleSubjects { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
