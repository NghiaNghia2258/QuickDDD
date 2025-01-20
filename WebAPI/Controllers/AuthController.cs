using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Userlogins;
using WebApi.Domain.ApiResult;
using WebApi.Domain.ParamsFilter;
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
		[HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterUser option)
		{
			ApiResult res = new ApiSuccessResult();
			var data = await _authService.Getall(option);
			res = new ApiSuccessResult<List<UserloginDto>>(data);
			return Ok(res);
		}
		[HttpPost("change-pass")]
        public async Task<IActionResult> GetAll(ChangePassword model)
        {
            ApiResult res = new ApiSuccessResult();
            await _authService.ChangePassword(model);
            return Ok(res);
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
					RefreshToken = JwtTokenHelper.GenerateJwtToken(token, _configuration),
					RoleGroupId = token.RoleGroupId,
					UserLoginId = token.UserLoginId
				};
				res = new ApiSuccessResult<TokenLogin>(tokenLogin);
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
