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
    public async Task<IEnumerable<StudentGrade>> GetStudentGradeByClassIDAndSubjectId(int classId, int subjectId)
    {
        var queryStudenInClass = await _dbContext.Students
            .Include(x => x.SchoolClasses.Where(y => y.SchoolClassesId == classId)).ToListAsync();
        var queryGradeSubject = _dbContext.StudentGrades.Where(x => x.SubjectId == subjectId);

        var query = from student in queryStudenInClass.Where(x => x.SchoolClasses.Count > 0)
                    join grade in queryGradeSubject
                    on student.Id equals grade.StudentId into studentGradeGroup
                    from grade in studentGradeGroup.DefaultIfEmpty() 
                    select new StudentGrade
                    {
                        Id = grade == null ? 0 : grade.Id,
                        StudentId = student.Id,
                        SubjectId = subjectId,
                        Version = grade == null ? 0 : grade.Version,
                        PracticalGrade = grade == null ? 0 : grade.PracticalGrade,
                        HomeworkGrade = grade == null ? 0 : grade.HomeworkGrade,
                        ExamGrade = grade == null ? 0 : grade.ExamGrade,
                        AttendanceGrade = grade == null ? 0 : grade.AttendanceGrade,
                        Student = new Student()
                        {
                            Id = student.Id,
                            FullName = student.FullName,
                            Code = student.Code,
                        }
                    };

        return query.ToList();
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
        return await _dbContext.Teachers
            .Include(x => x.Subjects)
            .Include(x => x.SchoolClasses).FirstOrDefaultAsync(x => x.Id == id);
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
    public async Task<IEnumerable<Teacher>> GetBySubjectId(int subjectId)
    {
        return await _dbContext.Teachers.Include(x => x.Subjects).Where(x => x.Subjects.Any(s => s.Id == subjectId)).ToArrayAsync();
    }
    public async Task<IEnumerable<StudentFeedback>> GetFeedback(OptionFilterFeedback option)
    {
        var query = _dbContext.StudentFeedback
            .Include(x => x.StudentGrade)
            .ThenInclude(x => x.Student)
            .ThenInclude(x => x.SchoolClasses)
            .ThenInclude(x => x.StudentClass)
            .ThenInclude(x => x.SchoolClassTeacherSubject)
            .Where(x => 
        (option.TeacherId == null || 
            x.StudentGrade
            .Student
            .SchoolClasses
            .Any(y => y.StudentClass.SchoolClassTeacherSubject
            .Any(z => z.TeacherId == option.TeacherId)))
        && (option.ClassId == null || x.StudentGrade
            .Student
            .SchoolClasses
            .Any(y => y.SchoolClassesId == option.ClassId))
        );
        return await query.Skip(option.PageSize * (option.PageIndex - 1)).Take(option.PageSize).ToListAsync();
    }
}
