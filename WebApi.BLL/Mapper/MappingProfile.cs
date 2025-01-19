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
        CreateMap<Student,GetAllStudentDto>()
            .ForMember(dest => dest.ClassCode , ost => ost.MapFrom(x => x.SchoolClasses.First().StudentClass.Code))
            .ForMember(dest => dest.MajorName , ost => ost.MapFrom(x => x.SchoolClasses.First().StudentClass.Major.Name))
            ;
        CreateMap<CreateStudentDto,Student>();
        CreateMap<Major,GetMajorsByFacultyIdDto>();
        CreateMap<UpdateStudentGradeDto, StudentGrade>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); ;
        CreateMap<StudentGrade,StudentGradeDto>()
             .ForMember(dest => dest.StudentCode, ost => ost.MapFrom(x => x.Student.Code))
             .ForMember(dest => dest.StudentName, ost => ost.MapFrom(x => x.Student.FullName))
             .ForMember(dest => dest.SubjectName, ost => ost.MapFrom(x => x.Subject.Name))
            .ReverseMap();
        CreateMap<SchoolClass, GetByIdSchoolClassDto>().ForMember(
           dest => dest.MajorName, ost => ost.MapFrom(x => x.Major.Name)
            ).ReverseMap();
        CreateMap<SchoolClass, GetAllSchoolClassDto>().ForMember(
           dest => dest.MajorName, ost => ost.MapFrom(x => x.Major.Name)
            );
    }
}
