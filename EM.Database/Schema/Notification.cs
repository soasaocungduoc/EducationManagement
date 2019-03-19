using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Notification")]
    public partial class Notification : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public int? IdSender { get; set; }

        public int? IdReceiver { get; set; }

        public int? IdClassReceiver { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual User UserSender { get; set; }

        public virtual User UserReceiver { get; set; }
    }
}