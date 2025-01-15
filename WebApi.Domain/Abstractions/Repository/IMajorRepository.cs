using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface IMajorRepository
{
    Task<int> CountClassesByIdInCurrentYear(int id);
    Task<bool> Create(Major major);
    Task<bool> Delete(int id);
    Task<Major> GetById(int id);
    Task<IEnumerable<Major>> GetMajorsByFacultyId(int facultyId);
    Task<bool> Update(Major major);
}
