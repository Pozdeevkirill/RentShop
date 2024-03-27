using Microsoft.EntityFrameworkCore.Storage;

namespace VideoRentShop.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        bool HasActiveTransaction { get; }
        IDbContextTransaction GetCurrentTransaction();
        IDbContextTransaction BeginTransaction();
        void Commit(IDbContextTransaction transaction);
        void Execute(Action action);
    }
}
