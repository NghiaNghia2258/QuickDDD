namespace WebApi.BLL.Mapper.Model.Category;

public class CategoryDto
{
	public int Id { get; set; }
	public string CategoryName { get; set; }
	public DateTime CreatedAt { get; set; }
	public string CreatedBy { get; set; }
	public string CreatedName { get; set; }
	public DateTime? UpdatedAt { get; set; }
	public string? UpdatedBy { get; set; }
	public string? UpdatedName { get; set; }
	public bool IsDeleted { get; set; }
	public DateTime? DeletedAt { get; set; }
	public string? DeletedBy { get; set; }
	public string? DeletedName { get; set; }

}
