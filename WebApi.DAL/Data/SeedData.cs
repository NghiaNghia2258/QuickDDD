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
                new RoleGroup { Id = 4,Code = "STUDENT", Name = "Student" },
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
                    new { RoleGroupsId = 2, RolesId = 1 },
                    new { RoleGroupsId = 3, RolesId = 1 }

                ));

            var faculties = new List<Faculty>
            {
                new Faculty { Id = 1, Code = "CS", Name = "Công nghệ thông tin", IsDeleted = false },
                new Faculty { Id = 2, Code = "EE", Name = "Kỹ thuật điện", IsDeleted = false },
                new Faculty { Id = 3, Code = "ME", Name = "Cơ khí", IsDeleted = false },
                new Faculty { Id = 4, Code = "CE", Name = "Xây dựng", IsDeleted = false },
            };

            modelBuilder.Entity<Faculty>().HasData(faculties);

            var majors = new List<Major> { 
                new Major { Id = 1,Code = "101",Name = "Khoa học máy tính",FacultyId = 1},
                new Major { Id = 2,Code = "125",Name = "Kỹ thuật phần mềm",FacultyId = 1},
                new Major { Id = 3,Code = "210",Name = "Hệ thông điện", FacultyId = 2},
                new Major { Id = 4,Code = "225",Name = "Điện công nghiệp và dân dụng", FacultyId = 2},
                new Major { Id = 5,Code = "315",Name = "Sức bền vật liệu", FacultyId = 3},
                new Major { Id = 6,Code = "323",Name = "Khí động học", FacultyId = 3},
                new Major { Id = 7,Code = "411",Name = "Kỹ thuật xây dựng", FacultyId = 4},
                new Major { Id = 8,Code = "431",Name = "Kỹ thuật vật liệu", FacultyId = 4},
            };
            modelBuilder.Entity<Major>().HasData(majors);
        }
    }
}
