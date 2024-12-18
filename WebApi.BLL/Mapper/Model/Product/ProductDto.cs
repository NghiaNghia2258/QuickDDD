namespace WebApi.BLL.Mapper.Model.Product
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public int CategoryId { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }

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
}
