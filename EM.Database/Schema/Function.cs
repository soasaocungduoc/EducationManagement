using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Function")]
    public sealed class Function : TableHaveIdInt
    {
        public Function()
        {
            Permissions = new HashSet<Permission>();
        }

        public int ScreenId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(100)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionName { get; set; }

        public Screen Screen { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
