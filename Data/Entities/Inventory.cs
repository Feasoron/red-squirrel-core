using System;
using RedSquirrel.Models;

namespace RedSquirrel.Data.Entities
{
    public class Inventory
    {
        public Int32  Id { get; set;}
        public virtual ApplicationUser User { get; set; }
        public virtual Food Food { get; set; }
        public virtual Location Location { get; set; }
        public Double Amount { get; set; }
    }
}