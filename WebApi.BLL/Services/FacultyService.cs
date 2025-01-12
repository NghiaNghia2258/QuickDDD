using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Faculties;
using WebApi.BLL.Mapper.Subjects;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;

namespace WebApi.BLL.Services;

public class FacultyService : ServiceBase, IFacultyService
{
    public FacultyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<List<GetAllFacultyDto>> GetAll()
    {
        List<Faculty> faculties = await _unitOfWork.Faculty.GetAll();
        return _mapper.Map<List<GetAllFacultyDto>>(faculties);
    }
}
