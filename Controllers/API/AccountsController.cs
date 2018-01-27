using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : BaseController
    {
        private UserService UserService { get; set; }
        
        public AccountsController(UserService userService)
        {
            UserService = userService;
        }
        
        // GET
        public IActionResult Get()
        {
            var externalId = GetExternalId();
            
            if (externalId == null)
            {
                return BadRequest();
            }

            var user = new Models.User
            {
                Email = GetClaimValue("email"),
                Name = GetClaimValue("name"),
                ExternalUserId = externalId
            };

            var userId = UserService.GetOrCreateUserId(user);
            
            //User.Claims.

            return Ok(userId);
        }
       
    }
}