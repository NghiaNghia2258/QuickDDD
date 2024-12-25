using WebApi.Domain.Abstractions;

namespace WebApi.Domain.Models
{
    public class Subject : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
