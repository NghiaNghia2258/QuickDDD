using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Category;
using WebApi.Domain.ApiResult;
using WebApi.Domain.Const;
using WebApi.Domain.ParamsFilter;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IAuthoziService _authoziService;

		public CategoryController(ICategoryService categoryService, IAuthoziService authoziService)
		{
			_categoryService = categoryService;
			_authoziService = authoziService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] OptionFilterCategory option) {

			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.SELECT_CATEGORY);

			ApiResult res = new ApiSuccessResult();
			IEnumerable<CategoryGetAllDto> categories = await _categoryService.GetAll(option);
			res = new ApiSuccessResult<IEnumerable<CategoryGetAllDto>>(categories);
			return Ok(res);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.SELECT_CATEGORY);

			ApiResult res = new ApiSuccessResult();
			CategoryDto category = await _categoryService.GetById(id);
			res = new ApiSuccessResult<CategoryDto>(category);
			return Ok(res);
		}
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCategoryDto model)
		{

			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.CREATE_CATEGORY);

			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _categoryService.Add(model, HttpContext);
			return Ok(res);
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] CategoryDto model)
		{

			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.UPDATE_CATEGORY);

			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _categoryService.Update(model, HttpContext);
			return Ok(res);
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{

			await _authoziService.IsAuthozi(HttpContext, role: RoleNameConst.DELETE_CATEGORY);

			ApiResult res = new ApiSuccessResult();
			bool isSuccess = await _categoryService.Delete(id, HttpContext);
			return Ok(res);
		}
	}
}
