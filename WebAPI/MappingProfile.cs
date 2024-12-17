using AutoMapper;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, BookDto>().ReverseMap();
		}
	}
}
