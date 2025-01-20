namespace WebApi.Domain.ParamsFilter;

public class OptionFilterFeedback: PagingRequestParameters
{
    public int? TeacherId { get; set; }
    public int? ClassId { get; set; }
}
