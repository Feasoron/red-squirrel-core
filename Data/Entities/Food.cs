using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Food")]
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64  Id { get; set;}
        public String Name { get; set; }
        
        public virtual User Owner { get; set; }
    }
}