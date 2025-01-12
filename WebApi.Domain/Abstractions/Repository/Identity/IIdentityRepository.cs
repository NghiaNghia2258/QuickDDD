using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository.Identity;

public interface IIdentityRepository : IAuthenRepository, IAuthoziRepository
{
    Task<RoleGroup> GetRoleGroupByCode(string code);
}
