namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ErrorMsg")]
    public partial class ErrorMsg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Msg { get; set; }

        public int Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
