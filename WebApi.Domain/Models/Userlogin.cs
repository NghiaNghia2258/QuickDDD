using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models
{
	public class UserLogin : EntityBase<int>, ISoftDelete
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public int RoleGroupId { get; set; }

		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
		public string? DeletedBy { get; set; }
		public string? DeletedName { get; set; }

		public virtual RoleGroup RoleGroup { get; set; } = null!;

	}
}
