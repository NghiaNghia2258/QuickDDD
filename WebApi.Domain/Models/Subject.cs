using WebApi.Domain.Abstractions;
using WebApi.Domain.Abstractions.Model;

namespace WebApi.Domain.Models;

public class Subject: EntityBase<int>, ISoftDelete
{
    public string Code { get; set; } 
    public string Name { get; set; } 
    public bool IsMandatory { get; set; } 
    public int Semester { get; set; } 
    public int TheoryCredits { get; set; } 
    public int PracticeCredits { get; set; } 
    public int ExerciseCredits { get; set; } 
    public bool IsIncludedInGPA { get; set; }
    public bool IsDeleted { get ; set ; }
    public DateTime? DeletedAt { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public string? DeletedName { get ; set ; }

    public virtual ICollection<Major> Majors { get; set; } = new List<Major>();
    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = new List<StudentGrade>();

}
