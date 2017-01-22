using System;

namespace RedSquirrel.Data.Entities
{
    public class UnitConversion
    {
        public Int32  Id { get; set;}
        public virtual Unit FirstUnit  { get; set; }
        public virtual Unit SecondUnit  { get; set; }
        public virtual Double Ratio  { get; set; }
    }
}