using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Room")]
    public partial class Room : TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Classes = new HashSet<Classes>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumberRoom { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classes> Classes { get; set; }
    }
}
