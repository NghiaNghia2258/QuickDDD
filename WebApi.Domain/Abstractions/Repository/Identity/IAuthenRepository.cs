using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Mapper.Identity;

namespace WebApi.Domain.Abstractions.Repository.Identity
{
	public interface IAuthenRepository
	{
        Task<bool> Create(UserLogin userLogin);
        Task<IEnumerable<UserLogin>> GetAll(OptionFilterUser option);
        Task<UserLogin> GetById(int id);
        Task<Student> GetStudentById(int id);
        Task<Teacher> GetTeacherById(int id);
        Task<UserLogin> SignIn(ParamasSignInRequest model);
		Task<bool> SignUp(ParamasSignUpRequest model);
        Task<bool> Update(UserLogin userLogin);
    }
}
