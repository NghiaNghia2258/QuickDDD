using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Book;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.BLL.Services;

public class BookService : ServiceBase, IBookService
{
	public BookService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config) : base(unitOfWork, mapper, config)
	{
	}

	public async Task<bool> Create(CreateBookDto book, HttpContext httpContext)
	{
		Book newBook = _mapper.Map<Book>(book);
		PayloadToken payloadToken = JwtTokenHelper.GetPayloadToken(httpContext,_config);
		bool isCreatedSuccess = await _unitOfWork.BookRepository.Create(newBook, payloadToken);
		return isCreatedSuccess;
	}
	public async Task<IEnumerable<BookDto>> GetAll(OptionFilterBook option)
	{
		IEnumerable<Book> books = await _unitOfWork.BookRepository.GetAll(option);
		return _mapper.Map<IEnumerable<BookDto>>(books);
	}
}
