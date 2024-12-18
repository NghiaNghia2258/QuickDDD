using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Domain.Abstractions;

namespace WebApi.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;

    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public DbContext GetDbContext()
    {
        return _dbContext;
    }
    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return _dbContext.Database.BeginTransactionAsync();
    }
    public Task RollbackTransactionAsync()
    {
        return _dbContext.Database.RollbackTransactionAsync();
    }
    public async Task EndTransactionAsync()
    {
        await CommitAsync();
        await _dbContext.Database.CommitTransactionAsync();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
