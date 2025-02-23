﻿using Microsoft.AspNetCore.Http;
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
    public async Task<IEnumerable<StudentGrade>> GetGradeById(int id)
    {
        return await _dbContext.StudentGrades.Include(x => x.Subject).Include(x => x.StudentFeedbacks).Where(x => x.StudentId == id).ToListAsync();
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
        var query = _dbContext.Students
            .Include(x => x.SchoolClasses)
            .ThenInclude(x => x.StudentClass)
            .ThenInclude(x => x.Major)
            .Where(x =>
            (option.NameOrCode == null || (x.Code.Contains(option.NameOrCode) || x.FullName.Contains(option.NameOrCode)))
        );
        if(option.SchoolClassId != null)
        {
            query = query.Include(x => x.SchoolClasses.Where(y => y.SchoolClassesId == option.SchoolClassId)).Where(x => x.SchoolClasses.Count > 0);
        }
        TotalRecords.STUDENT = await query.CountAsync();
        var res = await query.Skip(option.PageSize * (option.PageIndex - 1)).Take(option.PageSize).ToListAsync();
        return res.Where(x => option.SchoolClassId == null || x.SchoolClasses.Count > 0).ToList();
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
