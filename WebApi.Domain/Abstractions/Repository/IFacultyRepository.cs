using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface IFacultyRepository
{
    Task<List<Faculty>> GetAll();
    Task<Faculty> GetById(int id);
}
