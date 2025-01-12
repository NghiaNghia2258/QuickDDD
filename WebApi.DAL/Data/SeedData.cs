using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;

namespace WebApi.DAL.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Define roles with specific permissions
            var roles = new List<Role>
            {
                new Role { Id = 1,Code = "CREATE_TEACHER", Name = "CREATE_TEACHER" },
            };

            modelBuilder.Entity<Role>().HasData(roles);

            // Define role groups
            var roleGroups = new List<RoleGroup>
            {
                new RoleGroup { Id = 1,Code = "ADMIN", Name = "Admin" },
                new RoleGroup { Id = 3,Code = "TEACHER", Name = "Teacher" },
                new RoleGroup { Id = 2,Code = "USER", Name = "User" }
            };

            modelBuilder.Entity<RoleGroup>().HasData(roleGroups);

            var subjects = new List<Subject>()
            {
                new Subject(){Id = 1,Code = "TCC",Name = "Toán cao cấp"},
                new Subject(){Id = 2,Code = "VLDC", Name = "Vật lý đại cương"},
                new Subject(){Id = 3,Code = "OOP", Name = "Lập trình hướng đối tượng"},
            };
            modelBuilder.Entity<Subject>().HasData(subjects);

       

            // Define users and their role groups
            var userLogins = new List<UserLogin>
            {
                new UserLogin { Id = 1, Username = "admin", Password = "admin123", RoleGroupId = 1, IsDeleted = false },
                new UserLogin { Id = 2, Username = "user1", Password = "user123", RoleGroupId = 2, IsDeleted = false }
            };

            modelBuilder.Entity<UserLogin>().HasData(userLogins);

            // Map role groups to roles
            modelBuilder.Entity<RoleGroup>()
                .HasMany(rg => rg.Roles)
                .WithMany(r => r.RoleGroups)
                .UsingEntity(j => j.HasData(
                    new { RoleGroupsId = 1, RolesId = 1 },
                    new { RoleGroupsId = 1, RolesId = 2 },
                    new { RoleGroupsId = 1, RolesId = 3 },
                    new { RoleGroupsId = 1, RolesId = 4 }, // Admin has full permissions
                    new { RoleGroupsId = 2, RolesId = 4 } // User only has SELECT permission
                ));

            var faculties = new List<Faculty>
            {
                new Faculty { Id = 1, Code = "CS", Name = "Công nghệ thông tin", IsDeleted = false },
                new Faculty { Id = 2, Code = "EE", Name = "Kỹ thuật điện", IsDeleted = false },
                new Faculty { Id = 3, Code = "ME", Name = "Cơ khí", IsDeleted = false },
                new Faculty { Id = 4, Code = "CE", Name = "Xây dựng", IsDeleted = false },
                new Faculty { Id = 5, Code = "AE", Name = "Kỹ thuật môi trường", IsDeleted = false }
            };

            modelBuilder.Entity<Faculty>().HasData(faculties);
        }
    }
}
