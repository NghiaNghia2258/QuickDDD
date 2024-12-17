using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Services.Interface;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookSer service;

		public BookController(IBookSer service)
		{
			this.service = service;
		}
		[HttpPost("AddBook")]
		public IActionResult Add(BookDto model)
		{
			service.AddBook(model);
			return Ok("Thêm thành công");
		}
		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var res = service.GetBooks();
			return Ok(res);
		}
	}
}
