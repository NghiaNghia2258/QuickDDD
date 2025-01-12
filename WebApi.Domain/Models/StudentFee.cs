using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class StudentFee: EntityBase<int>, IAuditableEntity
{
    public string FeeType { get; set; }
    public double Amount { get; set; }
    public DateTime DueDate { get; set; }
    public double CollectedAmount { get; set; }
    public int PaymentStatus { get; set; }
    public string StudentId { get; set; }

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

    public virtual Student Student { get; set; }
}
