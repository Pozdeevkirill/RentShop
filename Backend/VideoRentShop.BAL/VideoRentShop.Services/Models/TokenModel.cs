namespace VideoRentShop.Services.Models
{
    public class TokenModel
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        public string AccsessToken { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Дата создания токена(Дата авторизации)
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Дата обновления токена
        /// </summary>
        public DateTime DateUpdate { get; set; }
    }
}
