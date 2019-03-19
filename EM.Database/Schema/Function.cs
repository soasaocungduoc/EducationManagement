using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Function")]
    public partial class Function : TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Function()
        {
            Permission = new HashSet<Permission>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdScreen { get; set; }

        [Required]
        [StringLength(50)]
        public string NameFunction { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(50)]
        public string NameController { get; set; }

        [Required]
        [StringLength(50)]
        public string NameAction { get; set; }

        public virtual Screen Screen { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
