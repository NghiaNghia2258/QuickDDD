using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Subjects;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Services;

public class SubjectService : ServiceBase, ISubjectService
{
    public SubjectService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config) : base(unitOfWork, mapper, config)
    {
    }

    public async Task<IEnumerable<SubjectGetAllDto>> GetAll(OptionFilterSubject option)
    {
        var subjects = await _unitOfWork.SubjectRepository.GetAll(option);
        return _mapper.Map<IEnumerable<SubjectGetAllDto>>(subjects);
    }
}
