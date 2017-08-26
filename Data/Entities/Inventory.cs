using System;
using System.ComponentModel.DataAnnotations.Schema;
using RedSquirrel.Models;

namespace RedSquirrel.Data.Entities
{
    [Table("Inventory")]
    public class Inventory
    {
        public Int32  Id { get; set;}
        public virtual User User { get; set; }
        public virtual Food Food { get; set; }
        public virtual Location Location { get; set; }
        public Double Amount { get; set; }
    }
}