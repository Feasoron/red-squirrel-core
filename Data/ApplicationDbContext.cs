using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RedSquirrel.Models;

namespace RedSquirrel.Data
{
    [Table("red_squirrel_unit")]
    public class Unit
    {
        public Int32  Id { get; set;}
        public String Name { get; set; }
    }

    public

    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        protected IHostingEnvironment Environment { get; set; }
        protected ILogger<ApplicationDbContext> Log { get; set; }

        public ApplicationDbContext(IHostingEnvironment env, ILogger<ApplicationDbContext> log)
        {            // Add framework services.
            //Database.EnsureCreated();

            Environment = env;
            Log = log;
        }
        public DbSet<Unit> Units { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.ContentRootPath + "/squirrel.db";
            Log.LogDebug("Opeing Database at :" + path);
            optionsBuilder.UseSqlite("Filename=" + path );
        }
    }
}