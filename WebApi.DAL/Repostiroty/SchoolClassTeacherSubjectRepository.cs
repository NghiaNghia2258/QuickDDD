using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Abstractions.Repository;
using WebApi.Domain.Models;

namespace WebApi.DAL.Repostiroty;

public class SchoolClassTeacherSubjectRepository: ISchoolClassTeacherSubjectRepository
{
    private readonly AppDbContext _appDbContext;

    public SchoolClassTeacherSubjectRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task TaskAsync(int schoolClassId, int teacherId, int subjectId)
    {
        SchoolClassTeacherSubject entity = await _appDbContext.SchoolClassTeacherSubject.FirstOrDefaultAsync(x => x.SchoolClassId == schoolClassId && x.TeacherId == teacherId && x.SubjectId == subjectId);
        _appDbContext.SchoolClassTeacherSubject.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }
}
