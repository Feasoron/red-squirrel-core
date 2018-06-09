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

        public LocationsController(LocationService service, UserService userService)
            : base(userService)
        {
            Service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            return await Service.GetAll(await GetCurrentUserId());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(Int32 id)
        {
           return new JsonResult(await Service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Location value)
        {
            if(String.IsNullOrEmpty(value.Name) || value.Id.HasValue) 
            {
                return new BadRequestResult();
            }
            
            var id = await Service.AddLocation(value, await GetCurrentUserId());
            return new CreatedResult("Location", id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Int32 id, [FromBody]Location value)
        {
            var resp = await Service.UpdateLocation(value);
            return Ok(resp);
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
