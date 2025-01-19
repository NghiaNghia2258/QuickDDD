namespace WebApi.BLL.Mapper.Students;

public class GetAllStudentDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string? ClassCode { get; set; }
    public string? MajorName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Ward { get; set; }
    public string? Gender { get; set; }
    public string? IdentityCardNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int EnrollmentYear { get; set; }
    public int Status { get; set; }
    public int version { get; set; }
}
