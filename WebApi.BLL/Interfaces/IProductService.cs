using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BLL.Mapper.Model.Product;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces
{
	public interface IProductService
	{
		Task<bool> Add(CreateProductDto product, HttpContext httpContext);
		Task<bool> Delete(int id, HttpContext httpContext);
		Task<IEnumerable<ProductGetAllDto>> GetAll(OptionFilterProduct option);
		Task<ProductDto> GetById(int id);
		Task<bool> Update(ProductDto product, HttpContext httpContext);
	}
}
