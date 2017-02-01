using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Food")]
    public class Food
    {
        public Int32  Id { get; set;}
        public String Name { get; set; }
    }
}