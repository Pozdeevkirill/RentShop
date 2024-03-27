using System.Security.Claims;
using VideoRentShop.Common.PasswordHelper;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Data.Interfaces.Identity;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.HttpModels.Responses.Identity;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.Services.Implementation.Identity
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository,
                            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenResponse Login(LoginRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var user = _userRepository.Get(request.Login);

            //TODO: Переделать на выбрасывание ошибки кастомной 
            if (user == null) return null;

            //TODO: Переделать на выбрасывание ошибки кастомной
            if (!PasswordHelper.VerifyHashedPassword(user.Password, request.Password)) return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Login),
                //new Claim(ClaimTypes.Role, "Manager") //Роли пока нету
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            //TODO: Вынести эту настройку в конфиг
            user.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime.AddDays(1);

            return new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public void Register(RegisterRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            //TODO: Переделать на выбрасывание ошибки кастомной как на работе :)
            if (_userRepository.Any(x => x.Login == request.Login)) return;

            string hashedPassword = PasswordHelper.HashPassword(request.Password);

            User user = new() { Password = hashedPassword, Login = request.Login, Name = request.Login };

            _userRepository.UnitOfWork.Execute(() =>
            {
                _userRepository.Add(user);
            });
        }
    }
}
