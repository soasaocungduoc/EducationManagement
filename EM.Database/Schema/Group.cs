using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Group")]
    public sealed class Group : TableHaveIdInt
    {
        public Group()
        {
            Accounts = new HashSet<Account>();
            Permissions = new HashSet<Permission>();
        }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
