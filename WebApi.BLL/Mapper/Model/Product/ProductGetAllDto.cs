﻿namespace WebApi.BLL.Mapper.Model.Product
{
	public class ProductGetAllDto
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public int CategoryId { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
	}
}