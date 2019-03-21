using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("SchoolInformation")]
    public class SchoolInformation : TableHaveIdInt
    {

        [Required]
        [StringLength(200)]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string Email { get; set; }

        [Required]
        public string SchoolIntroduction { get; set; }

        [Required]
        [StringLength(255)]
        public string WebsiteUrl { get; set; }

        [Required]
        [StringLength(30)]
        public string Fax { get; set; }
    }
}
