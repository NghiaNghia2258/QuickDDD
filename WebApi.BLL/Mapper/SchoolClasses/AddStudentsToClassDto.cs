namespace WebApi.BLL.Mapper.SchoolClasses;

public class AddStudentsToClassDto
{
    public int SchoolClassId { get; set; }
    public IEnumerable<int> StudentIds { get; set; } = Enumerable.Empty<int>();
}
