namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InforSchool")]
    public partial class InforSchool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NameSchool { get; set; }

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
        public string IntroSchool { get; set; }

        [Required]
        [StringLength(255)]
        public string LinkWebsite { get; set; }

        [Required]
        [StringLength(30)]
        public string Fax { get; set; }
    }
}
