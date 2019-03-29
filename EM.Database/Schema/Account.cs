using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("Account")]
    public class Account: TableHaveIdInt
    {
        
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int UserId { get; set; }

        public int GroupId { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }

    }
}
