namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long IdUser { get; set; }

        public int IdTeam { get; set; }

        public virtual User User { get; set; }

        public virtual Team Team { get; set; }
    }
}
