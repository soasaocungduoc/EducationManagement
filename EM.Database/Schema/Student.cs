using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("Student")]
    public partial class Student
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Result = new HashSet<Result>();
            StudentTranscript = new HashSet<StudentTranscript>();
            SubjectMark = new HashSet<SubjectMark>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        public int IdUser { get; set; }

        public int IdClass { get; set; }

        public int IdParent { get; set; }

        public int Status { get; set; }

        public virtual Classes Classes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }

        public virtual User User { get; set; }

        public virtual Parent Parent { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentTranscript> StudentTranscript { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectMark> SubjectMark { get; set; }
    }
}
