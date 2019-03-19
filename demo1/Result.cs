namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Result")]
    public partial class Result
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long IdStudent { get; set; }

        public int IdClassification { get; set; }

        public int IdConduct { get; set; }

        public double GPA { get; set; }

        public long IdScholastic { get; set; }

        public virtual Classification Classification { get; set; }

        public virtual Conduct Conduct { get; set; }

        public virtual Student Student { get; set; }

        public virtual Scholastic Scholastic { get; set; }
    }
}
