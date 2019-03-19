namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectMark")]
    public partial class SubjectMark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public double Mark { get; set; }

        public int IdTypeMark { get; set; }

        public long IdStudent { get; set; }

        public long IdSubject { get; set; }

        public long IdSemester { get; set; }

        public virtual Semester Semester { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual TypeMark TypeMark { get; set; }
    }
}
