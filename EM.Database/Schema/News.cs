using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("News")]
    public class News : TableHaveIdInt
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(200)]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
