using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.DAL.Repostiroty;

public class SchoolClassRepository : RepositoryBase<SchoolClass, int>, ISchoolClassRepository
{
    public SchoolClassRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task<List<SchoolClass>> GetAll(OptionFilterSchoolClass option)
    {
        var query = _dbContext.SchoolClasses
            .Include(x => x.Major)
            .Include(x => x.Students)
            .ThenInclude(x => x.Student);

        TotalRecords.SCHOOL_CLASS = await query.CountAsync();
        return await query.Skip(option.PageSize * (option.PageIndex - 1)).Take(option.PageSize).ToListAsync();
    }
    public async Task<SchoolClass> GetOneClassesByMajorIdWithAvailableSlot(int majorId)
    {
        return await _dbContext.SchoolClasses.FirstOrDefaultAsync(x => x.IsAvailableSlot && x.MajorId == majorId);
    }
    public async Task<SchoolClass> GetById(int id)
    {
        return await _dbContext.SchoolClasses
            .Include(x => x.Major)
            .Include(x => x.Students)
            .ThenInclude(x => x.Student)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(SchoolClass schoolClass)
    {
        return await CreateAsync(schoolClass);
    }

    public async Task<bool> Update(SchoolClass schoolClass)
    {
        await UpdateAsync(schoolClass);
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        await DeleteAsync(id);
        return true;
    }
}
