using AutoMapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Subjects;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class SubjectService : ServiceBase, ISubjectService
{
    public SubjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    public async Task<List<GetAllSubjectDto>> GetAll(OptionFilterSubject option)
    {
        List<Subject> subjects = await _unitOfWork.Subject.GetAll(option);
        return _mapper.Map<List<GetAllSubjectDto>>(subjects);
    }
}
