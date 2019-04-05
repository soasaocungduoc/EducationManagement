using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Slide")]
    public partial class Slide : TableHaveIdInt
    {
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Path { get; set; }

        public bool IsShown { get; set; }
    }
}
