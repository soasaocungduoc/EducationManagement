using EM.Database.Schema.Basic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EM.Database
{

    [Table("User")]
    public partial class User : TableHaveIdInt
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Account = new HashSet<Account>();
            NotificationSender = new HashSet<Notification>();
            NotificationReceiver = new HashSet<Notification>();
            Parent = new HashSet<Parent>();
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Avatar { get; set; }

        public bool Gender { get; set; }

        //[Column(TypeName = "datetime2")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string IdentityCard { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Account { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> NotificationSender { get; set; }

        public virtual ICollection<Notification> NotificationReceiver { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parent> Parent { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
