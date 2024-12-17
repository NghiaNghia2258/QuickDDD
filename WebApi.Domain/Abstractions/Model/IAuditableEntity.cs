namespace WebApi.Domain.Abstractions.Model
{
	public interface IAuditableEntity : ICreateTracking, IUpdateTracking, ISoftDelete
	{
	}
}
