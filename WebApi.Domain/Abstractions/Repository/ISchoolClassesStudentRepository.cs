
namespace WebApi.Domain.Abstractions.Repository;

public interface ISchoolClassesStudentRepository
{
    Task Delete(int studentId, int schoolClassId);
}
