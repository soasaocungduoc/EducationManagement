using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("TypeMark")]
    public partial class TypeMark : TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeMark()
        {
            SubjectMark = new HashSet<SubjectMark>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameTypeMark { get; set; }

        public double Factor { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectMark> SubjectMark { get; set; }
    }
}
