using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Models;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    public class FoodsController : Controller
    {
        protected FoodService Service { get; set; }

        public FoodsController(FoodService service)
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
        public JsonResult Get(Int32 id)
        {
           return new JsonResult(Service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult  Post(Food value)
        {
            var id = Service.AddFood(value);
            return new CreatedResult(id.ToString(), value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Int32 id, Food value)
        {
            var resp = Service.UpdateFood(value);
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
