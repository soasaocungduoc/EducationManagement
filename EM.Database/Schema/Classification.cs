using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Classification")]
    public sealed class Classification: TableHaveIdInt
    {
        public Classification()
        {
            Results = new HashSet<Result>();
            StudentTranscripts = new HashSet<StudentTranscript>();
        }

        [Required]
        [StringLength(50)]
        public string NameClassification { get; set; }

        public double FromGpa { get; set; }

        public double ToGpa { get; set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<StudentTranscript> StudentTranscripts { get; set; }
    }
}
