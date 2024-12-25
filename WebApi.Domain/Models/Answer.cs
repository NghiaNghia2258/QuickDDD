using WebApi.Domain.Abstractions;

namespace WebApi.Domain.Models
{
    public class Answer : EntityBase<int>
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; } = null!;

    }

}
