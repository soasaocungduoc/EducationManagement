using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Permission")]
    public partial class Permission : TableHaveIdInt
    {

        public int GroupId { get; set; }

        public int FunctionId { get; set; }

        public bool IsEnable { get; set; }

        public virtual Function Function { get; set; }

        public virtual Group Group { get; set; }
    }
}
