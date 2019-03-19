using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
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
