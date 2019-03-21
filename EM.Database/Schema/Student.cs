using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Student")]
    public sealed class Student : TableHaveIdInt
    {
        public Student()
        {
            Results = new HashSet<Result>();
            StudentTranscripts = new HashSet<StudentTranscript>();
            SubjectMarks = new HashSet<SubjectMark>();
        }

        public int IdUser { get; set; }

        public int IdClass { get; set; }

        public int IdParent { get; set; }

        public int Status { get; set; }

        public Class Class { get; set; }

        public User User { get; set; }

        public Parent Parent { get; set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<StudentTranscript> StudentTranscripts { get; set; }

        public ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
