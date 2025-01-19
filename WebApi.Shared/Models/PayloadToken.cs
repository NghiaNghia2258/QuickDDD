namespace WebApi.Shared.Models
{
	public class PayloadToken
	{
		public int UserLoginId { get; set; }
		public string Username { get; set; }
		public string FullName { get; set; }
		public int? RoleGroupId { get; set; }

		public IEnumerable<RoleDto> Roles { get; set; }
	}
}
