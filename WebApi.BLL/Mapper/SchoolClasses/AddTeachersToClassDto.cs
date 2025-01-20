namespace WebApi.BLL.Mapper.SchoolClasses;

public class AddTeachersToClassDto
{
    public int SchoolClassId { get; set; }
    public IEnumerable<TeacherSubjectDto> Teachers { get; set; }
}
public class TeacherSubjectDto
{
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
}
