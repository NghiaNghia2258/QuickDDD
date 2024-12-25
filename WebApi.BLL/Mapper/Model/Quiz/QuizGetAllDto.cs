namespace WebApi.BLL.Mapper.Model.Quiz;

public class QuizGetAllDto
{
    public int Id { get; set; }
    public int Verrsion { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Duration { get; set; }
    public int SubjectId { get; set; }
    public string? SubjectName { get; set; }
}
