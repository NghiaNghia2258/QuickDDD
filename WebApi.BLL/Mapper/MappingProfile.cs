using AutoMapper;
using WebApi.BLL.Mapper.Faculties;
using WebApi.BLL.Mapper.Subjects;
using WebApi.BLL.Mapper.Teachers;
using WebApi.Domain.Models;

namespace WebApi.BLL.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateTeacherDto,Teacher>();
        CreateMap<Subject,GetAllSubjectDto>();
        CreateMap<Faculty,GetAllFacultyDto>();
    }
}
