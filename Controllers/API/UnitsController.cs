using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Models;
using RedSquirrel.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace RedSquirrel.Controllers.API
{
    [EnableCors("AllowAll"), Route("api/[controller]")]
    public class UnitsController : Controller
    {
        protected UnitService Service { get; set; }
        private ILogger<UnitService> Log { get; }

        public UnitsController(UnitService service, ILogger<UnitService> log)
        {
            Service = service;
            Log = log;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return Service.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(Int32 id)
        {
           return new JsonResult(Service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult  Post(Unit value)
        {
            if (value == null)
            {
                return new BadRequestResult();
            }

            Log.LogDebug("Adding new unit. Name:" + value.Name );
            var id = Service.AddUnit(value);
            return new CreatedResult(id.ToString(), value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Int32 id, Unit value)
        {
            var resp = Service.UpdateUnit(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Int32 id)
        {
            var resp = Service.Delete(id);
            return Ok();
        }
    }
}
