using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("SchoolYear")]
    public sealed class SchoolYear : TableHaveIdInt
    {
        public SchoolYear()
        {
            Results = new HashSet<Result>();
            Semesters = new HashSet<Semester>();
        }

        public int StartYear { get; set; }

        public int EndYear { get; set; }

        public ICollection<Result> Results { get; set; }

        public ICollection<Semester> Semesters { get; set; }
    }
}
