using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("Semester")]
    public sealed class Semester : TableHaveIdInt
    {
        public Semester()
        {
            StudentTranscripts = new HashSet<StudentTranscript>();
            SubjectMarks = new HashSet<SubjectMark>();
            ScheduleSubjects = new HashSet<ScheduleSubject>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int ScholasticId { get; set; }

        public SchoolYear SchoolYear { get; set; }

        public ICollection<StudentTranscript> StudentTranscripts { get; set; }

        public ICollection<ScheduleSubject> ScheduleSubjects { get; set; }

        public ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
