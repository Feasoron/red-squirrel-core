using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Models;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {
        protected UnitService Service { get; set; }

        public UnitsController(UnitService service)
        {
            Service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return Service.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
           return new JsonResult(Service.GetById(id));
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
