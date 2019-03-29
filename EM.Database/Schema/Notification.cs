using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Notification")]
    public class Notification : TableHaveIdInt
    {

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public int? SenderId { get; set; }

        public int? ReceiverId { get; set; }

        public int? ClassReceiverId { get; set; }

        public virtual Class Class { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }
    }
}
