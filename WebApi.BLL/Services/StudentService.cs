using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Students;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class StudentService : ServiceBase, IStudentService
{
    public StudentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public Task<bool> Create(CreateStudentDto model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GetAllStudentDto>> GetAllStudents(OptionFilterStudent option)
    {
        throw new NotImplementedException();
    }
}
