using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.DAL.Repostiroty
{
	public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext dbContext) : base(dbContext)
		{
		}
		public async Task<bool> Add(Category category, PayloadToken payload)
		{
			await CreateAsync(category, payload);
			return true;
		}
		public async Task<bool> Update(Category category, PayloadToken payload)
		{
			await UpdateAsync(category, payload);
			return true;
		}
		public async Task<bool> Delete(int id, PayloadToken payload)
		{
			await DeleteAsync(id,payload);
			return true;
		}
		public async Task<IEnumerable<Category>> GetAll(OptionFilterCategory option)
		{
			var query = _dbContext.Categories
				.Select(x => new Category()
				{
					Id = x.Id,
					CategoryName = x.CategoryName,
				});
			TotalRecords.CATEGORY = await query.CountAsync();
			return query
				.Skip((option.PageIndex - 1)*option.PageSize)
				.Take(option.PageSize)
				.ToList();
		}
		public async Task<Category> GetById(int id)
		{
			return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
