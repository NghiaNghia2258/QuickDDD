using Microsoft.AspNetCore.Http;

namespace WebApi.Domain.Abstractions.Repository.Identity;

public interface IAuthoziRepository
{
	Task<bool> IsAuthozi(HttpContext httpContext, string? role = null);
}
