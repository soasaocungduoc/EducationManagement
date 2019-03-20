using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Function")]
    public partial class Function : TableHaveIdInt
    {
        public Function()
        {
            Permissions = new HashSet<Permission>();
        }

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

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
