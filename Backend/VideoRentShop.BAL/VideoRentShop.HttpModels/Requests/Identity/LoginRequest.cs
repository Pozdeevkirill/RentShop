namespace VideoRentShop.HttpModels.Requests.Identity
{
    /// <summary>
    /// Запрос на авторизацию
    /// </summary>
    public class LoginRequest : IBaseRequest
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
