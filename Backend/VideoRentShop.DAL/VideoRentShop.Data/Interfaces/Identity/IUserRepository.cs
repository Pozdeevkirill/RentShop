using VideoRentShop.Models.Identity;

namespace VideoRentShop.Data.Interfaces.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Получить пользователя по логину<br/>
        /// </summary>
        User Get(string login);
    }
}
