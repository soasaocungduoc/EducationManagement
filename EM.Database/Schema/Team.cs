using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Team")]
    public partial class Team : TableHaveIdInt
    {
        public Team()
        {
            Subjects = new HashSet<Subject>();
            Teachers = new HashSet<Teacher>();
        }

        [Required]
        [StringLength(50)]
        public string NameTeam { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
