using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DbSet<Unit> Units { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=/home/chris/sourcecode/red-squirrel/db.sqlite3.sqrl");
        }
    }
}