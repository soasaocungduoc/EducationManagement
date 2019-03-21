using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Permission")]
    public partial class Permission : TableHaveIdInt
    {

        public int IdGroup { get; set; }

        public int IdFunction { get; set; }

        public bool IsEnable { get; set; }

        public virtual Function Function { get; set; }

        public virtual Group Group { get; set; }
    }
}
