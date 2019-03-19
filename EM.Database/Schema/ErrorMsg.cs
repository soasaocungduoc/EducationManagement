using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("ErrorMsg")]
    public partial class ErrorMsg : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Msg { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
