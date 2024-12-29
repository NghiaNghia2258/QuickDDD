namespace WebApi.BLL.Mapper.Model.Subjects;

public class SubjectGetAllDto
{
    public int Id { get; set; }
    public int Version { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
