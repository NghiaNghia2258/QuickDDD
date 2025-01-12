using WebApi.BLL.Mapper.Teachers;

namespace WebApi.BLL.Interfaces;

public interface ITeacherService
{
    Task<bool> Create(CreateTeacherDto model);
}
