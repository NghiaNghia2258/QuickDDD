using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Const;
using WebApi.Domain.Models;
using WebApi.Domain.ParamsFilter;

namespace WebApi.DAL.Repostiroty;

public class StudentRepository : RepositoryBase<Student, int>, IStudentRepository
{
    public StudentRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task<int> GetOrdinalNumberOfCurrentYear()
    {
        int ordinal = await _dbContext.Students
            .CountAsync(x => x.CreatedAt.Year == TimeConst.CurrentYear);
        return ordinal;
    }
    public async Task<bool> CreateListStudent(List<Student> students)
    {
        await _dbContext.Students.AddRangeAsync(students);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<List<Student>> GetAll(OptionFilterStudent option)
    {
        var query = _dbContext.Students.Where(x =>
            (option.NameOrCode == null || (x.Code.Contains(option.NameOrCode) || x.FullName.Contains(option.NameOrCode)))
        );
        if(option.SchoolClassId != null)
        {
            query = query.Include(x => x.SchoolClasses.Where(y => y.Id == option.SchoolClassId)).Where(x => x.SchoolClasses.Any());
        }
        TotalRecords.STUDENT = await query.CountAsync();
        return await query.Skip(option.PageSize * (option.PageIndex - 1)).Take(option.PageSize).ToListAsync();
    }
    public async Task<Student> GetById(int id)
    {
        return await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<bool> Create(Student student)
    {
        await CreateAsync(student);
        return true;
    }
    public async Task<bool> Update(Student student)
    {
        await UpdateAsync(student);
        return true;
    }
    public async Task<bool> Delete(int id)
    {
        await DeleteAsync(id);
        return true;
    }
}
