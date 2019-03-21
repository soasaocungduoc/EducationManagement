using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Screen")]
    public sealed class Screen : TableHaveIdInt
    {
        public Screen()
        {
            Functions = new HashSet<Function>();
        }

        [Required]
        [StringLength(50)]
        public string ScreenName { get; set; }

        public ICollection<Function> Functions { get; set; }
    }
}
