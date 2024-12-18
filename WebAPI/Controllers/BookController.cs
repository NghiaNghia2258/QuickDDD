﻿using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}
	}
}
