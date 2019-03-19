namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long IdGroup { get; set; }

        public long IdFunction { get; set; }

        public bool IdEnable { get; set; }

        public virtual Function Function { get; set; }

        public virtual Group Group { get; set; }
    }
}
