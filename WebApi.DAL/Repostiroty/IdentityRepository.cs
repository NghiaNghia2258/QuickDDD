using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.Domain.Models;
using WebApi.Shared.Mapper.Identity;

namespace WebApi.DAL.Repostiroty
{
	public class IdentityRepository :RepositoryBase<UserLogin,int>, IAuthoziRepository, IAuthenRepository
	{
		public IdentityRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public Task<bool> IsAuthozi(HttpContext httpContext, string? role = null)
		{
			throw new NotImplementedException();
		}

		public async Task<UserLogin> SignIn(ParamasSignInRequest model)
		{
			UserLogin? UserLogin = await _dbContext.UserLogins
				.Include(x => x.RoleGroup)
				.ThenInclude(x => x.Roles)
				.Where(x => x.Username == model.Username && x.Password == model.Password)
				.Select(x => new UserLogin()
				{
					Username = x.Username,
					RoleGroupId = x.RoleGroupId,
					RoleGroup = x.RoleGroup
				}).FirstOrDefaultAsync();
				;
			return UserLogin ?? new UserLogin();
		}

		public async Task<bool> SignUp(ParamasSignUpRequest model)
		{
			UserLogin newUser = new UserLogin() { 
				Username= model.Username,
				Password = model.Password,
				RoleGroupId = model.RoleGroupId,
			};
			await CreateAsync(newUser);
			return true;
		}
	}
}
