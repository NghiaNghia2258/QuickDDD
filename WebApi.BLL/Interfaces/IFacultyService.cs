using WebApi.BLL.Mapper.Faculties;
using WebApi.BLL.Mapper.Majors;

namespace WebApi.BLL.Interfaces;

public interface IFacultyService
{
    Task<List<GetAllFacultyDto>> GetAll();
    Task<IEnumerable<GetMajorsByFacultyIdDto>> GetMajorsById(int id);
}
