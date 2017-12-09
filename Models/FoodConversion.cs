using System;

namespace RedSquirrel.Models
{
    public class FoodConversion : OwnedObject
    {
        public Int32?  Id { get; set;}
        public virtual Food Food { get; set; }
        public virtual Unit FirstUnit  { get; set; }
        public virtual Unit SecondUnit  { get; set; }
        public virtual Double Ratio  { get; set; }
    }
}