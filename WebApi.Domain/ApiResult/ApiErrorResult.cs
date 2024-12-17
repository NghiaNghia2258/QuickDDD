using WebApi.Domain.Const;

namespace WebApi.Domain.ApiResult
{
	public class ApiErrorResult : ApiResult
	{
		public List<string> Errors { set; get; }
		public ApiErrorResult(): base(false)
		{
			Message = MESSAGE_ERROR;
			StatusCode = StatusCodeCustom.ERROR;
		}
		public ApiErrorResult(string message) : base(false, message, StatusCodeCustom.ERROR)
		{
			Errors = new List<string>();
		}
		public ApiErrorResult(List<string> errs) : base(false, StatusCodeCustom.ERROR)
		{
			Errors = errs;
			Message = MESSAGE_ERROR;
		}
		public ApiErrorResult(List<string> errs,string message) : base(false, message, StatusCodeCustom.ERROR)
		{
			Errors = errs;
		}
	}
}
