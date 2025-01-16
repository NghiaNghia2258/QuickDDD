using AutoMapper;
using WebApi.BLL.Mapper.Faculties;
using WebApi.BLL.Mapper.Majors;
using WebApi.BLL.Mapper.SchoolClasses;
using WebApi.BLL.Mapper.Students;
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
        CreateMap<Teacher,GetAllTeacherDto>();
        CreateMap<Teacher,GetByIdTeacherDto>().ReverseMap();
        CreateMap<Student,GetByIdStudentDto>().ReverseMap();
        CreateMap<Student,GetAllStudentDto>();
        CreateMap<CreateStudentDto,Student>();
        CreateMap<Major,GetMajorsByFacultyIdDto>();
        CreateMap<SchoolClass, GetByIdSchoolClassDto>().ForMember(
           dest => dest.MajorName, ost => ost.MapFrom(x => x.Major.Name)
            ).ReverseMap();
        CreateMap<SchoolClass, GetAllSchoolClassDto>().ForMember(
           dest => dest.MajorName, ost => ost.MapFrom(x => x.Major.Name)
            );
    }
}
