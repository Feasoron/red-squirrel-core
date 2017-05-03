using System;

namespace RedSquirrel.Models
{
    public class Inventory
    {
        public Int32?  Id { get; set;}
        public virtual Food Food { get; set; }
        public virtual Location Location { get; set; }
        public Double Amount { get; set; }
        public ApplicationUser User { get; set; }
    }
}