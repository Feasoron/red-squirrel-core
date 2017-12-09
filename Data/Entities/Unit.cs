using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Unit")]
    public class Unit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set;}
        public String Name { get; set; }
    }
}