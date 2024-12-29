using AutoMapper;
using WebApi.BLL.Mapper.Model.Quiz;
using WebApi.BLL.Mapper.Model.Subjects;
using WebApi.Domain.Models;

namespace WebApi.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quiz, QuizDto>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name)) 
                .ReverseMap();

            CreateMap<CreateQuizDto, Quiz>();
            CreateMap<Quiz, QuizGetAllDto>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));

            CreateMap<Subject, SubjectGetAllDto>().ReverseMap();

        }
    }
}
