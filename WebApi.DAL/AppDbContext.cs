using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using WebApi.DAL.Data;
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


        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentFee> StudentFees { get; set; }
        public virtual DbSet<StudentFeedback> StudentFeedback { get; set; }
        public virtual DbSet<StudentGrade> StudentGrades { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SchoolClass> SchoolClasses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AppDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");



		private static LambdaExpression GenerateQueryFilterLambda(Type entityType)
		{
			var parameter = Expression.Parameter(entityType, "w");

			var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));

			var equalExpression = Expression.Equal(propertyAccess, Expression.Constant(false));

			return Expression.Lambda(equalExpression, parameter);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			SeedData.Seed(modelBuilder);
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

            modelBuilder.Entity<SchoolClass>()
				.HasOne(sc => sc.HomeroomTeacher)  // Mỗi lớp có một giáo viên chủ nhiệm
				.WithMany(t => t.HomeroomClasses)  // Một giáo viên có thể làm chủ nhiệm nhiều lớp
				.HasForeignKey(sc => sc.HomeroomTeacherId)  // Khóa ngoại trong bảng SchoolClass
				.OnDelete(DeleteBehavior.Restrict);  // Không tự động xóa giáo viên khi lớp bị xóa

            // Cấu hình mối quan hệ "1 giáo viên giảng dạy ở nhiều lớp" (many-to-many)
            modelBuilder.Entity<SchoolClass>()
                .HasMany(sc => sc.Teachers)  // Mỗi lớp có thể có nhiều giáo viên giảng dạy
                .WithMany(t => t.SchoolClasses)  // Một giáo viên có thể giảng dạy nhiều lớp
                .UsingEntity(j => j.ToTable("SchoolClassTeacher"));

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
