using EM.Database.Schema.Basic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM.Database
{

    [Table("DayLesson")]
    public partial class DayLesson: TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DayLesson()
        {
            ScheduleSubject = new HashSet<ScheduleSubject>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int Day { get; set; }

        public int Lesson { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleSubject> ScheduleSubject { get; set; }
    }
}
