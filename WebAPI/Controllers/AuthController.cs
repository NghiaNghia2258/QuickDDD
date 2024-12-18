using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.UserLogin;
using WebApi.Domain.ApiResult;
using WebApi.Shared.Mapper.Identity;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		private readonly IAuthoziService _authoziService;
		private readonly IConfiguration _configuration;

		public AuthController(IAuthService authService, IAuthoziService authoziService, IConfiguration configuration)
		{
			_authService = authService;
			_authoziService = authoziService;
			_configuration = configuration;
		}

		[HttpPost("sign-in")]
		public async Task<IActionResult> SignIn([FromBody] ParamasSignInRequest model)
		{
			ApiResult res = new ApiSuccessResult();
			PayloadToken token = await _authService.SignIn(model);
			if (token != null) {
				TokenLogin tokenLogin = new TokenLogin()
				{
					AccessToken = JwtTokenHelper.GenerateJwtToken(token,_configuration),
					RefreshToken = JwtTokenHelper.GenerateJwtToken(token, _configuration)
				};
			}
			else
			{
				res = new ApiErrorResult();
			}
			return Ok(res);
		}
		[HttpPost("sign-up")]
		public async Task<IActionResult> SignUp([FromBody] ParamasSignUpRequest model)
		{
			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _authService.SignUp(model);
			if (isSuccess)
			{

			}
			else
			{
				res = new ApiErrorResult();
			}
			return Ok(res);
		}
	}
}
