using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("StudentTranscript")]
    public partial class StudentTranscript : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdStudent { get; set; }

        public int IdClassification { get; set; }

        public int IdConduct { get; set; }

        public double GPA { get; set; }

        public int IdSemester { get; set; }

        public virtual Classification Classification { get; set; }

        public virtual Conduct Conduct { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Student Student { get; set; }
    }
}
