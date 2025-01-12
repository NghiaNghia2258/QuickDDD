namespace WebApi.BLL.Mapper.Teachers;

public class CreateTeacherDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int FacultyId { get; set; }
    public List<int> SubjectIds { get; set; }
}
