using System.ComponentModel.DataAnnotations;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    public partial class News : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string UrlImage { get; set; }

        [Required]
        [StringLength(200)]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
