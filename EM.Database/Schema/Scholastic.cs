using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Scholastic")]
    public partial class Scholastic : TableHaveIdInt
    {
        public Scholastic()
        {
            Results = new HashSet<Result>();
            Semesters = new HashSet<Semester>();
        }

        public int StartYear { get; set; }

        public int EndYear { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
