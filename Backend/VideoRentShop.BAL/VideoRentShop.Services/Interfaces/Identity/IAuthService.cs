using VideoRentShop.HttpModels.Requests.Admin;
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
        TokenResponse Login(LoginRequest login, string createdIp);

        /// <summary>
        /// Регистрация в системе
        /// </summary>
        void Register(RegisterRequest registerRequest);

        /// <summary>
        /// Обновление токена
        /// </summary>
        TokenResponse RefreshToken(RefreshTokenRequest request);

        /// <summary>
        /// Добавить пользователя Администратором из админ-панели
        /// </summary>
        void AddUser(AddUserRequest request);
    }
}
