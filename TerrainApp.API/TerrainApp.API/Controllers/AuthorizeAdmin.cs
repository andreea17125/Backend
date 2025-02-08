using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace TerrainApp.API.Controllers
{
  
        public class AuthorizeAdmin : Attribute, IAuthorizationFilter
        {

            public void OnAuthorization(AuthorizationFilterContext context)
            {

                var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                if (!ValidateToken(token))
                {
                    context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden); // 403 if token is invalid
                    return;
                }
            }
            public bool ValidateToken(string token)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("averylongsecretkeythatisrequiredtobeused")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                try
                {
                    tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                    var role = (validatedToken as JwtSecurityToken).Claims.FirstOrDefault(Claim =>Claim.Type == ClaimTypes.Role) ;
                    return role != null&&role.Value == "Admin";
                }
                catch
                {
                    return false;
                }
            }
        }


    
}
