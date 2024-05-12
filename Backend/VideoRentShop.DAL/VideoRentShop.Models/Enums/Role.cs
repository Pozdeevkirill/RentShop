using System.ComponentModel;

namespace VideoRentShop.Models.Enums
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public enum Role
    {
        [Description("Администратор")]
        Admin,

        [Description("Модератор")]
        Moderator
    }
}
