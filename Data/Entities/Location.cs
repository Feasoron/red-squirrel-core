using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Location")]
    public class Location
    {
        public Int32  Id { get; set;}
        public String Name { get; set; }
    }
}