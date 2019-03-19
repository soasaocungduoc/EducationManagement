using EM.Database.Schema.Basic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Database
{

    [Table("Slide")]
    public partial class Slide : TableHaveIdInt
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
        [StringLength(255)]
        public string Path { get; set; }

        public bool IsShow { get; set; }
    }
}
