﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ItProjectManagementApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231208152610_migration3")]
    partial class migration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserStoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserStoryId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.TaskDependency", b =>
                {
                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("DependentOnId")
                        .HasColumnType("int");

                    b.HasKey("TaskId", "DependentOnId");

                    b.HasIndex("DependentOnId");

                    b.ToTable("TaskDependencies");
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.HasOne("Domain.Entities.Team", "Team")
                        .WithOne("Project")
                        .HasForeignKey("Domain.Entities.Project", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Domain.Entities.Task", b =>
                {
                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Domain.Entities.Task", "UserStory")
                        .WithMany("SubTasks")
                        .HasForeignKey("UserStoryId");

                    b.Navigation("Project");

                    b.Navigation("User");

                    b.Navigation("UserStory");
                });

            modelBuilder.Entity("Domain.Entities.TaskDependency", b =>
                {
                    b.HasOne("Domain.Entities.Task", "DependentOn")
                        .WithMany()
                        .HasForeignKey("DependentOnId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Task", "Task")
                        .WithMany("Dependencies")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DependentOn");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.Entities.Task", b =>
                {
                    b.Navigation("Dependencies");

                    b.Navigation("SubTasks");
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.Navigation("Project")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
