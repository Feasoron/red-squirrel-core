using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Unit")]
    public class Unit
    {
        public Int32 Id { get; set;}
        public String Name { get; set; }
    }
}