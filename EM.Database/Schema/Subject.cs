using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Subjects")]
    public partial class Subject : TableHaveIdInt
    {
        public Subject()
        {
            ScheduleSubjects = new HashSet<ScheduleSubject>();
            SubjectMarks = new HashSet<SubjectMark>();
        }

        [Required]
        [StringLength(50)]
        public string NameSubject { get; set; }

        public int IdTeam { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<ScheduleSubject> ScheduleSubjects { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
