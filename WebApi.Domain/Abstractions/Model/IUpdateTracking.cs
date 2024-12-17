namespace WebApi.Domain.Abstractions.Model
{
	public interface IUpdateTracking
	{
		DateTime? UpdatedAt { get; set; }
		string? UpdatedBy { get; set; }
		string? UpdatedName { get; set; }
	}
}
