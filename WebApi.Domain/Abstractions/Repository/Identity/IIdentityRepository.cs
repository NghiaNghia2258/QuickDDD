using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.Domain.Abstractions.Repository.Identity;

public interface IIdentityRepository : IAuthenRepository, IAuthoziRepository
{
    Task<RoleGroup> GetRoleGroupByCode(string code);
    Task<List<UserLogin>> GetAllUsersAsync(OptionFilterUser option);
    Task<UserLogin> GetUserByUsernameAsync(string username);
    Task<bool> UpdateAccount(UserLogin user);
}
