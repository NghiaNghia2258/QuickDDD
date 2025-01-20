namespace WebApi.BLL.Mapper.SchoolClasses;

public class GetAllSchoolClassDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int? HomeroomTeacherId { get; set; }
    public string? HomeroomTeacherName { get; set; }
    public int MaxStudents { get; set; } = 10;
    public int AvailableSlots { get; set; } = 10;
    public int Status { get; set; }
    public int MajorId { get; set; }
    public string? MajorName { get; set; }
    public int? StudentCount { get; set; }
}
