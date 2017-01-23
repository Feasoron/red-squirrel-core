using System;

namespace RedSquirrel.Models
{
    public class UnitConversion
    {
        public Int32  Id { get; set;}
        public Unit FirstUnit  { get; set; }
        public Unit SecondUnit  { get; set; }
        public Double Ratio  { get; set; }
    }
}