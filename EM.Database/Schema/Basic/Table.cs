using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EM.Database.Schema.Basic
{
    public abstract class Table
    {
        public DateTime? Created_at { set; get; }
        public int Created_by { set; get; }
        public DateTime? Updated_at { set; get; }
        public int? Updated_by { set; get; }
        public bool DelFlag { set; get; }
    }
    public abstract class TableHaveIdInt : Table
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { set; get; }
    }
}