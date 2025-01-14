using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.Domain.Abstractions.Repository;

public interface IStudentRepository
{
    Task<bool> Create(Student student);
    Task<bool> Delete(int id);
    Task<List<Student>> GetAll(OptionFilterStudent option);
    Task<Student> GetById(int id);
    Task<bool> Update(Student student);
}
