using WebApi.Domain.Const;

namespace WebApi.Domain.ApiResult
{
	public class ApiSuccessResult : ApiResult
	{
		public ApiSuccessResult() : base(true)
		{
			Message = MESSAGE_SUCCESS;
			StatusCode = StatusCodeCustom.SUCCESS;
		}
		public ApiSuccessResult(int statuscode) : base(true, statuscode)
		{
			Message = MESSAGE_SUCCESS;
		}
		public ApiSuccessResult(string message) : base(true, message, StatusCodeCustom.SUCCESS)
		{
		}
		public ApiSuccessResult(int statuscode,string message) : base(true, message, statuscode)
		{
		}
	}
	public class ApiSuccessResult<T> : ApiSuccessResult
	{
		private T _data;
		private long _fetchedRecordsCount;
		public T Data { get => _data; }
		public long FetchedRecordsCount
		{
			get
			{
				if (_fetchedRecordsCount <= 0) { return 1; }
				else { return _fetchedRecordsCount; }
			}
			set => _fetchedRecordsCount = value;
		}
		public int TotalRecordsCount { get; set; }
		public ApiSuccessResult(T data, int statuscode, string message) : base(statuscode, message)
		{
			_data = data;
		}
		public ApiSuccessResult(T data) : base()
		{
			_data = data;
		}
		public ApiSuccessResult(T data, int statuscode) : base(statuscode)
		{
			_data = data;
		}
		public ApiSuccessResult(T data, string message) : base(message)
		{
			_data = data;
		}
	}

}
