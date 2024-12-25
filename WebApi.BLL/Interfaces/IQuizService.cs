using Microsoft.AspNetCore.Http;
using WebApi.BLL.Mapper.Model.Quiz;
using WebApi.Domain.ParamsFilter;

namespace WebApi.BLL.Interfaces;

public interface IQuizService
{
    Task<bool> Add(CreateQuizDto quiz, HttpContext httpContext);
    Task<bool> Delete(int id, HttpContext httpContext);
    Task<IEnumerable<QuizGetAllDto>> GetAll(OptionFilterQuiz option);
    Task<QuizDto> GetById(int id);
    Task<bool> Update(QuizDto quiz, HttpContext httpContext);
}
