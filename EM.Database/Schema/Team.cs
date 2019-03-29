using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Team")]
    public sealed class Team : TableHaveIdInt
    {
        public Team()
        {
            Subjects = new HashSet<Subject>();
            Teachers = new HashSet<Teacher>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
