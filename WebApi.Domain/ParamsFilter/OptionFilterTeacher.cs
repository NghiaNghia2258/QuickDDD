namespace WebApi.Domain.ParamsFilter;

public class OptionFilterTeacher: PagingRequestParameters
{
    public string? NameOrCode { get; set; }
}
