using EM.Database.Schema.Basic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Database
{

    [Table("Scholastic")]
    public partial class Scholastic : TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scholastic()
        {
            Result = new HashSet<Result>();
            Semester = new HashSet<Semester>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Semester> Semester { get; set; }
    }
}
