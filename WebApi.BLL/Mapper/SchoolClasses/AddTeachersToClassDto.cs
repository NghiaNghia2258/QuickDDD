namespace WebApi.BLL.Mapper.SchoolClasses;

public class AddTeachersToClassDto
{
    public int SchoolClassId { get; set; }
    public IEnumerable<int> TeacherIds { get; set; }
}
