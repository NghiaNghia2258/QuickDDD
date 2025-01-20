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
                new Role { Id = 2,Code = "RULE_STUDENT", Name = "RULE_STUDENT" },
                new Role { Id = 3,Code = "RULE_TEACHER", Name = "RULE_TEACHER" },
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

            var subjects = new List<Subject>()
            {
                new Subject(){Id = 1,Code = "TCC",Name = "Toán cao cấp"},
                new Subject(){Id = 2,Code = "VLDC", Name = "Vật lý đại cương"},
                new Subject(){Id = 3,Code = "OOP", Name = "Lập trình hướng đối tượng"},
                new Subject(){Id = 4,Code = "HDC", Name = "Hóa học đại cương"},
                new Subject(){Id = 5,Code = "TML", Name = "Triết học Mác - Lênin"},
                new Subject(){Id = 6,Code = "KTML", Name = "Kinh tế chính trị Mác - Lênin"},
                new Subject(){Id = 7,Code = "GDQP", Name = "Giáo dục quốc phòng - an ninh"},
                new Subject(){Id = 8,Code = "GDTC", Name = "Giáo dục thể chất"},
                new Subject(){Id = 9,Code = "KNM", Name = "Kỹ năng mềm"},
                new Subject(){Id = 10,Code = "TACB", Name = "Tiếng Anh cơ bản"},
                new Subject(){Id = 11,Code = "LLCT", Name = "Lý luận chính trị"},
                new Subject(){Id = 12,Code = "VHDG", Name = "Văn hóa đại cương"},
                new Subject(){Id = 13,Code = "TDK", Name = "Tư duy khoa học"},
                new Subject(){Id = 14,Code = "CSDLTG", Name = "Cấu trúc dữ liệu và giải thuật"},
                new Subject(){Id = 15,Code = "HOC", Name = "Học máy"},
                new Subject(){Id = 16,Code = "KHMT", Name = "Kỹ thuật lập trình"},
                new Subject(){Id = 17,Code = "CS", Name = "Cơ sở dữ liệu"},
                new Subject(){Id = 18,Code = "TNSP", Name = "Tin học và hệ thống phần mềm"},
                new Subject(){Id = 19,Code = "HTH", Name = "Hệ thống thông tin"},
                new Subject(){Id = 20,Code = "ATTT", Name = "An toàn thông tin"},
                new Subject(){Id = 21,Code = "MTT", Name = "Mạng máy tính"},
                new Subject(){Id = 22,Code = "PTUD", Name = "Phát triển ứng dụng di động"},
                new Subject(){Id = 23,Code = "CC", Name = "Công cụ lập trình"},
                new Subject(){Id = 24, Code = "QLDJPM", Name = "Quản lý dự án phần mềm"},
                new Subject(){Id = 25, Code = "KTPM", Name = "Kiểm thử phần mềm"}, // Môn học bổ sung
                new Subject(){Id = 26, Code = "LTPM", Name = "Lập trình mạng"}, // Môn học bổ sung
                new Subject(){Id = 27, Code = "LPCT", Name = "Lập trình C++"}, // Môn học bổ sung
                new Subject(){Id = 28, Code = "LTPY", Name = "Lập trình Python"}, // Môn học bổ sung
                new Subject(){Id = 29, Code = "HTD", Name = "Hệ thống điều khiển"},
                new Subject(){Id = 30, Code = "TDTH", Name = "Thiết kế hệ thống điện tự động"},
                new Subject(){Id = 31, Code = "DTHD", Name = "Điện tử công nghiệp"},
                new Subject(){Id = 32, Code = "HTDC", Name = "Hệ thống điện công nghiệp"},
                new Subject(){Id = 33, Code = "TDCN", Name = "Thiết kế điện công nghiệp"},
                new Subject(){Id = 34, Code = "CVDH", Name = "Cấu trúc và vận hành của mạng điện"},
                new Subject(){Id = 35, Code = "QLNGE", Name = "Quản lý năng lượng và hiệu suất"},
                new Subject(){Id = 36, Code = "KTDCD", Name = "Kỹ thuật điều khiển điện"},
                new Subject(){Id = 37, Code = "CHVL", Name = "Cơ học vật liệu"},
                new Subject(){Id = 38, Code = "PAUBD", Name = "Phân tích ứng suất và biến dạng"},
                new Subject(){Id = 39, Code = "TKKC", Name = "Tính toán kết cấu"},
                new Subject(){Id = 40, Code = "CHVR", Name = "Cơ học vật rắn"},
                new Subject(){Id = 41, Code = "CHPH", Name = "Cơ học phá hủy"},
                new Subject(){Id = 42, Code = "CHCL", Name = "Cơ học chất lưu"},
                new Subject(){Id = 43, Code = "DLDVT", Name = "Động lực học của vật thể"},
                new Subject(){Id = 44, Code = "KTKDH", Name = "Kỹ thuật khí động học"},
                 new Subject(){Id = 45, Code = "KCBTCT", Name = "Kết cấu bê tông cốt thép"},
                new Subject(){Id = 46, Code = "KTTK", Name = "Kỹ thuật thi công"},
                new Subject(){Id = 47, Code = "QLDX", Name = "Quản lý dự án xây dựng"},
                new Subject(){Id = 48, Code = "KTVTXD", Name = "Kỹ thuật vật liệu xây dựng"},
                new Subject(){Id = 49, Code = "KHVL", Name = "Khoa học vật liệu"},
    new Subject(){Id = 50, Code = "KTVLCT", Name = "Kỹ thuật vật liệu composite"},
    new Subject(){Id = 51, Code = "VTXD", Name = "Vật liệu xây dựng"},
    new Subject(){Id = 52, Code = "CTXLVL", Name = "Công nghệ xử lý vật liệu"}
                        };
            modelBuilder.Entity<Subject>().HasData(subjects);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Majors)
                .WithMany(x => x.Subjects)
                .UsingEntity(x => x.HasData(
                            new { MajorsId = 1, SubjectsId = 1 },  // Toán cao cấp
                           new { MajorsId = 1, SubjectsId = 2 },  // Vật lý đại cương
                           new { MajorsId = 1, SubjectsId = 3 },  // Lập trình hướng đối tượng
                           new { MajorsId = 1, SubjectsId = 4 },  // Hóa học đại cương
                           new { MajorsId = 1, SubjectsId = 5 },  // Triết học Mác - Lênin
                           new { MajorsId = 1, SubjectsId = 6 },  // Kinh tế chính trị Mác - Lênin
                           new { MajorsId = 1, SubjectsId = 7 },  // Giáo dục quốc phòng - an ninh
                           new { MajorsId = 1, SubjectsId = 8 },  // Giáo dục thể chất
                           new { MajorsId = 1, SubjectsId = 9 },  // Kỹ năng mềm
                           new { MajorsId = 1, SubjectsId = 10 }, // Tiếng Anh cơ bản
                           new { MajorsId = 1, SubjectsId = 11 }, // Lý luận chính trị
                           new { MajorsId = 1, SubjectsId = 12 }, // Văn hóa đại cương
                           new { MajorsId = 1, SubjectsId = 13 }, // Tư duy khoa học
                           new { MajorsId = 1, SubjectsId = 14 }, // Cấu trúc dữ liệu và giải thuật
                           new { MajorsId = 1, SubjectsId = 15 }, // Học máy
                           new { MajorsId = 1, SubjectsId = 16 }, // Kỹ thuật lập trình
                           new { MajorsId = 1, SubjectsId = 17 }, // Cơ sở dữ liệu
                           new { MajorsId = 1, SubjectsId = 18 }, // Tin học và hệ thống phần mềm
                           new { MajorsId = 1, SubjectsId = 19 }, // Hệ thống thông tin
                           new { MajorsId = 1, SubjectsId = 20 }, // An toàn thông tin
                           new { MajorsId = 1, SubjectsId = 21 }, // Mạng máy tính
                           new { MajorsId = 1, SubjectsId = 22 }, // Phát triển ứng dụng di động
                           new { MajorsId = 1, SubjectsId = 23 },  // Công cụ lập trình

                           new { MajorsId = 2, SubjectsId = 1 },  // Toán cao cấp
                           new { MajorsId = 2, SubjectsId = 2 },  // Vật lý đại cương
                           new { MajorsId = 2, SubjectsId = 3 },  // Lập trình hướng đối tượng
                           new { MajorsId = 2, SubjectsId = 4 },  // Hóa học đại cương
                           new { MajorsId = 2, SubjectsId = 5 },  // Triết học Mác - Lênin
                           new { MajorsId = 2, SubjectsId = 6 },  // Kinh tế chính trị Mác - Lênin
                           new { MajorsId = 2, SubjectsId = 7 },  // Giáo dục quốc phòng - an ninh
                           new { MajorsId = 2, SubjectsId = 8 },  // Giáo dục thể chất
                           new { MajorsId = 2, SubjectsId = 9 },  // Kỹ năng mềm
                           new { MajorsId = 2, SubjectsId = 10 }, // Tiếng Anh cơ bản
                           new { MajorsId = 2, SubjectsId = 11 }, // Lý luận chính trị
                           new { MajorsId = 2, SubjectsId = 12 }, // Văn hóa đại cương
                           new { MajorsId = 2, SubjectsId = 13 }, // Tư duy khoa học
                           new { MajorsId = 2, SubjectsId = 14 }, // Cấu trúc dữ liệu và giải thuật
                           new { MajorsId = 2, SubjectsId = 15 }, // Học máy
                           new { MajorsId = 2, SubjectsId = 16 }, // Kỹ thuật lập trình
                           new { MajorsId = 2, SubjectsId = 17 }, // Cơ sở dữ liệu
                           new { MajorsId = 2, SubjectsId = 18 }, // Tin học và hệ thống phần mềm
                           new { MajorsId = 2, SubjectsId = 19 }, // Hệ thống thông tin
                           new { MajorsId = 2, SubjectsId = 20 }, // An toàn thông tin
                           new { MajorsId = 2, SubjectsId = 21 }, // Mạng máy tính
                           new { MajorsId = 2, SubjectsId = 22 }, // Phát triển ứng dụng di động
                           new { MajorsId = 2, SubjectsId = 23 }, // Công cụ lập trình
                           new { MajorsId = 2, SubjectsId = 24 }, // Quản lý dự án phần mềm
                           new { MajorsId = 2, SubjectsId = 25 }, // Kiểm thử phần mềm
                           new { MajorsId = 2, SubjectsId = 26 }, // Lập trình mạng
                           new { MajorsId = 2, SubjectsId = 27 }, // Lập trình C++
                           new { MajorsId = 2, SubjectsId = 28 },  // Lập trình Python

                            new { MajorsId = 3, SubjectsId = 1 },  // Toán cao cấp
                            new { MajorsId = 3, SubjectsId = 2 },  // Vật lý đại cương
                            new { MajorsId = 3, SubjectsId = 3 },  // Lập trình hướng đối tượng
                            new { MajorsId = 3, SubjectsId = 4 },  // Hóa học đại cương
                            new { MajorsId = 3, SubjectsId = 5 },  // Triết học Mác - Lênin
                            new { MajorsId = 3, SubjectsId = 6 },  // Kinh tế chính trị Mác - Lênin
                            new { MajorsId = 3, SubjectsId = 7 },  // Giáo dục quốc phòng - an ninh
                            new { MajorsId = 3, SubjectsId = 29 },  // Hệ thống điều khiển
                            new { MajorsId = 3, SubjectsId = 30 },  // Thiết kế hệ thống điện tự động
                            new { MajorsId = 3, SubjectsId = 31 },   // Điện tử công nghiệp

                            new { MajorsId = 4, SubjectsId = 1 },  // Toán cao cấp
                            new { MajorsId = 4, SubjectsId = 2 },  // Vật lý đại cương
                            new { MajorsId = 4, SubjectsId = 3 },  // Lập trình hướng đối tượng
                            new { MajorsId = 4, SubjectsId = 4 },  // Hóa học đại cương
                            new { MajorsId = 4, SubjectsId = 5 },  // Triết học Mác - Lênin
                            new { MajorsId = 4, SubjectsId = 6 },  // Kinh tế chính trị Mác - Lênin
                            new { MajorsId = 4, SubjectsId = 32 }, // Hệ thống điện công nghiệp
                            new { MajorsId = 4, SubjectsId = 33 }, // Thiết kế điện công nghiệp
                            new { MajorsId = 4, SubjectsId = 34 }, // Cấu trúc và vận hành của mạng điện
                            new { MajorsId = 4, SubjectsId = 35 }, // Quản lý năng lượng và hiệu suất
                            new { MajorsId = 4, SubjectsId = 36 },  // Kỹ thuật điều khiển điện

                            new { MajorsId = 5, SubjectsId = 1 },  // Toán cao cấp
                            new { MajorsId = 5, SubjectsId = 2 },  // Vật lý đại cương
                            new { MajorsId = 5, SubjectsId = 3 },  // Lập trình hướng đối tượng
                            new { MajorsId = 5, SubjectsId = 4 },  // Hóa học đại cương
                            new { MajorsId = 5, SubjectsId = 37 }, // Cơ học vật liệu
                            new { MajorsId = 5, SubjectsId = 38 }, // Phân tích ứng suất và biến dạng
                            new { MajorsId = 5, SubjectsId = 39 }, // Tính toán kết cấu
                            new { MajorsId = 5, SubjectsId = 40 }, // Cơ học vật rắn
                            new { MajorsId = 5, SubjectsId = 41 },  // Cơ học phá hủy

                            new { MajorsId = 6, SubjectsId = 9 },  // Toán cao cấp
                            new { MajorsId = 6, SubjectsId = 8 },  // Vật lý đại cương
                            new { MajorsId = 6, SubjectsId = 7 },  // Lập trình hướng đối tượng
                            new { MajorsId = 6, SubjectsId = 4 },  // Hóa học đại cương
                            new { MajorsId = 6, SubjectsId = 5 },  // Triết học Mác - Lênin
                            new { MajorsId = 6, SubjectsId = 6 },  // Kinh tế chính trị Mác - Lênin
                            new { MajorsId = 6, SubjectsId = 42 }, // Cơ học chất lưu
                            new { MajorsId = 6, SubjectsId = 43 }, // Động lực học của vật thể
                            new { MajorsId = 6, SubjectsId = 44 },  // Kỹ thuật khí động học

                             new { MajorsId = 7, SubjectsId = 1 },  // Toán cao cấp
                            new { MajorsId = 7, SubjectsId = 2 },  // Vật lý đại cương
                            new { MajorsId = 7, SubjectsId = 3 },  // Lập trình hướng đối tượng
                            new { MajorsId = 7, SubjectsId = 4 },  // Hóa học đại cương
                            new { MajorsId = 7, SubjectsId = 45 }, // Kết cấu bê tông cốt thép
                            new { MajorsId = 7, SubjectsId = 46 }, // Kỹ thuật thi công
                            new { MajorsId = 7, SubjectsId = 47 }, // Quản lý dự án xây dựng
                            new { MajorsId = 7, SubjectsId = 48 },  // Kỹ thuật vật liệu xây dựng

                            new { MajorsId = 8, SubjectsId = 1 },  // Toán cao cấp
                            new { MajorsId = 8, SubjectsId = 2 },  // Vật lý đại cương
                            new { MajorsId = 8, SubjectsId = 3 },  // Lập trình hướng đối tượng
                            new { MajorsId = 8, SubjectsId = 48 }, // Khoa học vật liệu
                            new { MajorsId = 8, SubjectsId = 49 }, // Khoa học vật liệu
                            new { MajorsId = 8, SubjectsId = 50 }, // Kỹ thuật vật liệu composite
                            new { MajorsId = 8, SubjectsId = 51 }, // Vật liệu xây dựng
                            new { MajorsId = 8, SubjectsId = 52 }  // Công nghệ xử lý vật liệu
                    ));

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
                    new { RoleGroupsId = 3, RolesId = 3 },
                    new { RoleGroupsId = 4, RolesId = 2 }
                ));

           
        }
    }
}
