using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface ISchoolClassService
{
    Task<bool> Delete(int id);
    Task<IEnumerable<GetAllSchoolClassDto>> GetAll(OptionFilterSchoolClass option);
    Task<GetByIdSchoolClassDto> GetById(int id);
    Task<bool> Update(GetByIdSchoolClassDto model);
}
