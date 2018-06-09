using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RedSquirrel.Models;
using RedSquirrel.Services;

namespace RedSquirrel
{
    public class AuthEvent : JwtBearerEvents
    {
        private UserService UserService { get; set; }
        public AuthEvent(UserService service)
        {
            
            UserService = service;
            OnTokenValidated = context =>
            {
                // Add the access_token as a claim, as we may actually need it
                if (context.SecurityToken is JwtSecurityToken accessToken)
                {
                    var identity = context.Principal.Identity as ClaimsIdentity;
                }

                return Task.CompletedTask;
            };
        }

        // duped code. centralize. 
        private String GetExternalId(ClaimsIdentity identity)
        {
            // Sometimes we're getting a nameidentifier claim, sometimes a sub.
            // Until we get to the bottom of why, moving forward with this gross workaround
            var externalId = GetClaimValue(identity, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier") ??
                             GetClaimValue(identity, "sub");
            
            return externalId;
        }
        
        private String GetClaimValue(ClaimsIdentity identity, String claimType)
        {
            try
            {
                return identity.Claims.FirstOrDefault(claim => claim.Type == claimType)?.Value;
            }
            catch
            {
                return null;
            }
        }
       
    }
}