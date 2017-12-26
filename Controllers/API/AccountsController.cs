using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Data;
using RedSquirrel.Models;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    
    
    
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : Controller
    {
        private ApplicationDbContext _applicationDbContext { get; set; }
        
        public AccountsController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public String claimType { get; set; } = "nameidentifier";
        
        // GET
        public IActionResult Get()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == claimType);

            if (id == null)
            {
                return BadRequest();
            }
            
          //  var user = _applicationDbContext.Users.Fir
            
            if (id != null)
            {
                
                
                return Ok(id);
            }
            
            
            
            return Ok();
        }
    }
}