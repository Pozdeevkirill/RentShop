using System.Text.Json.Serialization;

namespace VideoRentShop.HttpModels.Common.Identity
{
    /// <summary>
    /// Базовая модель токена
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Токен доступа
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Токен обновления
        /// </summary>
        public string? RefreshToken { get; set; }


        /// <summary>
        /// Когда истекает токен
        /// </summary>
        [JsonIgnore]
        public DateTime Expires { get; set; }

        /// <summary>
        /// Дата создания токена
        /// </summary>
        [JsonIgnore]
        public DateTime Created { get; set; }

        /// <summary>
        /// ИП с которого создавали токен
        /// </summary>
        [JsonIgnore]
        public string CreatedByIp { get; set; }

        /// <summary>
        /// Дата, когда отозвали токен
        /// </summary>
        [JsonIgnore]
        public DateTime? Revoked { get; set; }

        /// <summary>
        /// ИП с которого отозвали токен
        /// </summary>
        [JsonIgnore]
        public string RevokedByIp { get; set; }


        [JsonIgnore]
        public string ReplacedByToken { get; set; }

        /// <summary>
        /// Токен закончился
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => DateTime.Now >= Expires;

        /// <summary>
        /// Это отозванный токе
        /// </summary>
        [JsonIgnore]
        public bool IsRevoked => Revoked != null;

        /// <summary>
        /// Токен не активный
        /// </summary>

        [JsonIgnore]
        public bool IsActive => !IsRevoked && !IsExpired;
    }
}
