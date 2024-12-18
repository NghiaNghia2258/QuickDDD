using WebApi.BLL.Interfaces;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.Domain.Models;
using WebApi.Shared.Mapper.Identity;
using WebApi.Shared.Models;

namespace WebApi.BLL.Services;

public class IdentityServices : IAuthService, IAuthoziService
{
	private readonly IAuthenRepository _authenRepository;
	private readonly IAuthoziRepository _authoziRepository ;

	public IdentityServices(IAuthenRepository authenRepository, IAuthoziRepository authoziRepository)
	{
		_authenRepository = authenRepository;
		_authoziRepository = authoziRepository;
	}

	public async Task<PayloadToken> SignIn(ParamasSignInRequest paramas)
	{
		Userlogin userlogin = await _authenRepository.SignIn(paramas);
		if (userlogin.Username == null) {
			return new PayloadToken();
		}
		PayloadToken payloadToken = new PayloadToken();
		payloadToken.Username = userlogin.Username;
		List<RoleDto> roles = new List<RoleDto>();
		foreach(var item in userlogin.RoleGroup.Roles)
		{
			roles.Add(new RoleDto
			{
				Id = item.Id,
				Name = item.Name,
			});
		}
		payloadToken.Roles = roles;
		return payloadToken;
	}

	public async Task<bool> SignUp(ParamasSignUpRequest paramas)
	{
		bool isSignUpSuccess = await _authenRepository.SignUp(paramas);
		return isSignUpSuccess;
	}
}
