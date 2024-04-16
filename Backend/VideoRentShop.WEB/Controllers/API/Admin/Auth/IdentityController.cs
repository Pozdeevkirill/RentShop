using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.WEB.Controllers.API.Admin.Auth
{
    [Route("api/")]
    public class IdentityController : Controller
    {
        private readonly IWebAuthService _authService;

        public IdentityController(IWebAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromForm] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password)) return BadRequest();
            var claims = _authService.Login(request);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claims),
                new AuthenticationProperties
                {
                    //IsPersistent = request.IsPersistent
                });

            return Ok();
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
