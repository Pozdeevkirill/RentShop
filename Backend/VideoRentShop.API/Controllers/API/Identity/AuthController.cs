using Microsoft.AspNetCore.Mvc;
using VideoRentShop.API.Attributes.Authorization;
using VideoRentShop.Common;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.API.Controllers.API.Identity
{
    [Route("api/auth/")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            var response = _authService.Login(request, HttpHelper.GetIp(Request, HttpContext.Connection));
            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            _authService.Register(request);
            return Ok();
        }


        [HttpPost]
        [Route("refresh")]
        [Authorize]
        public IActionResult RefreshToken([FromBody]RefreshTokenRequest request)
        {
            var response = _tokenService.RefreshToken(request.RefreshToken, HttpHelper.GetIp(Request, HttpContext.Connection));

            return Ok(response);
        }

        [HttpGet]
        [Route("test")]
        [Authorize]
        public IActionResult TestMethod()
        {
            return Ok("Auth");
        }

		[HttpPost]
		[Route("upload")]
		public ActionResult Upload([FromForm] Guid itemId, [FromForm] List<IFormFile> files)
		{
			return Ok();
		}


		#region Helpers

		private void SetRefreshTokenInCookie(string token)
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = false,
                Expires = DateTime.UtcNow.AddDays(1),
            };

            Response.Cookies.Append("refreshToken", token, cookieOption);
        }

        #endregion
    }
}
