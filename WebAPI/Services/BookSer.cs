using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services.Interface;

namespace WebAPI.Services
{
	public class BookSer: IBookSer
	{
		private readonly AppDbContext appDbContext;
		private readonly IMapper mapper;

		public BookSer(AppDbContext appDbContext, IMapper mapper)
		{
			this.appDbContext = appDbContext;
			this.mapper = mapper;
		}

		public void AddBook(BookDto model)
		{
			appDbContext.Books.Add(mapper.Map<Book>(model));
			appDbContext.SaveChanges();
		}
		public IEnumerable<BookDto> GetBooks() {
			var books = appDbContext.Books.ToList();
			return mapper.Map<IEnumerable<BookDto>>(books);
		}
		
	}
}
