using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.DAL.Data;
public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var roles = new List<Role>
        {
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "User" },
            new Role { Id = 3, Name = "Guest" }
        };

        modelBuilder.Entity<Role>().HasData(roles);

        var roleGroups = new List<RoleGroup>
        {
            new RoleGroup { Id = 1, Name = "Administrator Group" },
            new RoleGroup { Id = 2, Name = "User Group" },
            new RoleGroup { Id = 3, Name = "Guest Group" }
        };

        modelBuilder.Entity<RoleGroup>().HasData(roleGroups);

        var userLogins = new List<UserLogin>
        {
            new UserLogin { Id = 1, Username = "admin", Password = "admin123", RoleGroupId = 1, IsDeleted = false },
            new UserLogin { Id = 2, Username = "user1", Password = "user123", RoleGroupId = 2, IsDeleted = false },
            new UserLogin { Id = 3, Username = "guest1", Password = "guest123", RoleGroupId = 3, IsDeleted = false }
        };

        modelBuilder.Entity<UserLogin>().HasData(userLogins);

        modelBuilder.Entity<RoleGroup>()
            .HasMany(rg => rg.Roles)
            .WithMany(r => r.RoleGroups)
            .UsingEntity(j => j.HasData(
                new { RoleGroupsId = 1, RolesId = 1 },
                new { RoleGroupsId = 2, RolesId = 2 },
                new { RoleGroupsId = 3, RolesId = 3 }
            ));
    }
}