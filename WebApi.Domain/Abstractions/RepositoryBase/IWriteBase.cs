
using WebApi.Shared.Models;

namespace WebApi.Domain.Abstractions.RepositoryBase
{
	public interface IWriteBase<T, TKey>
	{
		Task<TKey> CreateAsync(T entity, PayloadToken payloadToken);
		Task DeleteAsync(TKey entity, PayloadToken payloadToken);
		Task UpdateAsync(T update, PayloadToken payloadToken);
	}
}
