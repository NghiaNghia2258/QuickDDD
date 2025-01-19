using WebApi.Domain.Models;
using WebApi.Shared.Mapper.Identity;

namespace WebApi.Domain.Abstractions.Repository.Identity
{
	public interface IAuthenRepository
	{
        Task<Student> GetStudentById(int id);
        Task<Teacher> GetTeacherById(int id);
        Task<UserLogin> SignIn(ParamasSignInRequest model);
		Task<bool> SignUp(ParamasSignUpRequest model);
	}
}
