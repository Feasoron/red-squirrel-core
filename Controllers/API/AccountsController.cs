using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : BaseController
    {
        public AccountsController(UserService userService)
            : base(userService)
        {
        }
        
        // GET
        public async Task<IActionResult> Get()
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

            var userId = await UserService.GetOrCreateUserId(user);

            return Ok(userId);
        }
       
    }
}