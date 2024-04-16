using Microsoft.Extensions.Options;
using VideoRentShop.API.Settings;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Data.Interfaces.Identity;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenSetting _appSettings;
        private readonly IRepository<User> _userRepository; 

        public JwtMiddleware(RequestDelegate next, IOptions<TokenSetting> appSettings, IRepository<User> userRepository)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public async Task Invoke(HttpContext context, IRepository<User> userRepository, ITokenService jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userRepository.Get(userId.Value);
            }

            await _next(context);
        }
    }
}
