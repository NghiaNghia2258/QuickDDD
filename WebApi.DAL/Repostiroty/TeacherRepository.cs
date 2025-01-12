using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty;

public class TeacherRepository : RepositoryBase<Teacher, int>, ITeacherRepository
{
    public TeacherRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task<bool> Create(Teacher model)
    {
        await CreateAsync(model);
        return true;
    }
    public async Task<int> GetOrdinalNumberOfCurrentYear()
    {
        int ordinal = await _dbContext.Teachers.CountAsync(x => x.CreatedAt.Year == TimeConst.CurrentYear);
        return 0;
    }
}
