using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSquirrel.Data.Entities
{
    [Table("Location")]
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64  Id { get; set;}
        public String Name { get; set; }
    }
}