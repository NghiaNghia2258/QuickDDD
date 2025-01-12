using Microsoft.AspNetCore.Http;

namespace WebApi.BLL.Interfaces
{
	public interface IAuthoziService
	{
		Task IsAuthozi(string role = "");
	}
}
