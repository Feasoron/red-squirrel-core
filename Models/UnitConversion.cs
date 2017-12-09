using System;

namespace RedSquirrel.Models
{
    public class UnitConversion : OwnedObject
    {
        public Int32?  Id { get; set;}
        public Unit FirstUnit  { get; set; }
        public Unit SecondUnit  { get; set; }
        public Double Ratio  { get; set; }
    }
}