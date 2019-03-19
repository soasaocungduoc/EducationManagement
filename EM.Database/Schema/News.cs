using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
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
