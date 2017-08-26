using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RedSquirrel.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User 
    {
        public Int64 UserId { get; set; }
        public virtual List<Data.Entities.Inventory> Inventories { get; set; }
    }
}