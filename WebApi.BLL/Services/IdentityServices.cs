using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Identity;
using WebApi.Shared.Models;

namespace WebApi.BLL.Services;

public class IdentityServices : IAuthService, IAuthoziService
{
	public Task<PayloadToken> SignIn(ParamasSignInRequest paramas)
	{
		throw new NotImplementedException();
	}

	public Task<bool> SignUp(ParamasSignUpRequest paramas)
	{
		throw new NotImplementedException();
	}
}
