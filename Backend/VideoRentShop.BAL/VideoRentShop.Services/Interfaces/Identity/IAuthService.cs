using VideoRentShop.HttpModels.Requests.Identity;
using VideoRentShop.HttpModels.Responses.Identity;

namespace VideoRentShop.Services.Interfaces.Identity
{
    /// <summary>
    /// Сервис аутентификации и авторизации
    /// </summary>
    public interface IAuthService : IService
    {
        /// <summary>
        /// Вход в систему
        /// </summary>
        TokenResponse Login(LoginRequest login);

        /// <summary>
        /// Регистрация в системе
        /// </summary>
        void Register(RegisterRequest registerRequest);
    }
}
