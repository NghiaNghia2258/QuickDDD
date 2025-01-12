using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface ISubjectRepository
{
    Task<Subject> GetById(int id);
}
