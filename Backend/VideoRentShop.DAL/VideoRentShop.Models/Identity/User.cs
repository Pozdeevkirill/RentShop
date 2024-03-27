namespace VideoRentShop.Models.Identity
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль(захешированный)
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Срок годности токена
        /// </summary>
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
