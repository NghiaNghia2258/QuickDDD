using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Abstractions
{
	public abstract class EntityBase<TKey> : IEntityBase<TKey>
	{
		public TKey Id { get; set; }
		public int Version { get; set; } = 0;
	}
}
