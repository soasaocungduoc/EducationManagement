using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Parent")]
    public partial class Parent : TableHaveIdInt
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }
        public int IdUser { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
