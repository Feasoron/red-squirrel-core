using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Inventory")]
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public virtual Food Food { get; set; }
        public virtual Location Location { get; set; }
        public virtual Unit Unit { get; set; }
        public Double Amount { get; set; }

        public virtual User Owner { get; set; }
    }
}