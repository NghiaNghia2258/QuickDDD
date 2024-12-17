using WebAPI.DTO;

namespace WebAPI.Services.Interface
{
	public interface IBookSer
	{
		void AddBook(BookDto model);
		IEnumerable<BookDto> GetBooks();
	}
}
