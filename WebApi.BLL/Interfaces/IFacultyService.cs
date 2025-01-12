using WebApi.BLL.Mapper.Faculties;

namespace WebApi.BLL.Interfaces;

public interface IFacultyService
{
    Task<List<GetAllFacultyDto>> GetAll();
}
