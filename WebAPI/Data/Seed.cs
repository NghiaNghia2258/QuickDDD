using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
	public static class Seed
	{
		public static void SeedData(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().HasData(
				new Book { Id = 1, Title = "The Catcher in the Rye" },
				new Book { Id = 2, Title = "To Kill a Mockingbird" },
				new Book { Id = 3, Title = "1984" });
		}
	}
}
