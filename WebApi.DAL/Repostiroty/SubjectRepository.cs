using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

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
    public async Task<List<Subject>> GetAll(OptionFilterSubject option)
    {
        var data = await FindAll()
            .Include(x => x.Teachers)
            .Include(x => x.Majors)
            .ThenInclude(x => x.SchoolClasses)
            .Where(x => (option.FacultyId == null || x.Majors.Any(y => y.FacultyId == option.FacultyId))
            && (option.ClassId == null || x.Majors.Any(y => y.SchoolClasses.Any(z => z.Id == option.ClassId)))
            )
            .ToListAsync();
        return data;
    }
}
