using EM.Database.Schema.Basic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Database
{

    [Table("Parent")]
    public partial class Parent : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdUser { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
