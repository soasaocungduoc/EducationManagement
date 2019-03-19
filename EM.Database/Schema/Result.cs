using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Result")]
    public partial class Result : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdStudent { get; set; }

        public int IdClassification { get; set; }

        public int IdConduct { get; set; }

        public double GPA { get; set; }

        public int IdScholastic { get; set; }

        public virtual Classification Classification { get; set; }

        public virtual Conduct Conduct { get; set; }

        public virtual Student Student { get; set; }

        public virtual Scholastic Scholastic { get; set; }
    }
}
