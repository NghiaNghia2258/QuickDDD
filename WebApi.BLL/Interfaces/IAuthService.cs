using WebApi.Shared.Mapper.Identity;
using WebApi.Shared.Models;

namespace WebApi.BLL.Interfaces;
public interface IAuthService
{
	Task<PayloadToken> SignIn(ParamasSignInRequest paramas);
	Task<bool> SignUp(ParamasSignUpRequest paramas);
}
