namespace VideoRentShop.HttpModels.Requests.Identity
{
    /// <summary>
    /// Запрос на регистрацию
    /// </summary>
    public class RegisterRequest : IBaseRequest
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        public string ConfirmPassword { get; set; }
    }
}
