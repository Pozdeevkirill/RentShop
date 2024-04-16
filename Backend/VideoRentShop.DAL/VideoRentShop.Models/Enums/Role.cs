using System.ComponentModel;

namespace VideoRentShop.Models.Enums
{
    public enum Role
    {
        [Description("Администратор")]
        Admin,

        [Description("Модератор")]
        Moderator
    }
}
