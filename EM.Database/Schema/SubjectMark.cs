using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("SubjectMark")]
    public partial class SubjectMark : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public double Mark { get; set; }

        public int IdTypeMark { get; set; }

        public int IdStudent { get; set; }

        public int IdSubject { get; set; }

        public int IdSemester { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual TypeMark TypeMark { get; set; }
    }
}
