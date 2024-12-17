using WebApi.Domain.Const;

namespace WebApi.Domain.ApiResult
{
	public class ApiNotFoundResult : ApiResult
	{
		public List<string> Errors { set; get; }
		public ApiNotFoundResult(string message = "Not found") : base(false, message, StatusCodeCustom.NOTFOUND)
		{
			Errors = new List<string>();
		}
		public ApiNotFoundResult(List<string> errs, string message = "Not found") : base(false, message, StatusCodeCustom.NOTFOUND)
		{
			Errors = errs;
		}
	}
}
