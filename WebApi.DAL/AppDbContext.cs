using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using WebApi.Domain.Abstractions.Model;
using WebApi.Domain.Models;

namespace WebApi.DAL
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

		public virtual DbSet<Role> Roles { get; set; }

		public virtual DbSet<RoleGroup> RoleGroups { get; set; }

		public virtual DbSet<UserLogin> UserLogins { get; set; }
		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LEDG467\\SQLEXPRESS;Initial Catalog=AppDB;Integrated Security=True;Trust Server Certificate=True");



		private static LambdaExpression GenerateQueryFilterLambda(Type entityType)
		{
			// Tham số đại diện cho thực thể: "w =>"
			var parameter = Expression.Parameter(entityType, "w");

			// Truy cập thuộc tính IsDeleted: "w.IsDeleted"
			var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));

			// Biểu thức so sánh: "w.IsDeleted == false"
			var equalExpression = Expression.Equal(propertyAccess, Expression.Constant(false));

			// Tạo Lambda Expression: "w => w.IsDeleted == false"
			return Expression.Lambda(equalExpression, parameter);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			modelBuilder.Entity<Book>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("PK__Book__3214EC07534DB846");

				entity.ToTable("Book");
			});

			modelBuilder.Entity<RoleGroup>(entity =>
			{
				entity.HasMany(d => d.Roles).WithMany(p => p.RoleGroups)
					.UsingEntity<Dictionary<string, object>>(
						"RoleRoleGroup",
						r => r.HasOne<Role>().WithMany().HasForeignKey("RolesId"),
						l => l.HasOne<RoleGroup>().WithMany().HasForeignKey("RoleGroupsId"),
						j =>
						{
							j.HasKey("RoleGroupsId", "RolesId");
							j.ToTable("RoleRoleGroup");
							j.HasIndex(new[] { "RolesId" }, "IX_RoleRoleGroup_RolesId");
						});
			});

			modelBuilder.Entity<UserLogin>(entity =>
			{
				entity.HasIndex(e => e.RoleGroupId, "IX_UserLogins_RoleGroupId");

				entity.HasOne(d => d.RoleGroup).WithMany(p => p.UserLogins).HasForeignKey(d => d.RoleGroupId);
			});

			var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes()
	        .Where(type => typeof(ISoftDelete).IsAssignableFrom(type)
		        && type.IsClass
		        && !type.IsAbstract);
			foreach (var softDeleteEntity in softDeleteEntities)
			{
				modelBuilder.Entity(softDeleteEntity).HasQueryFilter(GenerateQueryFilterLambda(softDeleteEntity));
			}
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
