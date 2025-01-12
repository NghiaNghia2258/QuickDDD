using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.Domain.Abstractions.Repository;

public interface ISubjectRepository
{
    Task<List<Subject>> GetAll(OptionFilterSubject option);
    Task<Subject> GetById(int id);
}
