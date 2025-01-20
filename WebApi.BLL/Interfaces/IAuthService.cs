using WebApi.BLL.Mapper.Userlogins;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Mapper.Identity;
using WebApi.Shared.Models;

namespace WebApi.BLL.Interfaces;
public interface IAuthService
{
    Task ChangePassword(ChangePassword model);
    Task<List<UserloginDto>> Getall(OptionFilterUser option);
    Task<PayloadToken> SignIn(ParamasSignInRequest paramas);
	Task<bool> SignUp(ParamasSignUpRequest paramas);
}
