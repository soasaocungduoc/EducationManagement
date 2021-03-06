using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Subject")]
    public sealed class Subject : TableHaveIdInt
    {
        public Subject()
        {
            ScheduleSubjects = new HashSet<ScheduleSubject>();
            SubjectMarks = new HashSet<SubjectMark>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public ICollection<ScheduleSubject> ScheduleSubjects { get; set; }

        public ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
