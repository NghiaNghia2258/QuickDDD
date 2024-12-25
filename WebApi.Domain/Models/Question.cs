using WebApi.Domain.Abstractions;

namespace WebApi.Domain.Models
{
    public class Question : EntityBase<int>
    {
        public string Content { get; set; } = string.Empty;
        
        public virtual Quiz Quiz { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
