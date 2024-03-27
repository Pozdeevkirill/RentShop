using Microsoft.AspNetCore.Mvc;
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
            return Ok(_authService.Login(request));
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
        public IActionResult RefreshToken(RefreshTokenRequest request)
        {
            return Ok(_tokenService.RefreshToken(request));
        }
    }
}
