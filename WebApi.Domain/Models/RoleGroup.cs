using System.Data;
using WebApi.Domain.Abstractions;

namespace WebApi.Domain.Models
{
	public class RoleGroup : EntityBase<int>
	{
		public string Name { get; set; } = null!;

		public virtual ICollection<Userlogin> UserLogins { get; set; } = new List<Userlogin>();

		public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
	}
}
