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
    public class UnitsController : BaseController
    {
        private UnitService Service { get; set; }

        public UnitsController(UnitService service, UserService userService)
            : base(userService)
        {
            Service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            var units = await Service.GetAll(await GetCurrentUserId());
            return units;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
           return new JsonResult(await Service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Unit value)
        {
            if(String.IsNullOrEmpty(value.Name) || value.Id.HasValue) 
            {
                return new BadRequestResult();
            }

            var id = await Service.AddUnit(value, await GetCurrentUserId());
            return new CreatedResult("Units", id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Int32 id, [FromBody]Unit value)
        {
            var resp = Service.UpdateUnit(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var resp = Service.Delete(id);
            return Ok();
        }
    }
}
