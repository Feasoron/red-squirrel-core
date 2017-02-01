using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("FoodConversion")]
    public class FoodConversion
    {
        public Int32  Id { get; set;}
        public virtual Food Food { get; set; }
        public virtual Unit FirstUnit  { get; set; }
        public virtual Unit SecondUnit  { get; set; }
        public virtual Double Ratio  { get; set; }
    }
}