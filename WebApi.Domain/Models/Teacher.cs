using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class Teacher: EntityBase<int>, IAuditableEntity
{
    public string Code { get; set; } 
    public string FullName { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 
    public bool IsDepartmentHead { get; set; }
    public int FacultyId { get; set; }
    public int UserLoginId { get; set; }
    public DateTime CreatedAt { get ; set ; }
    public string CreatedBy { get ; set ; }
    public string CreatedName { get ; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
    public string? UpdatedName { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public DateTime? DeletedAt { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public string? DeletedName { get ; set ; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    // Mối quan hệ với các lớp mà giáo viên chủ nhiệm
    public virtual ICollection<SchoolClass> HomeroomClasses { get; set; } = new List<SchoolClass>();

    // Mối quan hệ với các lớp mà giáo viên giảng dạy
    public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
    public virtual ICollection<SchoolClassTeacherSubject> SchoolClassTeacherSubject { get; set; } = new List<SchoolClassTeacherSubject>();
    public virtual Faculty Faculty { get; set; }
    public virtual UserLogin UserLogin { get; set; }

}
