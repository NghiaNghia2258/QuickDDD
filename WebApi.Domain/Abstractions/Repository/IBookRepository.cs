using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.Domain.Abstractions.Repository
{
	public interface IBookRepository
	{
		Task<bool> Create(Book book, PayloadToken payloadToken);
		Task<IEnumerable<Book>> GetAll(OptionFilterBook option);
		Task<Book> GetById(int id);
		Task<bool> Update(Book book, PayloadToken payloadToken);
	}
}
