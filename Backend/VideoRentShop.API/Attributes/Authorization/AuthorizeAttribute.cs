using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.Identity;
using VideoRentShop.Services.Implementation.Identity;
using VideoRentShop.API.Settings;

namespace VideoRentShop.API.Attributes.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var service = context.HttpContext.RequestServices.GetRequiredService<ITokenService>();
            

            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var token = (string)context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(token))
            {
                Unauthorized(ref context);
                return;
            }

            var test = service.GetPrincipalFromExpiredToken(token);
            var user = service.GetUserByToken(token);

            if (user == null)
            {
                Unauthorized(ref context);
                return;
            }

            var aToken = service.GetTokenByUserId(user.Id);
            if(!aToken.IsActive || aToken.IsRevoked || aToken.IsExpired)
            {
                Unauthorized(ref context);
                return;
            }
        }

        private void Unauthorized(ref AuthorizationFilterContext context)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }
    }
}
