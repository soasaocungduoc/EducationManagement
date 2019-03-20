using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Student")]
    public partial class Student : TableHaveIdInt
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

        public virtual Class Class { get; set; }

        public virtual User User { get; set; }

        public virtual Parent Parent { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        public virtual ICollection<StudentTranscript> StudentTranscripts { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
