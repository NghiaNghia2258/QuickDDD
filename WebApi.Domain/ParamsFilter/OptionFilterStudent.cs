namespace WebApi.Domain.ParamsFilter;

public class OptionFilterStudent: PagingRequestParameters
{
    public string? NameOrCode { get; set; }
}
