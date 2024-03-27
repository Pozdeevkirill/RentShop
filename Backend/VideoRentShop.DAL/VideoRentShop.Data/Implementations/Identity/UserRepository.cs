using VideoRentShop.Data.Interfaces.Identity;
using VideoRentShop.Models.Identity;

namespace VideoRentShop.Data.Implementations.Identity
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainDbContext mainDbContext) : base(mainDbContext)
        {
        }

        public User? Get(string login)
        {
            return base.Get(x => x.Login == login);
        }

        public void Test(string t)
        {
            throw new NotImplementedException();
        }
    }
}
