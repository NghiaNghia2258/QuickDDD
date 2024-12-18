using Microsoft.AspNetCore.Http;

namespace WebApi.Domain.Abstractions.Repository.Identity;

public interface IAuthoziRepository
{
	Task<bool> IsAuthozi(int userLoginId, string? role = null);
}
