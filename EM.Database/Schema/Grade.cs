using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Grade")]
    public sealed class Grade : TableHaveIdInt
    {
        public Grade()
        {
            Classes = new HashSet<Class>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }
    }
}
