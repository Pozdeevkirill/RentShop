using System.Security.Claims;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.Identity;
using VideoRentShop.Common;

namespace VideoRentShop.Services.Implementation.Identity
{
	public class WebAuthService : IWebAuthService
    {
        private readonly IRepository<User> _userRepository;

        public WebAuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsIdentity Login(LoginRequest request)
        {
            if (!_userRepository.Any(x => x.Login == request.Login)) throw new Exception("Не существующий пользователь");

            var user = _userRepository.List(x => x.Login == request.Login).Single();

            if (!PasswordHelper.VerifyHashedPassword(user.Password, request.Password)) throw new Exception("Неверный пароли");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var cliamIdentity = new ClaimsIdentity(claims, "Authorization", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return cliamIdentity;
        }
	}
}
