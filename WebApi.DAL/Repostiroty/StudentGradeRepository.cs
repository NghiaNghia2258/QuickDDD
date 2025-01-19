using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty;

public class StudentGradeRepository : RepositoryBase<StudentGrade, int>, IStudentGradeRepository
{
    public StudentGradeRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(dbContext, httpContextAccessor, config)
    {
    }
    public async Task Create(StudentGrade studentGrade)
    {
        await CreateAsync(studentGrade);
    }
    public async Task Update(StudentGrade studentGrade)
    {
        await UpdateAsync(studentGrade);
    }
    public async Task Delete(int id)
    {
        await DeleteAsync(id);
    }
    public async Task<StudentGrade> GetById(int id)
    {
        return await _dbContext.StudentGrades.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<StudentGrade> GetByStudentIdAndSubjectId(int studentId, int subjectId)
    {
        return await _dbContext.StudentGrades.FirstOrDefaultAsync(x => x.StudentId == studentId && x.SubjectId == subjectId);
    }
}
