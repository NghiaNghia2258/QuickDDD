using WebApi.BLL.Mapper.Model.Subjects;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface ISubjectService
{
    Task<IEnumerable<SubjectGetAllDto>> GetAll(OptionFilterSubject option);

}
