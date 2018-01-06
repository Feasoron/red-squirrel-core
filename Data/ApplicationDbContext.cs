
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RedSquirrel.Data.Entities;

namespace RedSquirrel.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodConversion> FoodConversions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UnitConversion> UnitConversions { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<User> Users { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}