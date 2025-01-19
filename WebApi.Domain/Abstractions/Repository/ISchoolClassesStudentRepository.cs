
using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface ISchoolClassesStudentRepository
{
    Task Create(SchoolClassStudent schoolClassStudent);
    Task Delete(int studentId, int schoolClassId);
}
