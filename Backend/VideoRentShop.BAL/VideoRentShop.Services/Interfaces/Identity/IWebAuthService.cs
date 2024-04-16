
using System.Security.Claims;
using VideoRentShop.HttpModels.Requests.Identity;

namespace VideoRentShop.Services.Interfaces.Identity
{
    /// <summary>
    /// Сервис для MVC версии проекта
    /// </summary>
    public interface IWebAuthService : IService
    {
        /// <summary>
        /// Авторизация
        /// </summary>
        ClaimsIdentity Login(LoginRequest request);
    }
}
