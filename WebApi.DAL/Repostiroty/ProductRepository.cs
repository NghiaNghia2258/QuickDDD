using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.DAL.Repostiroty;

public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
{
	public ProductRepository(AppDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<bool> Add(Product product, PayloadToken payload)
	{
		await CreateAsync(product, payload);
		return true;
	}

	public async Task<bool> Update(Product product, PayloadToken payload)
	{
		await UpdateAsync(product, payload);
		return true;
	}

	public async Task<bool> Delete(int id, PayloadToken payload)
	{
		await DeleteAsync(id, payload);
		return true;
	}

	public async Task<IEnumerable<Product>> GetAll(OptionFilterProduct option)
	{
		var query = _dbContext.Products
			.Select(x => new Product()
			{
				Id = x.Id,
				ProductName = x.ProductName,
				Price = x.Price,
				CategoryId = x.CategoryId,
				Quantity = x.Quantity,
			});

		TotalRecords.PRODUCT = await query.CountAsync();
		return await query
			.Skip((option.PageIndex - 1) * option.PageSize)
			.Take(option.PageSize)
			.ToListAsync();
	}

	public async Task<Product> GetById(int id)
	{
		return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
	}
}
