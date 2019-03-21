using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Conduct")]
    public sealed class Conduct : TableHaveIdInt
    {
        public Conduct()
        {
            Results = new HashSet<Result>();
            StudentTranscripts = new HashSet<StudentTranscript>();
        }

        [Required]
        [StringLength(50)]
        public string ConductType { get; set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<StudentTranscript> StudentTranscripts { get; set; }
    }
}
