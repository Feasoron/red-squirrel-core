using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("UnitConversion")]
    public class UnitConversion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64  Id { get; set;}
        public virtual Unit FirstUnit  { get; set; }
        public virtual Unit SecondUnit  { get; set; }
        public virtual Double Ratio  { get; set; }
    }
}