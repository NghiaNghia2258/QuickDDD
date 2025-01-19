using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty
{
    public class SchoolClassesStudentRepository: ISchoolClassesStudentRepository
    {
        private AppDbContext _appDbContext;
        public SchoolClassesStudentRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public async Task Delete(int studentId,int schoolClassId)
        {
            SchoolClassStudent schoolClassStudent = await _appDbContext.SchoolClassStudent.FirstOrDefaultAsync(x => x.SchoolClassesId == schoolClassId && x.StudentsId == studentId);
             _appDbContext.SchoolClassStudent.Remove(schoolClassStudent);
             await _appDbContext.SaveChangesAsync();
        }
        public async Task Create(SchoolClassStudent schoolClassStudent)
        {
            _appDbContext.SchoolClassStudent.Add(schoolClassStudent);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
