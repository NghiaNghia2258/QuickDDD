using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Students;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class StudentService : ServiceBase, IStudentService
{
    public StudentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<bool> Create(CreateStudentDto model)
    {
        Student newStudent = _mapper.Map<Student>(model);



        await _unitOfWork.Student.Create(newStudent);
        return true;
    }

    public Task<IEnumerable<GetAllStudentDto>> GetAllStudents(OptionFilterStudent option)
    {
        throw new NotImplementedException();
    }
}
