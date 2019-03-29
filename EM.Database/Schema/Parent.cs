using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Parent")]
    public sealed class Parent : TableHaveIdInt
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
