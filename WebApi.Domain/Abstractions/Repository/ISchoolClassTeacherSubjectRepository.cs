
namespace WebApi.Domain.Abstractions.Repository;

public interface ISchoolClassTeacherSubjectRepository
{
    Task TaskAsync(int schoolClassId, int teacherId, int subjectId);
}
