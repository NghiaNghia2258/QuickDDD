﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebApi.DAL.Repostiroty;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Repository;

namespace WebApi.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    private readonly IBookRepository _bookRepository;
    private readonly ICategoryRepository _categoryRepository;

	public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_dbContext);
	public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_dbContext);

	public UnitOfWork(AppDbContext dbContext)
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
       
    }
}
