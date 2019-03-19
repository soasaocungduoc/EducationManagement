namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScheduleSubject")]
    public partial class ScheduleSubject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long IdDayLesson { get; set; }

        public long IdSubject { get; set; }

        public long IdClass { get; set; }

        public long IdTeacher { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual DayLesson DayLesson { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
