namespace WebApi.Domain.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Duration { get; set; }
        public int SubjectId { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public Subject Subject { get; set; } = null!;
    }
}
