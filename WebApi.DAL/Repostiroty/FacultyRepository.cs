using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty;

public class FacultyRepository : RepositoryBase<Faculty, int>, IFacultyRepository
{
    public FacultyRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task<Faculty> GetById(int id)
    {
        return await _dbContext.Faculties.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<Faculty>> GetAll()
    {
        return await FindAll().ToListAsync();
    }
}
