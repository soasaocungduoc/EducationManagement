namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Semester")]
    public partial class Semester
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semester()
        {
            StudentTranscript = new HashSet<StudentTranscript>();
            SubjectMark = new HashSet<SubjectMark>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string NameSemester { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndTime { get; set; }

        public long IdScholastic { get; set; }

        public virtual Scholastic Scholastic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTranscript> StudentTranscript { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectMark> SubjectMark { get; set; }
    }
}
