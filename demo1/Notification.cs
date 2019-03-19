namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public long? IdSender { get; set; }

        public long? IdReceiver { get; set; }

        public long? IdClassReceiver { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual User User { get; set; }
    }
}
