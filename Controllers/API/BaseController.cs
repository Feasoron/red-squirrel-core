using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RedSquirrel.Controllers.API
{
    public class BaseController : Controller
    {
        protected Int64 CurrentUserId => Convert.ToInt64(GetClaimValue("user_id"));

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