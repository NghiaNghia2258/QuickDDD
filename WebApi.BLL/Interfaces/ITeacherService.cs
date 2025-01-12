using WebApi.BLL.Mapper.Teachers;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface ITeacherService
{
    Task<bool> Create(CreateTeacherDto model);
    Task<bool> Delete(int id);
    Task<List<GetAllTeacherDto>> GetAll(OptionFilterTeacher option);
    Task<GetByIdTeacherDto> GetById(int id);
    Task<bool> Update(GetByIdTeacherDto model);
}
