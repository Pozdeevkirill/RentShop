using Microsoft.EntityFrameworkCore;
using VideoRentShop.Models.Identity;

namespace VideoRentShop.Data.Interfaces
{
    public interface IApplicationContext : IUnitOfWork
    {
        DbSet<User> Users { get; }
    }
}
