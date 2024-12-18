using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Category;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.BLL.Services;

public class CategoryService : ServiceBase, ICategoryService
{
	public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config) : base(unitOfWork, mapper, config)
	{
	}
	public async Task<bool> Add(CreateCategoryDto category,HttpContext httpContext)
	{
		Category newCate = _mapper.Map<Category>(category);
		PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
		await _unitOfWork.CategoryRepository.Add(newCate, payload);
		return true;
	}
	public async Task<bool> Update(CategoryDto category,HttpContext httpContext)
	{
		Category cate = _mapper.Map<Category>(category);
		PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
		await _unitOfWork.CategoryRepository.Update(cate, payload);
		return true;
	}
	public async Task<bool> Delete(int id,HttpContext httpContext)
	{
		PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
		await _unitOfWork.CategoryRepository.Delete(id, payload);
		return true;
	}
	public async Task<IEnumerable<CategoryGetAllDto>> GetAll(OptionFilterCategory option)
	{
		var cate = await _unitOfWork.CategoryRepository.GetAll(option);
		return _mapper.Map<IEnumerable<CategoryGetAllDto>>(cate);
	}
	public async Task<CategoryDto> GetById(int id)
	{
		Category cate = await _unitOfWork.CategoryRepository.GetById(id);
		return _mapper.Map<CategoryDto>(cate);
	}
}
