using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("Classification")]
    public partial class Classification: TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classification()
        {
            Result = new HashSet<Result>();
            StudentTranscript = new HashSet<StudentTranscript>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameClassification { get; set; }

        public double FromGPA { get; set; }

        public double ToGPA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTranscript> StudentTranscript { get; set; }
    }
}
