using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models
{
	public class Userlogin : EntityBase<int>, IAuditableEntity
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public int RoleGroupId { get; set; }


		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedName { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string? UpdatedBy { get; set; }
		public string? UpdatedName { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? DeletedAt { get; set; }
		public string? DeletedBy { get; set; }
		public string? DeletedName { get; set; }

		public virtual RoleGroup RoleGroup { get; set; } = null!;

	}
}
