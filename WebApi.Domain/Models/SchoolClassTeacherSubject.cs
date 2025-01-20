namespace WebApi.Domain.Models;

public class SchoolClassTeacherSubject
{
    public int SchoolClassId { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    public virtual SchoolClass SchoolClass { get; set; }
    public virtual Teacher Teacher { get; set; }
    public virtual Subject Subject { get; set; }
}
