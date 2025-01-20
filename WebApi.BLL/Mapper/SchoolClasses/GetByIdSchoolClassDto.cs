using WebApi.BLL.Mapper.Students;

namespace WebApi.BLL.Mapper.SchoolClasses;

public class GetByIdSchoolClassDto: GetAllSchoolClassDto
{
    public bool IsAvailableSlot { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string? UpdatedName { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }
    public int Version { get; set; }
    public IEnumerable<TeacherSubjectDto> Teachers { get; set; }
}
