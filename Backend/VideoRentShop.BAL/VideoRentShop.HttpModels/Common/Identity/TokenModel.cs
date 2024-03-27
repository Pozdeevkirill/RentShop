namespace VideoRentShop.HttpModels.Common.Identity
{
    /// <summary>
    /// Базовая модель токена
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string? RefreshToken { get; set; }
    }
}
