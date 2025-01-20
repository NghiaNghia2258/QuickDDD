using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Mapper.Identity;

namespace WebApi.DAL.Repostiroty
{
    public class IdentityRepository :RepositoryBase<UserLogin,int>, IIdentityRepository
	{
        public IdentityRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
        {
        }
		public async Task<Student> GetStudentById(int id)
		{
			return await _dbContext.Students.FirstOrDefaultAsync(s => s.UserLoginId == id);
		}
        public async Task<Teacher> GetTeacherById(int id)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(s => s.UserLoginId == id);
        }
		public async Task<IEnumerable<UserLogin>> GetAll(OptionFilterUser option)
		{
			return await _dbContext.UserLogins.Include(x => x.RoleGroup).Skip(option.PageSize * (option.PageIndex - 1)).Take(option.PageSize).ToListAsync();
		}
        public async Task<bool> IsAuthozi(int userLoginId, string? role = null)
		{
			UserLogin? UserLogin = await _dbContext.UserLogins
				.Include(x => x.RoleGroup)
				.ThenInclude(x => x.Roles.Where(y => y.Name == role))
				.Where(x => x.Id == userLoginId)
				.Select(x => new UserLogin()
				{
					RoleGroup = x.RoleGroup
				}).FirstOrDefaultAsync();
			return UserLogin.RoleGroup.Roles.Count > 0;
		}

		public async Task<UserLogin> SignIn(ParamasSignInRequest model)
		{
			UserLogin? UserLogin = await _dbContext.UserLogins
				.Include(x => x.RoleGroup)
				.ThenInclude(x => x.Roles)
				.Where(x => x.Username == model.Username && x.Password == model.Password)
				.Select(x => new UserLogin()
				{
					Id = x.Id,
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
		public async Task<bool> Create(UserLogin userLogin)
		{
			await CreateAsync(userLogin);
			return true;
		}
        public async Task<bool> Update(UserLogin userLogin)
        {
            await UpdateAsync(userLogin);
            return true;
        }
        public async Task<RoleGroup> GetRoleGroupByCode(string code)
		{
			return await _dbContext.RoleGroups.FirstOrDefaultAsync(x => x.Code == code);
		}
		public async Task<UserLogin> GetById(int id)
		{
			return await _dbContext.UserLogins.FirstOrDefaultAsync(x => x.Id ==id);
		}
	}
}
