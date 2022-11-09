using Microsoft.EntityFrameworkCore;
using FoodDiary.Entities.Models;

namespace FoodDiary.Entities;
public class Context : DbContext
{    
    public DbSet<DailyRation> DailyRations { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Goal>Goals { get; set; }
    public DbSet<ListOfExercises> ListsOfExercises { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region DailyRations

        builder.Entity<DailyRation>().ToTable("dailyRations");
        builder.Entity<DailyRation>().HasKey(x => x.Id);

        #endregion

        #region Exercises

        builder.Entity<Exercise>().ToTable("exercises");
        builder.Entity<Exercise>().HasKey(x => x.Id);

        #endregion

        #region Goals

        builder.Entity<Goal>().ToTable("goals");
        builder.Entity<Goal>().HasKey(x => x.Id);

        #endregion

        #region ListsOfExercises

        builder.Entity<ListOfExercises>().ToTable("listsOfExercises");
        builder.Entity<ListOfExercises>().HasKey(x => x.Id);
        builder.Entity<ListOfExercises>().HasOne(x => x.Workout)
                                .WithMany(x => x.ListsOfExercises)
                                .HasForeignKey(x => x.WorkoutId)
                                .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<ListOfExercises>().HasOne(x => x.Exercise)
                                .WithMany(x => x.ListsOfExercises)
                                .HasForeignKey(x => x.ExerciseId)
                                .OnDelete(DeleteBehavior.Cascade);                                

        #endregion

        #region Menus

        builder.Entity<Menu>().ToTable("menus");
        builder.Entity<Menu>().HasKey(x => x.Id);
        builder.Entity<Menu>().HasOne(x => x.DailyRation)
                            .WithMany(x => x.Menus)
                            .HasForeignKey(x => x.DailyRationId)
                            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Menu>().HasOne(x => x.Product)
                            .WithMany(x => x.Menus)
                            .HasForeignKey(x => x.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);                            

        #endregion

        #region Products

        builder.Entity<Product>().ToTable("products");
        builder.Entity<Product>().HasKey(x => x.Id);

        #endregion

        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasOne(x => x.Goal)
                            .WithOne(x => x.User)
                            .HasForeignKey<Goal>(x => x.UserId);
        builder.Entity<User>().HasOne(x => x.DailyRation)
                            .WithOne(x => x.User)
                            .HasForeignKey<DailyRation>(x => x.UserId); 
        builder.Entity<User>().HasOne(x => x.Workout)
                            .WithOne(x => x.User)
                            .HasForeignKey<Workout>(x => x.UserId);                            


        #endregion

        #region Workouts

        builder.Entity<Workout>().ToTable("workouts");
        builder.Entity<Workout>().HasKey(x => x.Id);

        #endregion
   }
}