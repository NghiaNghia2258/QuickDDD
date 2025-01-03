﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.DAL;

#nullable disable

namespace WebApi.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("WebApi.Domain.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A quiz on basic mathematics",
                            Duration = 30,
                            SubjectId = 1,
                            Title = "Basic Math",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Basic physics quiz",
                            Duration = 45,
                            SubjectId = 2,
                            Title = "Physics Basics",
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "A quiz on World War II",
                            Duration = 60,
                            SubjectId = 3,
                            Title = "World War II",
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Name = "CREATE_QUIZ",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "DELETE_QUIZ",
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "UPDATE_QUIZ",
                            Version = 0
                        },
                        new
                        {
                            Id = 4,
                            Name = "SELECT_QUIZ",
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Name = "Admin",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            Version = 0
                        });
                });

            modelBuilder.Entity("WebApi.Domain.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Math related quizzes",
                            Name = "Mathematics",
                            Version = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Science related quizzes",
                            Name = "Science",
                            Version = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "History related quizzes",
                            Name = "History",
                            Version = 0
                        });
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

            modelBuilder.Entity("WebApi.Domain.Models.Answer", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Question", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Quiz", b =>
                {
                    b.HasOne("WebApi.Domain.Models.Subject", "Subject")
                        .WithMany("Quizzes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
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

            modelBuilder.Entity("WebApi.Domain.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("WebApi.Domain.Models.RoleGroup", b =>
                {
                    b.Navigation("UserLogins");
                });

            modelBuilder.Entity("WebApi.Domain.Models.Subject", b =>
                {
                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
