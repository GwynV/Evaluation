﻿// <auto-generated />
using EvaluationSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvaluationSystem.Migrations
{
    [DbContext(typeof(EvaluationSystemContext))]
    [Migration("20231212020216_GradingPeriod")]
    partial class GradingPeriod
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EvaluationSystem.Models.GradingPeriod", b =>
                {
                    b.Property<int>("GradingPeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradingPeriodId"), 1L, 1);

                    b.Property<string>("GradingPeriodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradingPeriodId");

                    b.ToTable("GradingPeriod");
                });

            modelBuilder.Entity("EvaluationSystem.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"), 1L, 1);

                    b.Property<string>("PositionCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("EvaluationSystem.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("StaffId");

                    b.HasIndex("PositionId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("EvaluationSystem.Models.Term", b =>
                {
                    b.Property<int>("TermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TermId"), 1L, 1);

                    b.Property<string>("TermName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TermId");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("EvaluationSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EvaluationSystem.Models.Staff", b =>
                {
                    b.HasOne("EvaluationSystem.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
