using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Screen")]
    public partial class Screen : TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Screen()
        {
            Function = new HashSet<Function>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameScreen { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Function> Function { get; set; }
    }
}
