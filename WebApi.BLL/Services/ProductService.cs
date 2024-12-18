using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Product;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.BLL.Services
{
	public class ProductService : ServiceBase, IProductService
	{
		public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config) : base(unitOfWork, mapper, config)
		{
		}

		public async Task<bool> Add(CreateProductDto product, HttpContext httpContext)
		{
			Product newProduct = _mapper.Map<Product>(product);
			PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
			await _unitOfWork.ProductRepository.Add(newProduct, payload);
			return true;
		}

		public async Task<bool> Update(ProductDto product, HttpContext httpContext)
		{
			Product updatedProduct = _mapper.Map<Product>(product);
			PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
			await _unitOfWork.ProductRepository.Update(updatedProduct, payload);
			return true;
		}

		public async Task<bool> Delete(int id, HttpContext httpContext)
		{
			PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
			await _unitOfWork.ProductRepository.Delete(id, payload);
			return true;
		}

		public async Task<IEnumerable<ProductGetAllDto>> GetAll(OptionFilterProduct option)
		{
			var products = await _unitOfWork.ProductRepository.GetAll(option);
			return _mapper.Map<IEnumerable<ProductGetAllDto>>(products);
		}

		public async Task<ProductDto> GetById(int id)
		{
			Product product = await _unitOfWork.ProductRepository.GetById(id);
			return _mapper.Map<ProductDto>(product);
		}
	}
}
