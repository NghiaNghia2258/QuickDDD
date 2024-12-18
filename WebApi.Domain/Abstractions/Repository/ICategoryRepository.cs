using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface ICategoryRepository
{
	Task<bool> Add(Category category, PayloadToken payload);
	Task<bool> Delete(int id, PayloadToken payload);
	Task<IEnumerable<Category>> GetAll(OptionFilterCategory option);
	Task<Category> GetById(int id);
	Task<bool> Update(Category category, PayloadToken payload);
}
