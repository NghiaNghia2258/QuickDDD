using Microsoft.AspNetCore.Http;
using WebApi.Domain.Abstractions.Repository.Identity;

namespace WebApi.DAL.Repostiroty
{
	public class IIdentityRepository : IAuthoziRepository
	{
		public Task<bool> IsAuthozi(HttpContext httpContext, string? role = null)
		{
			throw new NotImplementedException();
		}
	}
}
