using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EM.Database.Schema.Bases;

namespace EM.Database.Schema
{
    [Table("Account")]
    public partial class Account: TableHaveIdInt
    {
        
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Token { get; set; }

        public int IdUser { get; set; }

        public int IdGroup { get; set; }

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }

    }
}
