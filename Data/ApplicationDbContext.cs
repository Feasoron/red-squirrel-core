
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using User = RedSquirrel.Models.ApplicationUser;
using RedSquirrel.Data.Entities;

namespace RedSquirrel.Data
{
    public class ApplicationDbContext :  IdentityDbContext<User>
    {
        protected IHostingEnvironment Environment { get; set; }
        protected ILogger<ApplicationDbContext> Log { get; set; }
        
        public DbSet<Unit> Units { get; set; }
        public DbSet<Unit> Food { get; set; }
        public DbSet<Unit> FoodConversion { get; set; }
        public DbSet<Unit> Location { get; set; }
        public DbSet<Unit> Substitution { get; set; }
        public DbSet<Unit> UnitConversion { get; set; }
        public DbSet<Unit> Inventory { get; set; }

        public ApplicationDbContext(IHostingEnvironment env, ILogger<ApplicationDbContext> log)
        {    
            Environment = env;
            Log = log;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.ContentRootPath + "/squirrel.db";
            Log.LogDebug("Opeing Database at :" + path);
            optionsBuilder.UseSqlite("Filename=" + path );
        }
    }
}