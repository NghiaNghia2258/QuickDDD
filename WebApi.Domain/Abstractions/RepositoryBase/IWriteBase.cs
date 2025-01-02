namespace WebApi.Domain.Abstractions.RepositoryBase;

public interface IWriteBase<T, TKey>
{
	Task<TKey> CreateAsync(T entity);
	Task DeleteAsync(TKey entity);
	Task UpdateAsync(T update);
}
