using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface IQuizRepository
{
    Task<bool> Add(Quiz quiz, PayloadToken payload);
    Task<bool> Delete(int id, PayloadToken payload);
    Task<IEnumerable<Quiz>> GetAll(OptionFilterQuiz option);
    Task<Quiz> GetById(int id);
    Task<bool> Update(Quiz quiz, PayloadToken payload);
}
