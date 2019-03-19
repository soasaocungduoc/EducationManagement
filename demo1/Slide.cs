namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

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
