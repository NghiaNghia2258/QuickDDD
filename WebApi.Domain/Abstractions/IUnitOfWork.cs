using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApi.Domain.Abstractions
{
    public interface IUnitOfWork: IDisposable
	{
		Task<IDbContextTransaction> BeginTransactionAsync();
		Task CommitAsync();
		Task EndTransactionAsync();
		DbContext GetDbContext();
		Task RollbackTransactionAsync();
	}
}
