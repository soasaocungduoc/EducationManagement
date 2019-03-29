using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("StudentTranscript")]
    public class StudentTranscript : TableHaveIdInt
    {

        public int StudentId { get; set; }

        public int ClassificationId { get; set; }

        public int ConductId { get; set; }

        public double Gpa { get; set; }

        public int SemesterId { get; set; }

        public virtual Classification Classification { get; set; }

        public virtual Conduct Conduct { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Student Student { get; set; }
    }
}
