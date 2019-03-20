using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("ErrorMessage")]
    public partial class ErrorMessage : TableHaveIdInt
    {
        [Required]
        [StringLength(255)]
        public string Msg { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
