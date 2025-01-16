namespace WebApi.Domain.Models;
public class SchoolClassStudent
{
    public int SchoolClassesId { get; set; }
    public int StudentsId { get; set; }
    public virtual Student Student { get; set; }
    public virtual SchoolClass StudentClass { get; set; }
}
