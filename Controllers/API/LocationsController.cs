using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Models;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class LocationsController : BaseController
    {
        private LocationService Service { get; }

        public LocationsController(LocationService service)
        {
            Service = service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            return Service.GetAll(CurrentUserId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(Int32 id)
        {
           return new JsonResult(Service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult  Post([FromBody]Location value)
        {
            if(String.IsNullOrEmpty(value.Name) || value.Id.HasValue) 
            {
                return new BadRequestResult();
            }
            
            var id = Service.AddLocation(value, CurrentUserId);
            return new CreatedResult("Location", id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Int32 id, [FromBody]Location value)
        {
            var resp = Service.UpdateLocation(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Int32 id)
        {
            var resp = await Service.Delete(id);

            if (resp)
            {
                return Ok(id);
            }

            return BadRequest(id);
        }
    }
}
