using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Models.Identity;
using VideoRentShop.Models.ScopeContexts;
using VideoRentShop.Models.Shop;
using VideoRentShop.Models.Shop.File;

namespace VideoRentShop.Data
{
    public class MainDbContext : DbContext, IApplicationContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<FileAttachment> FileAttachments => Set<FileAttachment>();
        public DbSet<ItemFile> ItemFiles => Set<ItemFile>();
        public DbSet<Banner> Banners => Set<Banner>();
        public DbSet<Header> Headers => Set<Header>();
        public DbSet<Order> Orders => Set<Order>();

        public DbSet<OrderToItemScopeContext> OrderToItemScopeContext => Set<OrderToItemScopeContext>();

		public MainDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///TODO: мапинг, что бы в таблице FileAttachments не создавалось миллион полей с сылками на родительскую сущность
            ///а наоборот, все эти ссылки хранились в поле EntityId
            ///Стоит поменять, что бы постоянно не писать подобные маппинги для подобных моделей со связью one-to-many
            modelBuilder.Entity<Item>()
                .HasMany(x => x.Files)
                .WithOne()
                .HasForeignKey(x => x.EntityId);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public IDbContextTransaction BeginTransaction()
        {
            if (_currentTransaction != null) return null!;

            _currentTransaction = Database.BeginTransaction();

            return _currentTransaction;
        }

        public void Commit(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                SaveChanges();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

        private void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null!;
                }
            }
        }

        public void Execute(Action action)
        {
            var transaction = BeginTransaction();

            action();

            Commit(transaction);
        }
    }
}
