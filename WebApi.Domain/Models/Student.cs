using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class Student: EntityBase<int>, IAuditableEntity
{
    public string Code { get; set; }
    public string FullName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Ward { get; set; }
    public string? Gender { get; set; }
    public string? IdentityCardNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int EnrollmentYear { get; set; }
    public int Status { get; set; }
    public int UserLoginId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string? UpdatedName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }

    public virtual ICollection<StudentFee> StudentFees { get; set; } = new List<StudentFee>();

    public virtual UserLogin UserLogin { get; set; }
    public virtual ICollection<SchoolClassStudent> SchoolClasses { get; set; } = new List<SchoolClassStudent>();
}
