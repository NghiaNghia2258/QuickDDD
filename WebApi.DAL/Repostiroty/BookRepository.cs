using Microsoft.EntityFrameworkCore;
using WebApi.BLL.Mapper.Model.Book;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.DAL.Repostiroty
{
	public class BookRepository : RepositoryBase<Book, int>, IBookRepository
	{
		public BookRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
		public async Task<bool> Create(Book book, PayloadToken payloadToken)
		{
			try
			{
				await CreateAsync(book, payloadToken);
				return true;
			}
			catch { return false; }
		}
		public async Task<bool> Update(Book book, PayloadToken payloadToken)
		{
			try
			{
				await UpdateAsync(book, payloadToken);
				return true;
			}
			catch { return false; }
		}
		public async Task<IEnumerable<Book>> GetAll(OptionFilterBook option)
		{
			IQueryable<Book> queryable = FindAll()
				.Select(x => new Book()
				{
					Id = x.Id,
					Title = x.Title,
				});
			BookDto.TotalRecordsCount = await queryable.CountAsync();
			return await queryable.ToListAsync();
		}
		public async Task<Book> GetById(int id)
		{
			return await FindAll()
				.Select(x => new Book()
				{
					Id = x.Id,
					Title = x.Title,
				}).FirstOrDefaultAsync() ?? new Book();
		}
	}
}
