using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

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
        return ordinal;
    }
    public async Task<List<Teacher>> GetAll(OptionFilterTeacher option)
    {
        var query = FindAll().Where(x => option.NameOrCode == null || (x.Code.Contains(option.NameOrCode) || x.FullName.Contains(option.NameOrCode)));
        return await query.Skip(option.PageSize * (option.PageIndex-1)).Take(option.PageSize).ToListAsync();
    }
    public async Task<Teacher> GetById(int id)
    {
        return await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<bool> Delete(int id)
    {
        await DeleteAsync(id);
        return true;
    }
    public async Task<bool> Update(Teacher teacher)
    {
        await UpdateAsync(teacher);
        return true;
    }
}
