using Microsoft.AspNetCore.Http;
using WebApi.BLL.Mapper.Model.Category;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.BLL.Interfaces;

public interface ICategoryService
{
	Task<bool> Add(CreateCategoryDto category, HttpContext httpContext);
	Task<bool> Delete(int id, HttpContext httpContext);
	Task<IEnumerable<CategoryGetAllDto>> GetAll(OptionFilterCategory option);
	Task<CategoryDto> GetById(int id);
	Task<bool> Update(CategoryDto category, HttpContext httpContext);
}
