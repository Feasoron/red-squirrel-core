using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Data;

namespace RedSquirrel.Services
{
    public class UnitService
    {
        public Lazy<ApplicationDbContext> _context = new Lazy<ApplicationDbContext>();
        public ApplicationDbContext Context { get; set; }

    }
}