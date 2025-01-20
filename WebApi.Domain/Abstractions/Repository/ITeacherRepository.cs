using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.Domain.Abstractions.Repository;

public interface ITeacherRepository
{
    Task<bool> Create(Teacher model);
    Task<bool> Delete(int id);
    Task<List<Teacher>> GetAll(OptionFilterTeacher option);
    Task<Teacher> GetById(int id);
    Task<IEnumerable<Teacher>> GetBySubjectId(int subjectId);
    Task<int> GetOrdinalNumberOfCurrentYear();
    Task<IEnumerable<StudentGrade>> GetStudentGradeByClassIDAndSubjectId(int classId, int subjectId);
    Task<bool> Update(Teacher teacher);
}
