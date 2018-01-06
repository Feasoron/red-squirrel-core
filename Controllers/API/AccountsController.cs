using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Data;
using RedSquirrel.Data.Entities;
using RedSquirrel.Models;
using RedSquirrel.Services;
using User = RedSquirrel.Data.Entities.User;

namespace RedSquirrel.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize]
    public class AccountsController : Controller
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

            return Ok(userId);
        }

        private String GetExternalId()
        {
            // Sometimes we're getting a nameidentifier claim, sometimes a sub.
            // Until we get to the bottom of why, moving forward with this gross workaround
            var externalId = GetClaimValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") ??
                             GetClaimValue("sub");
            
            return externalId;
        }
        
        private String GetClaimValue(String claimType)
        {
            try
            {
                return User.Claims.FirstOrDefault(claim => claim.Type == claimType)?.Value;
            }
            catch
            {
                return null;
            }
        }
    }
}