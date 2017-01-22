using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Data;

namespace RedSquirrel.Controllers
{
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        public Lazy<ApplicationDbContext> _context = new Lazy<ApplicationDbContext>();
        public ApplicationDbContext Context { get; set; }

        public UnitsController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return Context.Units.ToList();
          //  return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return Context.Units.Where(u => u.Id == id).ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Unit value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Unit value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
            
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
