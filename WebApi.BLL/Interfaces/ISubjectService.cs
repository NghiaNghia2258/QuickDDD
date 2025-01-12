using WebApi.BLL.Mapper.Subjects;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface ISubjectService
{
    Task<List<GetAllSubjectDto>> GetAll(OptionFilterSubject option);
}
