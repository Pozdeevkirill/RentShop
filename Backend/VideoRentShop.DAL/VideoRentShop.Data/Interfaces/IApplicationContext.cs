using Microsoft.EntityFrameworkCore;
using VideoRentShop.Models.Identity;
using VideoRentShop.Models.Shop;

namespace VideoRentShop.Data.Interfaces
{
    public interface IApplicationContext : IUnitOfWork
    {
        DbSet<User> Users { get; }
        DbSet<Item> Items { get; }
        DbSet<FileAttachment> FileAttachments { get; }
        DbSet<ItemFile> ItemFiles { get; }  
        DbSet<Price> Prices{ get; }

    }
}
