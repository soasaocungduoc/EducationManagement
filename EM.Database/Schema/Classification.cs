using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Classification")]
    public partial class Classification: TableHaveIdInt
    {
        public Classification()
        {
            Results = new HashSet<Result>();
            StudentTranscripts = new HashSet<StudentTranscript>();
        }

        [Required]
        [StringLength(50)]
        public string NameClassification { get; set; }

        public double FromGPA { get; set; }

        public double ToGPA { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        public virtual ICollection<StudentTranscript> StudentTranscripts { get; set; }
    }
}
