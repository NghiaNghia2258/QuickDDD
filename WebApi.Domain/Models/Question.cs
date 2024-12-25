namespace WebApi.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        
        public virtual Quiz Quiz { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
