using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Models;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class InventoriesController : BaseController
    {
        private InventoryService Service { get; set; }

        public InventoriesController(InventoryService service)
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
        public ActionResult  Post([FromBody] Inventory value)
        {
            /*if(String.IsNullOrEmpty(value.Name) || value.Id.HasValue) 
            {
                return new BadRequestResult();
            }*/

            var id = Service.AddInventory(value, CurrentUserId);
            return new CreatedResult("Inventory", id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Int32 id, [FromBody]Inventory value)
        {
            var resp = Service.UpdateInventory(value);
            return Ok(resp);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Int32 id)
        {
            var resp = Service.Delete(id);
            return Ok(resp);
        }
       
    }
}