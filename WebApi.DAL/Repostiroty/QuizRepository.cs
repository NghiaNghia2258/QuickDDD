using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;
using WebApi.Shared.Models;

namespace WebApi.DAL.Repostiroty;

public class QuizRepository : RepositoryBase<Quiz, int>, IQuizRepository
{
    public QuizRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> Add(Quiz quiz, PayloadToken payload)
    {
        await CreateAsync(quiz, payload);
        return true;
    }

    public async Task<bool> Delete(int id, PayloadToken payload)
    {
        await DeleteAsync(id, payload);
        return true;
    }

    public async Task<IEnumerable<Quiz>> GetAll(OptionFilterQuiz option)
    {
        var query = _dbContext.Quizzes
                .Include(x => x.Subject)
                .Select(q => new Quiz
                {
                    Id = q.Id,
                    Title = q.Title,
                    Description = q.Description,
                    Duration = q.Duration,
                    Subject = new Subject
                    {
                        Name = q.Subject.Name 
                    }
                })
                ;
        TotalRecords.QUIZ = await query.CountAsync();
        return query
            .Skip((option.PageIndex - 1) * option.PageSize)
            .Take(option.PageSize)
            .ToList();
    }

    public async Task<Quiz> GetById(int id)
    {
        return await _dbContext.Quizzes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> Update(Quiz quiz, PayloadToken payload)
    {
        await UpdateAsync(quiz, payload);
        return true;
    }
}
