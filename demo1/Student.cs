namespace demo1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Result = new HashSet<Result>();
            StudentTranscript = new HashSet<StudentTranscript>();
            SubjectMark = new HashSet<SubjectMark>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long IdUser { get; set; }

        public long IdClass { get; set; }

        public long IdParent { get; set; }

        public int Status { get; set; }

        public virtual Classes Classes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTranscript> StudentTranscript { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectMark> SubjectMark { get; set; }
    }
}
