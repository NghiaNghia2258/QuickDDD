using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.Domain.Models;
using WebApi.Shared.Exceptions;
using WebApi.Shared.Mapper.Identity;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.BLL.Services;

public class IdentityServices : IAuthService, IAuthoziService
{
	private readonly IAuthenRepository _authenRepository;
	private readonly IAuthoziRepository _authoziRepository ;
	protected readonly IConfiguration _config;


	public IdentityServices(IAuthenRepository authenRepository, IAuthoziRepository authoziRepository, IConfiguration config)
	{
		_authenRepository = authenRepository;
		_authoziRepository = authoziRepository;
		_config = config;
	}

	public async Task<PayloadToken> SignIn(ParamasSignInRequest paramas)
	{
		UserLogin userlogin = await _authenRepository.SignIn(paramas);
		if (userlogin.Username == null) {
			return new PayloadToken();
		}
		PayloadToken payloadToken = new PayloadToken();
		payloadToken.Username = userlogin.Username;
		payloadToken.UserLoginId = userlogin.Id;
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

	public async Task IsAuthozi(HttpContext httpContext, string role = "")
	{
		PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
		if(string.IsNullOrEmpty(role) && payload != null)
		{
			return;
		}
		bool isAuthozi = await _authoziRepository.IsAuthozi(payload.UserLoginId,role);
		if(!isAuthozi)
		{
			throw new AuthoziException("Xác thực token thất bại vui lòng đọc file readme.md để biết thêm chi tiết về model phân quyền");
		}
	}
}
