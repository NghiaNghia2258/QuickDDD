namespace WebApi.BLL.Mapper.Teachers;

public class GetAllTeacherDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsDepartmentHead { get; set; }
    public int FacultyId { get; set; }
}
