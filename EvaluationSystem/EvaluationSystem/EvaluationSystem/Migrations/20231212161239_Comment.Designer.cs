﻿// <auto-generated />
using System;
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
    [Migration("20231212161239_Comment")]
    partial class Comment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EvaluationSystem.Models.CommentEval", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<int>("CommentedById")
                        .HasColumnType("int");

                    b.Property<string>("EvaluationComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvaluationId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("EvaluationId");

                    b.ToTable("CommentEval");
                });

            modelBuilder.Entity("EvaluationSystem.Models.Evaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationId"), 1L, 1);

                    b.Property<int>("GradingPeriodId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EvaluationId");

                    b.HasIndex("GradingPeriodId");

                    b.HasIndex("TermId");

                    b.HasIndex("UserId");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("EvaluationSystem.Models.EvaluationCategory", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationId"), 1L, 1);

                    b.Property<string>("EvaluationCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvaluationId");

                    b.ToTable("EvaluationCategory");
                });

            modelBuilder.Entity("EvaluationSystem.Models.EvaluationDetails", b =>
                {
                    b.Property<int>("EvaluationDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationDetailsId"), 1L, 1);

                    b.Property<int?>("CommentEvalId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluationCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluationRatingId")
                        .HasColumnType("int");

                    b.HasKey("EvaluationDetailsId");

                    b.HasIndex("CommentEvalId");

                    b.HasIndex("EvaluationCategoryId");

                    b.HasIndex("EvaluationRatingId");

                    b.ToTable("EvaluationDetails");
                });

            modelBuilder.Entity("EvaluationSystem.Models.EvaluationRating", b =>
                {
                    b.Property<int>("EvaluationRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationRatingId"), 1L, 1);

                    b.Property<string>("EvaluationRatingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvaluationScore")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("EvaluationRatingId");

                    b.ToTable("EvaluationRating");
                });

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

            modelBuilder.Entity("EvaluationSystem.Models.CommentEval", b =>
                {
                    b.HasOne("EvaluationSystem.Models.Evaluation", "Evaluation")
                        .WithMany()
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluation");
                });

            modelBuilder.Entity("EvaluationSystem.Models.Evaluation", b =>
                {
                    b.HasOne("EvaluationSystem.Models.GradingPeriod", "GradingPeriod")
                        .WithMany()
                        .HasForeignKey("GradingPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluationSystem.Models.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluationSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GradingPeriod");

                    b.Navigation("Term");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EvaluationSystem.Models.EvaluationDetails", b =>
                {
                    b.HasOne("EvaluationSystem.Models.CommentEval", "CommentEval")
                        .WithMany()
                        .HasForeignKey("CommentEvalId");

                    b.HasOne("EvaluationSystem.Models.EvaluationCategory", "EvaluationCategory")
                        .WithMany()
                        .HasForeignKey("EvaluationCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvaluationSystem.Models.EvaluationRating", "EvaluationRating")
                        .WithMany()
                        .HasForeignKey("EvaluationRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentEval");

                    b.Navigation("EvaluationCategory");

                    b.Navigation("EvaluationRating");
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
