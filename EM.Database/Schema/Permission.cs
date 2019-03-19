using EM.Database.Schema.Basic;
using System.ComponentModel.DataAnnotations.Schema;

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
