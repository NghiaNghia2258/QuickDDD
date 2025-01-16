using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class SchoolClass: EntityBase<int>, IAuditableEntity
{
    public string Code { get; set; } 
    public int? HomeroomTeacherId { get; set; }
    public int MaxStudents { get; set; } = 10;
    public int AvailableSlots { get; set; } = 10;
    public int Status { get; set; }
    public int MajorId { get; set; }
    public bool IsAvailableSlot { get; set; } = true;
    public DateTime CreatedAt { get ; set ; }
    public string CreatedBy { get ; set ; }
    public string CreatedName { get ; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
    public string? UpdatedName { get ; set ; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public string? DeletedName { get ; set ; }

    public virtual Major Major { get; set; }
    public virtual ICollection<SchoolClassStudent> Students { get; set; } = new List<SchoolClassStudent>();
    // Mối quan hệ "1 giáo viên chủ nhiệm 1 lớp"
    public virtual Teacher HomeroomTeacher { get; set; }

    // Mối quan hệ nhiều giáo viên giảng dạy nhiều lớp
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

}
