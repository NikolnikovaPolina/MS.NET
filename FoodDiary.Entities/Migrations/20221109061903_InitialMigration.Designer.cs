﻿// <auto-generated />
using System;
using FoodDiary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodDiary.Entities.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221109061903_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodDiary.Entities.Models.DailyRation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("dailyRations", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionOfTheExercise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("NameOfTheExercise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberofCaloriesBurned")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("exercises", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Goal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("AmountOfCarbohydratesConsumed")
                        .HasColumnType("real");

                    b.Property<float>("AmountOfFatConsumed")
                        .HasColumnType("real");

                    b.Property<float>("AmountOfProteinConsumed")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionOfTheGoal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DesiresWeight")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfTheGoal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCaloriesConsumed")
                        .HasColumnType("int");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("goals", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.ListOfExercises", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("listsOfExercises", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DailyRationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ProductWeight")
                        .HasColumnType("real");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DailyRationId");

                    b.HasIndex("ProductId");

                    b.ToTable("menus", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CaloricContent")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActivityLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Nik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOfTheTraining")
                        .HasColumnType("datetime2");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("TrainingDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("workouts", (string)null);
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.DailyRation", b =>
                {
                    b.HasOne("FoodDiary.Entities.Models.User", "User")
                        .WithOne("DailyRation")
                        .HasForeignKey("FoodDiary.Entities.Models.DailyRation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Goal", b =>
                {
                    b.HasOne("FoodDiary.Entities.Models.User", "User")
                        .WithOne("Goal")
                        .HasForeignKey("FoodDiary.Entities.Models.Goal", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.ListOfExercises", b =>
                {
                    b.HasOne("FoodDiary.Entities.Models.Exercise", "Exercise")
                        .WithMany("ListsOfExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDiary.Entities.Models.Workout", "Workout")
                        .WithMany("ListsOfExercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Menu", b =>
                {
                    b.HasOne("FoodDiary.Entities.Models.DailyRation", "DailyRation")
                        .WithMany("Menus")
                        .HasForeignKey("DailyRationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodDiary.Entities.Models.Product", "Product")
                        .WithMany("Menus")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DailyRation");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Workout", b =>
                {
                    b.HasOne("FoodDiary.Entities.Models.User", "User")
                        .WithOne("Workout")
                        .HasForeignKey("FoodDiary.Entities.Models.Workout", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.DailyRation", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Exercise", b =>
                {
                    b.Navigation("ListsOfExercises");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Product", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.User", b =>
                {
                    b.Navigation("DailyRation")
                        .IsRequired();

                    b.Navigation("Goal")
                        .IsRequired();

                    b.Navigation("Workout")
                        .IsRequired();
                });

            modelBuilder.Entity("FoodDiary.Entities.Models.Workout", b =>
                {
                    b.Navigation("ListsOfExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
