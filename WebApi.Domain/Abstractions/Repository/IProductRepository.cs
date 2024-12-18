using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface IProductRepository
{
	Task<bool> Add(Product product, PayloadToken payload);
	Task<bool> Delete(int id, PayloadToken payload);
	Task<IEnumerable<Product>> GetAll(OptionFilterProduct option);
	Task<Product> GetById(int id);
	Task<bool> Update(Product product, PayloadToken payload);
}
