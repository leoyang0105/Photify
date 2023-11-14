using Microsoft.EntityFrameworkCore.Storage;
using Photify.Domain;

namespace Photify.Infrastructure
{
    public interface IDbContext : IUnitOfWork
    {
        string Schema { get; }
        bool HasActiveTransaction { get; }
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        IDbContextTransaction GetCurrentTransaction();
        void RollbackTransaction();
    }
}
