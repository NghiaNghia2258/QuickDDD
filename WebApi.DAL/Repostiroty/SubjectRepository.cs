using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty;

public class SubjectRepository : RepositoryBase<Subject, int>, ISubjectRepository
{
    public SubjectRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task<Subject> GetById(int id)
    {
        return await _dbContext.Subjects.FirstOrDefaultAsync(x => x.Id == id);
    }
}
