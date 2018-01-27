using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RedSquirrel.Data.Entities
{
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 UserId { get; set; }
        public String ExternalUserId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        
        public virtual List<Location> Locations { get; set; }
        public virtual List<Food> Foods { get; set; }
        public virtual List<Inventory> Inventories { get; set; }
        public virtual List<Unit> Units { get; set; }
        public virtual List<UnitConversion> UnitConversions { get; set; }
    }
}