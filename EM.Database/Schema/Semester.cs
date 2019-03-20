using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("Semester")]
    public partial class Semester : TableHaveIdInt
    {
        public Semester()
        {
            StudentTranscripts = new HashSet<StudentTranscript>();
            SubjectMarks = new HashSet<SubjectMark>();
        }

        [Required]
        [StringLength(20)]
        public string NameSemester { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int IdScholastic { get; set; }

        public virtual Scholastic Scholastic { get; set; }

        public virtual ICollection<StudentTranscript> StudentTranscripts { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
