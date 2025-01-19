using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface IStudentGradeRepository
{
    Task Create(StudentGrade studentGrade);
    Task Delete(int id);
    Task<StudentGrade> GetById(int id);
    Task<StudentGrade> GetByStudentIdAndSubjectId(int studentId, int subjectId);
    Task Update(StudentGrade studentGrade);
}
