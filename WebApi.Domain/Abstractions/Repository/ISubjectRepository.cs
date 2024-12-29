using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.Domain.Abstractions.Repository;

public interface ISubjectRepository
{
    Task<IEnumerable<Subject>> GetAll(OptionFilterSubject option);

}
