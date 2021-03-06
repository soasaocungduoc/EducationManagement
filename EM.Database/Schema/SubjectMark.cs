using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("SubjectMark")]
    public class SubjectMark : TableHaveIdInt
    {

        public double Mark { get; set; }

        public int TypeMarkId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual TypeMark TypeMark { get; set; }
    }
}
