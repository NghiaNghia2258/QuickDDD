using AutoMapper;
using WebApi.BLL.Mapper.Model.Category;
using WebApi.BLL.Mapper.Model.Product;
using WebApi.Domain.Models;

namespace WebApi.BLL.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Category,CategoryDto>().ReverseMap();
			CreateMap<CreateCategoryDto,Category>();
			CreateMap<Category,CategoryGetAllDto>();
			
			CreateMap<Product,ProductDto>().ReverseMap();
			CreateMap<CreateProductDto,Product>();
			CreateMap<Product,ProductGetAllDto>();
		}
	}
}
