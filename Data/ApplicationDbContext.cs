using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace RedSquirrel.Data
{
    [Table("red_squirrel_unit")]
    public class Unit
    {
        public Int32  Id { get; set;}
        public String Name { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        protected IHostingEnvironment Environment { get; set; }
        protected ILogger<ApplicationDbContext> Log { get; set; }

        public ApplicationDbContext(IHostingEnvironment env, ILogger<ApplicationDbContext> log)
        {
            Environment = env;
            Log = log;
        }
        public DbSet<Unit> Units { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.ContentRootPath + "/db.sqlite3.sqrl";
            Log.LogDebug("Opeing Database at :" + path);
            optionsBuilder.UseSqlite("Filename=" + path );
        }
    }
}