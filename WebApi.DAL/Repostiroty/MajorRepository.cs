using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty;

public class MajorRepository : RepositoryBase<Major, int>, IMajorRepository
{
    public MajorRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task<Major> GetById(int id)
    {
        return await _dbContext.Majors.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<int> CountClassesByIdInCurrentYear(int id)
    {
        return await _dbContext.SchoolClasses.CountAsync(x => x.MajorId == id && x.CreatedAt.Year == TimeConst.CurrentYear);
    }
    public async Task<bool> Create(Major major)
    {
        await CreateAsync(major);
        return true;
    }

    public async Task<bool> Update(Major major)
    {
        await UpdateAsync(major);
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        await DeleteAsync(id);
        return true;
    }
    public async Task<IEnumerable<Major>> GetMajorsByFacultyId(int facultyId)
    {
        return await _dbContext.Majors.Where(x => x.FacultyId == facultyId).ToListAsync();
    }
}
