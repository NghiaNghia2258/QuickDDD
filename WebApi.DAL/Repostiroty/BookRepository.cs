using AutoMapper;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty
{
	public class BookRepository : RepositoryBase<Book, int>, IBookRepository
	{
		protected BookRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}
	}
}
