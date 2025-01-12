using WebApi.Domain.Abstractions;

namespace WebApi.Domain.Models;

public class StudentFeedback: EntityBase<int>
{
    public string Content { get; set; } 
    public int Rating { get; set; } 
    public string Review { get; set; }
    public int StudentGradeId { get; set; }

    public virtual StudentGrade StudentGrade { get; set; }
}
