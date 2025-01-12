﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using WebApi.DAL.Repostiroty;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Abstractions.Repository.Identity;

namespace WebApi.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _config;
    private ITeacherRepository _teacherRepository;
    private IFacultyRepository _facultyRepository;
    private ISubjectRepository _subjectRepository;
    private IIdentityRepository _identityRepository;

    public ITeacherRepository Teacher => _teacherRepository ?? new TeacherRepository(_dbContext, _httpContextAccessor, _config);
    public IFacultyRepository Faculty => _facultyRepository ?? new FacultyRepository(_dbContext, _httpContextAccessor, _config);
    public ISubjectRepository Subject => _subjectRepository ?? new SubjectRepository(_dbContext,_httpContextAccessor,_config);
    public IIdentityRepository Identity => _identityRepository ?? new IdentityRepository(_dbContext,_httpContextAccessor,_config);

    public UnitOfWork(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _config = config;
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
