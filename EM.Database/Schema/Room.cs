using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Room")]
    public partial class Room : TableHaveIdInt
    {
        public Room()
        {
            Classes = new HashSet<Class>();
        }

        [Required]
        [StringLength(50)]
        public string NumberRoom { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
