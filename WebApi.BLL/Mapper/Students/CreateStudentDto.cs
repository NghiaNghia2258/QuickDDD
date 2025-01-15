namespace WebApi.BLL.Mapper.Students;

public class CreateStudentDto
{
    public string FullName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Ward { get; set; }
    public string? Gender { get; set; }
    public string? IdentityCardNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int MajorId { get; set; }
    public string MajorCode { get; set; }
}
