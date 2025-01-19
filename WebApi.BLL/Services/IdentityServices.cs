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
    private IHttpContextAccessor _httpContextAccessor;


    public IdentityServices(IAuthenRepository authenRepository, IAuthoziRepository authoziRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _authenRepository = authenRepository;
        _authoziRepository = authoziRepository;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<PayloadToken> SignIn(ParamasSignInRequest paramas)
	{
		UserLogin userlogin = await _authenRepository.SignIn(paramas);
		if (userlogin.Username == null) {
			return new PayloadToken();
		}
		PayloadToken payloadToken = new PayloadToken();
		payloadToken.Username = userlogin.Username;
		Student isStudent = await _authenRepository.GetStudentById(userlogin.Id);
		if(isStudent != null)
		{
			payloadToken.UserLoginId = isStudent.Id;
			payloadToken.FullName = isStudent.FullName;
		}
        Teacher isTeacher = await _authenRepository.GetTeacherById(userlogin.Id);
        if (isTeacher != null)
        {
            payloadToken.UserLoginId = isTeacher.Id;
			payloadToken.FullName = isTeacher.FullName;
        }
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
		payloadToken.RoleGroupId = userlogin.RoleGroupId;
		return payloadToken;
	}

	public async Task<bool> SignUp(ParamasSignUpRequest paramas)
	{
		bool isSignUpSuccess = await _authenRepository.SignUp(paramas);
		return isSignUpSuccess;
	}

	public async Task IsAuthozi(string role = "")
	{
		PayloadToken payload = JwtTokenHelper.GetPayloadToken(_httpContextAccessor.HttpContext, _config);
		if(string.IsNullOrEmpty(role) && payload != null)
		{
			return;
		}
		bool isAuthozi = await _authoziRepository.IsAuthozi(payload.UserLoginId,role);
		if(!isAuthozi)
		{
			throw new AuthoziException("UnAuthozi");
		}
	}
}
