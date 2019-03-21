using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Room")]
    public sealed class Room : TableHaveIdInt
    {
        public Room()
        {
            Classes = new HashSet<Class>();
        }

        [Required]
        [StringLength(50)]
        public string RoomNumber { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
