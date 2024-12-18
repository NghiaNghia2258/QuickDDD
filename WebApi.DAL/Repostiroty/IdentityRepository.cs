using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.Domain.Models;
using WebApi.Shared.Mapper.Identity;

namespace WebApi.DAL.Repostiroty
{
	public class IdentityRepository :RepositoryBase<Userlogin,int>, IAuthoziRepository, IAuthenRepository
	{
		public IdentityRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public Task<bool> IsAuthozi(HttpContext httpContext, string? role = null)
		{
			throw new NotImplementedException();
		}

		public async Task<Userlogin> SignIn(ParamasSignInRequest model)
		{
			Userlogin? userlogin = await _dbContext.UserLogins
				.Include(x => x.RoleGroup)
				.ThenInclude(x => x.Roles)
				.Where(x => x.Username == model.Username && x.Password == model.Password)
				.Select(x => new Userlogin()
				{
					Username = x.Username,
				}).FirstOrDefaultAsync();
				;
			return userlogin ?? new Userlogin();
		}

		public async Task<bool> SignUp(ParamasSignUpRequest model)
		{
			Userlogin newUser = new Userlogin() { 
				Username= model.Username,
				Password = model.Password,
				RoleGroupId = model.RoleGroupId,
			};
			await CreateAsync(newUser);
			return true;
		}
	}
}
