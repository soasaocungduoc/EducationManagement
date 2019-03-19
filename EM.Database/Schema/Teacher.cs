using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("Teacher")]
    public partial class Teacher : TableHaveIdInt
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdUser { get; set; }

        public int IdTeam { get; set; }

        public virtual User User { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }

        public virtual ICollection<ScheduleSubject> ScheduleSubject { get; set; }
    }
}
