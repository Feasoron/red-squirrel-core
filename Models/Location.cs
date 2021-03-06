using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Models
{
    [Table("Location")]
    public class Location : OwnedObject
    {
        public Int32?  Id { get; set;}
        public String Name { get; set; }
    }
}