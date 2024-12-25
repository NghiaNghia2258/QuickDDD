using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Mapper.Model.Quiz;
using WebApi.BLL.ServicesBase;
using WebApi.Domain.Abstractions;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;
using WebApi.Shared.Utilities;

namespace WebApi.BLL.Services;

public class QuizService : ServiceBase, IQuizService
{
    public QuizService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config) : base(unitOfWork, mapper, config)
    {
    }

    public async Task<bool> Add(CreateQuizDto quiz, HttpContext httpContext)
    {
        Quiz newQuiz = _mapper.Map<Quiz>(quiz);
        PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
        await _unitOfWork.QuizRepository.Add(newQuiz, payload);
        return true;
    }

    public async Task<bool> Update(QuizDto quiz, HttpContext httpContext)
    {
        Quiz updatedQuiz = _mapper.Map<Quiz>(quiz);
        PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
        await _unitOfWork.QuizRepository.Update(updatedQuiz, payload);
        return true;
    }

    public async Task<bool> Delete(int id, HttpContext httpContext)
    {
        PayloadToken payload = JwtTokenHelper.GetPayloadToken(httpContext, _config);
        await _unitOfWork.QuizRepository.Delete(id, payload);
        return true;
    }

    public async Task<IEnumerable<QuizGetAllDto>> GetAll(OptionFilterQuiz option)
    {
        var quizzes = await _unitOfWork.QuizRepository.GetAll(option);
        return _mapper.Map<IEnumerable<QuizGetAllDto>>(quizzes);
    }

    public async Task<QuizDto> GetById(int id)
    {
        Quiz quiz = await _unitOfWork.QuizRepository.GetById(id);
        return _mapper.Map<QuizDto>(quiz);
    }
}
