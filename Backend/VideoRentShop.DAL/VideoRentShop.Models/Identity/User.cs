using VideoRentShop.Models.Enums;

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
        /// Роль пользователя
        /// </summary>
        public Role Role { get; set; }
    }
}
