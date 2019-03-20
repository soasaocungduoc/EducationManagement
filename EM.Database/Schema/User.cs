using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("User")]
    public partial class User : TableHaveIdInt
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            NotificationSenders = new HashSet<Notification>();
            NotificationReceivers = new HashSet<Notification>();
            Parents = new HashSet<Parent>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

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

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string IdentificationNumber { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Notification> NotificationSenders { get; set; }

        public virtual ICollection<Notification> NotificationReceivers { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
