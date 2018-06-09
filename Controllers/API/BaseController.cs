using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSquirrel.Services;

namespace RedSquirrel.Controllers.API
{
    public class BaseController : Controller
    {
        protected UserService UserService { get; }

        public BaseController(UserService userService)
        {
            UserService = userService;
        }
       
        protected async Task<Int64> GetCurrentUserId()
        {
                var claimId = GetClaimValue("user_id");
                
                if (!String.IsNullOrEmpty(claimId))
                {
                    return Convert.ToInt64(claimId);
                }
                
                var externalId = GetExternalId();
            
                if (externalId == null)
                {
                   throw new InvalidOperationException();
                }

                var user = new Models.User
                {
                    Email = GetClaimValue("email"),
                    Name = GetClaimValue("name"),
                    ExternalUserId = externalId
                };

            var id = await UserService.GetOrCreateUserId(user);

            return id;
        }

        protected String GetExternalId()
        {
            // Sometimes we're getting a nameidentifier claim, sometimes a sub.
            // Until we get to the bottom of why, moving forward with this gross workaround
            var externalId = GetClaimValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") ??
                             GetClaimValue("sub");
            
            return externalId;
        }
        
        protected String GetClaimValue(String claimType)
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