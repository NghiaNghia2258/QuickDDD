using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.DAL.Repostiroty;

public class SubjectRepository : RepositoryBase<Subject, int>, ISubjectRepository
{
    public SubjectRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Subject>> GetAll(OptionFilterSubject option)
    {
        var query = _dbContext.Subjects;
        TotalRecords.SUBJECT = await query.CountAsync();
        return query
            .Skip((option.PageIndex - 1) * option.PageSize)
            .Take(option.PageSize)
            .ToList();
    }
}
