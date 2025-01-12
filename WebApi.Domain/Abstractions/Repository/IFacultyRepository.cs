using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface IFacultyRepository
{
    Task<Faculty> GetById(int id);
}
