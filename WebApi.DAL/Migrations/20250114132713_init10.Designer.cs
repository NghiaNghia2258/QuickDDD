﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.DAL;

#nullable disable

namespace WebApi.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250114132713_init10")]
    partial class init10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MajorSubject", b =>
                {
                    b.Property<int>("MajorsId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("MajorsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("MajorSubject");
                });

            modelBuilder.Entity("RoleRoleGroup", b =>
                {
                    b.Property<int>("RoleGroupsId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("RoleGroupsId", "RolesId");

                    b.HasIndex(new[] { "RolesId" }, "IX_RoleRoleGroup_RolesId");

                    b.ToTable("RoleRoleGroup", (string)null);

                    b.HasData(
                        new
                        {
                            RoleGroupsId = 1,
                            RolesId = 1
                        },
                        new
                        {
                            RoleGroupsId = 1,
                            RolesId = 2
                        },
                        new
                        {
                            RoleGroupsId = 1,
                            RolesId = 3
                        },
                        new
                        {
                            RoleGroupsId = 1,
                            RolesId = 4
                        },
                        new
                        {
                            RoleGroupsId = 2,
                            RolesId = 4
                        });
                });

            modelBuilder.Entity("SchoolClassStudent", b =>
                {
                    b.Property<int>("SchoolClassesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("SchoolClassesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("SchoolClassStudent");
                });

            modelBuilder.Entity("SchoolClassTeacher", b =>
                {
                    b.Property<int>("SchoolClassesId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("SchoolClassesId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SchoolClassTeacher", (string)null);
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "CS",
                            IsDeleted = false,
                            Name = "Công nghệ thông tin",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Code = "EE",
                            IsDeleted = false,
                            Name = "Kỹ thuật điện",
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Code = "ME",
                            IsDeleted = false,
                            Name = "Cơ khí",
                            Version = 0
                        },
                        new
                        {
                            Id = 4,
                            Code = "CE",
                            IsDeleted = false,
                            Name = "Xây dựng",
                            Version = 0
                        },
                        new
                        {
                            Id = 5,
                            Code = "AE",
                            IsDeleted = false,
                            Name = "Kỹ thuật môi trường",
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "CREATE_TEACHER",
                            Name = "CREATE_TEACHER",
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoleGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "ADMIN",
                            Name = "Admin",
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Code = "TEACHER",
                            Name = "Teacher",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Code = "USER",
                            Name = "User",
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.SchoolClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeroomTeacherId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailableSlot")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<int>("MaxStudents")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeroomTeacherId");

                    b.HasIndex("MajorId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnrollmentYear")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserLoginId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("CollectedAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId1");

                    b.ToTable("StudentFees");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentGradeId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentGradeId");

                    b.ToTable("StudentFeedback");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AttendanceGrade")
                        .HasColumnType("float");

                    b.Property<double>("ExamGrade")
                        .HasColumnType("float");

                    b.Property<double>("HomeworkGrade")
                        .HasColumnType("float");

                    b.Property<double>("PracticalGrade")
                        .HasColumnType("float");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentGrades");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExerciseCredits")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIncludedInGPA")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PracticeCredits")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("TheoryCredits")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "TCC",
                            ExerciseCredits = 0,
                            IsDeleted = false,
                            IsIncludedInGPA = false,
                            IsMandatory = false,
                            Name = "Toán cao cấp",
                            PracticeCredits = 0,
                            Semester = 0,
                            TheoryCredits = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Code = "VLDC",
                            ExerciseCredits = 0,
                            IsDeleted = false,
                            IsIncludedInGPA = false,
                            IsMandatory = false,
                            Name = "Vật lý đại cương",
                            PracticeCredits = 0,
                            Semester = 0,
                            TheoryCredits = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Code = "OOP",
                            ExerciseCredits = 0,
                            IsDeleted = false,
                            IsIncludedInGPA = false,
                            IsMandatory = false,
                            Name = "Lập trình hướng đối tượng",
                            PracticeCredits = 0,
                            Semester = 0,
                            TheoryCredits = 0,
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDepartmentHead")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("WebApi.Domain.Models.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleGroupId" }, "IX_UserLogins_RoleGroupId");

                    b.ToTable("UserLogins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Password = "admin123",
                            RoleGroupId = 1,
                            Username = "admin",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Password = "user123",
                            RoleGroupId = 2,
                            Username = "user1",
                            Version = 0
                        });
                });

            modelBuilder.Entity("MajorSubject", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Major", null)
                        .WithMany()
                        .HasForeignKey("MajorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleRoleGroup", b =>
                {
                    b.HasOne("WebApi.Domain.Models.RoleGroup", null)
                        .WithMany()
                        .HasForeignKey("RoleGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolClassStudent", b =>
                {
                    b.HasOne("WebApi.Domain.Models.SchoolClass", null)
                        .WithMany()
                        .HasForeignKey("SchoolClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolClassTeacher", b =>
                {
                    b.HasOne("WebApi.Domain.Models.SchoolClass", null)
                        .WithMany()
                        .HasForeignKey("SchoolClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Domain.Models.Major", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("WebApi.Domain.Models.SchoolClass", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Teacher", "HomeroomTeacher")
                        .WithMany("HomeroomClasses")
                        .HasForeignKey("HomeroomTeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Major", "Major")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeroomTeacher");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Student", b =>
                {
                    b.HasOne("WebApi.Domain.Models.UserLogin", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentFee", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Student", "Student")
                        .WithMany("StudentFees")
                        .HasForeignKey("StudentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentFeedback", b =>
                {
                    b.HasOne("WebApi.Domain.Models.StudentGrade", "StudentGrade")
                        .WithMany("StudentFeedbacks")
                        .HasForeignKey("StudentGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentGrade");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentGrade", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.Subject", "Subject")
                        .WithMany("StudentGrades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Teacher", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Faculty", "Faculty")
                        .WithMany("Teachers")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Models.UserLogin", "UserLogin")
                        .WithMany("Teachers")
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("WebApi.Domain.Models.UserLogin", b =>
                {
                    b.HasOne("WebApi.Domain.Models.RoleGroup", "RoleGroup")
                        .WithMany("UserLogins")
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleGroup");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Faculty", b =>
                {
                    b.Navigation("Majors");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Major", b =>
                {
                    b.Navigation("SchoolClasses");
                });

            modelBuilder.Entity("WebApi.Domain.Models.RoleGroup", b =>
                {
                    b.Navigation("UserLogins");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Student", b =>
                {
                    b.Navigation("StudentFees");
                });

            modelBuilder.Entity("WebApi.Domain.Models.StudentGrade", b =>
                {
                    b.Navigation("StudentFeedbacks");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Subject", b =>
                {
                    b.Navigation("StudentGrades");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Teacher", b =>
                {
                    b.Navigation("HomeroomClasses");
                });

            modelBuilder.Entity("WebApi.Domain.Models.UserLogin", b =>
                {
                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
