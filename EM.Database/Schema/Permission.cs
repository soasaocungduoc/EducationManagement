using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("Permission")]
    public partial class Permission : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdGroup { get; set; }

        public int IdFunction { get; set; }

        public bool IdEnable { get; set; }

        public virtual Function Function { get; set; }

        public virtual Group Group { get; set; }
    }
}
