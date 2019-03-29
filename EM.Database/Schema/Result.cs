using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Result")]
    public class Result : TableHaveIdInt
    {

        public int StudentId { get; set; }

        public int ClassificationId { get; set; }

        public int ConductId { get; set; }

        public double Gpa { get; set; }

        public int ScholasticId { get; set; }

        public virtual Classification Classification { get; set; }

        public virtual Conduct Conduct { get; set; }

        public virtual Student Student { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }
    }
}
