using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class Faculty : EntityBase<int>, ISoftDelete
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }

    public virtual ICollection<Major> Majors { get; set; } = new List<Major>();
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
