using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("TypeMark")]
    public partial class TypeMark : TableHaveIdInt
    {
        public TypeMark()
        {
            SubjectMarks = new HashSet<SubjectMark>();
        }

        [Required]
        [StringLength(50)]
        public string NameTypeMark { get; set; }

        public double Factor { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
