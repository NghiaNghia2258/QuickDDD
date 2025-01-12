using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class Major : EntityBase<int>, ISoftDelete
{
    public string Name { get; set; }
    public int FacultyId { get; set; }
    public bool IsDeleted { get ; set ; }
    public DateTime? DeletedAt { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public string? DeletedName { get ; set ; }
    public virtual Faculty Faculty { get; set; } = null!;
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
}
