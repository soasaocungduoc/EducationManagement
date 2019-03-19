using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("Notification")]
    public partial class Notification : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public int? IdSender { get; set; }

        public int? IdReceiver { get; set; }

        public int? IdClassReceiver { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual User UserSender { get; set; }

        public virtual User UserReceiver { get; set; }
    }
}
