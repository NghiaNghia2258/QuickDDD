using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class StudentGrade: EntityBase<int>, IUpdateTracking
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; } 
    public double PracticalGrade { get; set; }
    public double HomeworkGrade { get; set; } 
    public double ExamGrade { get; set; } 
    public double AttendanceGrade { get; set; } 

    public Student Student { get; set; } 
    public Subject Subject { get; set; }
    public virtual ICollection<StudentFeedback> StudentFeedbacks { get; set; } = new List<StudentFeedback>();

    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
    public string? UpdatedName { get ; set ; }
}
