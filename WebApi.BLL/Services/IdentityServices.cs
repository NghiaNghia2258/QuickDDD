using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Exceptions;
using WebApi.Shared.Mapper.Identity;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.BLL.Services;

public class IdentityServices : ServiceBase, IAuthService, IAuthoziService
{
    private readonly IAuthenRepository _authenRepository;
    private readonly IAuthoziRepository _authoziRepository;
    protected readonly IConfiguration _config;
    private IHttpContextAccessor _httpContextAccessor;

    public IdentityServices(IUnitOfWork unitOfWork, IMapper mapper, IAuthenRepository authenRepository, IAuthoziRepository authoziRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper)
    {

        _authenRepository = authenRepository;
        _authoziRepository = authoziRepository;
        _config = config;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<PayloadToken> SignIn(ParamasSignInRequest paramas)
    {
        UserLogin userlogin = await _authenRepository.SignIn(paramas);
        if (userlogin.Username == null)
        {
            return new PayloadToken();
        }
        PayloadToken payloadToken = new PayloadToken();
        payloadToken.Username = userlogin.Username;
        payloadToken.UserLoginId = userlogin.Id;
        List<RoleDto> roles = new List<RoleDto>();
        foreach (var item in userlogin.RoleGroup.Roles)
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

    public async Task IsAuthozi(string role = "")
    {
        PayloadToken payload = JwtTokenHelper.GetPayloadToken(_httpContextAccessor.HttpContext, _config);
        if (string.IsNullOrEmpty(role) && payload != null)
        {
            return;
        }
        bool isAuthozi = await _authoziRepository.IsAuthozi(payload.UserLoginId, role);
        if (!isAuthozi)
        {
            throw new AuthoziException("UnAuthozi");
        }
    }
    public async Task<List<UserLogin>> GetAllUsersAsync(OptionFilterUser option)
    {
        return await _unitOfWork.Identity.GetAllUsersAsync(option);
    }
    public async Task UpdateAccBLL(string username, string pass, int role)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be null or empty", nameof(username));
        }
        var user = await _unitOfWork.Identity.GetUserByUsernameAsync(username);

        if (user == null)
        {
            throw new InvalidOperationException("User not found");
        }

        user.Password = pass;//mã hóa
        user.RoleGroupId = role;

        await _unitOfWork.Identity.UpdateAccount(user);
    }
}
