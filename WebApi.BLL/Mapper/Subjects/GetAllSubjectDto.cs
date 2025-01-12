namespace WebApi.BLL.Mapper.Subjects;

public class GetAllSubjectDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsMandatory { get; set; }
    public int Semester { get; set; }
    public int TheoryCredits { get; set; }
    public int PracticeCredits { get; set; }
    public int ExerciseCredits { get; set; }
}
