using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;

namespace WebApi.BLL.Services;

public class BookService : ServiceBase, IBookService
{
	public BookService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}
}
