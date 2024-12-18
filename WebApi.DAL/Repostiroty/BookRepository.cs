using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty
{
	public class BookRepository : RepositoryBase<Book, int>, IBookRepository
	{
		public BookRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
	}
}
