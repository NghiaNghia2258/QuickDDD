using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Product;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IAuthoziService _authoziService;

		public ProductController(IProductService productService, IAuthoziService authoziService)
		{
			_productService = productService;
			_authoziService = authoziService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] OptionFilterProduct option)
		{
			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.SELECT_PRODUCT);

			ApiResult res = new ApiSuccessResult();
			IEnumerable<ProductGetAllDto> products = await _productService.GetAll(option);
			res = new ApiSuccessResult<IEnumerable<ProductGetAllDto>>(products);
			return Ok(res);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.SELECT_PRODUCT);

			ApiResult res = new ApiSuccessResult();
			ProductDto product = await _productService.GetById(id);
			res = new ApiSuccessResult<ProductDto>(product);
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductDto model)
		{
			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.CREATE_PRODUCT);

			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _productService.Add(model, HttpContext);
			res = isSuccess ? new ApiSuccessResult() : new ApiErrorResult("Failed to create product");
			return Ok(res);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] ProductDto model)
		{
			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.UPDATE_PRODUCT);

			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _productService.Update(model, HttpContext);
			res = isSuccess ? new ApiSuccessResult() : new ApiErrorResult("Failed to update product");
			return Ok(res);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.DELETE_PRODUCT);

			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _productService.Delete(id, HttpContext);
			res = isSuccess ? new ApiSuccessResult() : new ApiErrorResult("Failed to delete product");
			return Ok(res);
		}
	}
}
