using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{

    [Table("Group")]
    public partial class Group : TableHaveIdInt
    {
        public Group()
        {
            Accounts = new HashSet<Account>();
            Permissions = new HashSet<Permission>();
        }

        [Required]
        [StringLength(50)]
        public string NameGroup { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
