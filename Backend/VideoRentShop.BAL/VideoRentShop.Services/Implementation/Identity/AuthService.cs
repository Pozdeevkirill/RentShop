using System.Security.Claims;
using VideoRentShop.Common;
using VideoRentShop.Data.Interfaces.Identity;
using VideoRentShop.HttpModels.Requests.Admin;
using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.HttpModels.Responses.Identity;
using VideoRentShop.Models.Enums;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.Services.Implementation.Identity
{
	public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IIdentityService _identityService;

        public AuthService(IUserRepository userRepository,
                            ITokenService tokenService,
                            IIdentityService identityService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _identityService = identityService;
        }

        public TokenResponse Login(LoginRequest request, string createdIp)
        {
            if (request == null) throw new ArgumentNullException(ErrorMessages.RequiredFieldsError);

            var user = _userRepository.Get(request.Login);

            if (user == null) throw new Exception("Неверный логин и/или пароль");

            if (!PasswordHelper.VerifyHashedPassword(user.Password, request.Password)) throw new Exception("Неверный логин и/или пароль");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Login),
                //new Claim(ClaimTypes.Role, "Manager") //Роли пока нету
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            _identityService.AddUserWithToken(user.Id, new()
            {
                UserName = user.Login,
                RefreshToken = refreshToken,
                AccessToken = accessToken,
                Created = DateTime.Now,
                CreatedByIp = createdIp,
                Expires = DateTime.Now.AddMinutes(5)
            });

            return new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserName = user.Login
            };
        }

        public void Register(RegisterRequest request)
        {
            if (request == null) throw new ArgumentNullException(ErrorMessages.RequestEmptyError);

            if (_userRepository.Any(x => x.Login == request.Login)) throw new Exception("Пользователь с такми логином уже зарегестрирован.");

            string hashedPassword = PasswordHelper.HashPassword(request.Password);

            User user = new() { Password = hashedPassword, Login = request.Login, Name = request.Login };

            _userRepository.UnitOfWork.Execute(() =>
            {
                _userRepository.Add(user);
            });
        }

        public TokenResponse RefreshToken(RefreshTokenRequest request)
        {
            var user = _tokenService.GetUserByRefreshToken(request.RefreshToken);
            var token = _tokenService.GetTokenByUserId(user.Id);

            //Если токен отозван(Например разлогинился юзер)
            if (token.IsRevoked)
            {
                _tokenService.RemoveTokenByUserId(user.Id);
                throw new Exception("Ваша сессия завершена, пожалуйста, авторизуйтесь.");
            }

            //Если токен по каким-то причинам не активен
            if (!token.IsActive)
				throw new Exception("Ваша сессия завершена, пожалуйста, авторизуйтесь.");

			var newRefreshToken = _tokenService.GenerateRefreshToken();
            _identityService.UpdateRefreshToken(user.Id, newRefreshToken);

            return null;
        }

		public void AddUser(AddUserRequest request)
		{
			if (request == null) throw new ArgumentNullException(ErrorMessages.RequestEmptyError);

			if (_userRepository.Any(x => x.Login == request.Login)) return;

			string hashedPassword = PasswordHelper.HashPassword(request.Password);

			User user = new() { Password = hashedPassword, Login = request.Login, Name = request.Name , Role = (Role)request.Role};

			_userRepository.UnitOfWork.Execute(() =>
			{
				_userRepository.Add(user);
			});
		}
	}
}
