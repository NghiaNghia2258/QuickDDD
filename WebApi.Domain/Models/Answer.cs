namespace WebApi.Domain.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; } = null!;

    }

}
