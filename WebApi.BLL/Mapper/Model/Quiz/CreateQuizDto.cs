namespace WebApi.BLL.Mapper.Model.Quiz;

public class CreateQuizDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Duration { get; set; }
    public int SubjectId { get; set; }
}
