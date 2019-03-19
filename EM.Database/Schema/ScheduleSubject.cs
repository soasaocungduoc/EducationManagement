using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("ScheduleSubject")]
    public partial class ScheduleSubject : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdDayLesson { get; set; }

        public int IdSubject { get; set; }

        public int IdClass { get; set; }

        public int IdTeacher { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Classes Classes { get; set; }

        public virtual DayLesson DayLesson { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
