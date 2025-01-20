namespace WebApi.Domain.ParamsFilter;

public class OptionFilterSubject: PagingRequestParameters
{
    public int? FacultyId { get; set; }
    public int? ClassId { get; set; }
}
