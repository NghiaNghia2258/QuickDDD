using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.Domain.Abstractions.Repository;

public interface ISchoolClassRepository
{
    Task<int> Create(SchoolClass schoolClass);
    Task<bool> Delete(int id);
    Task<List<SchoolClass>> GetAll(OptionFilterSchoolClass option);
    Task<SchoolClass> GetById(int id);
    Task<SchoolClass> GetOneClassesByMajorIdWithAvailableSlot(int majorId);
    Task<bool> Update(SchoolClass schoolClass);
}
