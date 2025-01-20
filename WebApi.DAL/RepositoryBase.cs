using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;
using WebApi.Domain.Abstractions.RepositoryBase;
using WebApi.Domain.Const;
using WebApi.Shared.Exceptions;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.DAL
{
	public abstract class RepositoryBase<T,TKey>: IRepositoryBase<T,TKey> where T : EntityBase<TKey>
    { 
       
        protected readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        protected RepositoryBase(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
        }
        public async Task UpdateAsync(T update)
        {
            if (_dbContext.Entry(update).State == EntityState.Unchanged) return;
            T? exist = _dbContext.Set<T>().Find(update.Id);
            if (exist == null) { throw new NotFoundDataException("Record for update not found"); }
            if (exist.Version == update.Version)
            {
                update.Version += 1;
            }
            else { throw new VersionIsOldException(); }
            if (update is IUpdateTracking trackingEntity)
            {
                try
                {
                    PayloadToken payloadToken = JwtTokenHelper.GetPayloadToken(_httpContextAccessor.HttpContext, _config);
                    trackingEntity.UpdatedAt = TimeConst.Now;
                    trackingEntity.UpdatedBy = payloadToken.Username;
                    trackingEntity.UpdatedName = payloadToken.FullName;
                }
                catch
                {

                }
            }
            _dbContext.Entry(exist).CurrentValues.SetValues(update);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<TKey> CreateAsync(T entity)
        {
            T? exist = _dbContext.Set<T>().Find(entity.Id);
            if (exist != null) { throw new RecordAlreadyExistsException(); }
            if (entity is ICreateTracking createTracking)
            {
                PayloadToken payloadToken = JwtTokenHelper.GetPayloadToken(_httpContextAccessor.HttpContext, _config);

                createTracking.CreatedAt = TimeConst.Now;
                createTracking.CreatedBy = payloadToken.UserLoginId.ToString();
                createTracking.CreatedName = payloadToken.FullName;
            }
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task DeleteAsync(TKey primaykey)
        {
            T? exist = _dbContext.Set<T>().Find(primaykey);
            if (exist == null) { throw new NotFoundDataException("Record for delete does not exist"); }
            if (exist is ISoftDelete softDelete)
            {
                PayloadToken payloadToken = JwtTokenHelper.GetPayloadToken(_httpContextAccessor.HttpContext, _config);

                softDelete.IsDeleted = true;
                softDelete.DeletedBy = payloadToken.Username;
                softDelete.DeletedAt = TimeConst.Now;
                softDelete.DeletedName = payloadToken.FullName;
            }
            else
            {
                _dbContext.Set<T>().Remove(exist);
            }
            await _dbContext.SaveChangesAsync();
        }
        public IQueryable<T> FindAll(bool trackChanges = false)
        {
            return !trackChanges ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(TKey primaryKey)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(primaryKey));
        }

        public async Task<T?> GetByIdAsync(TKey primaryKey, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = _dbContext.Set<T>().Where(x => x.Id.Equals(primaryKey));
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return await items.FirstOrDefaultAsync();
        }
    }
}
