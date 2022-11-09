namespace FoodDiary.Entities.Models;

public class ListOfExercises : BaseEntity
{
    public Guid ExerciseId { get; set; }
    public Guid WorkoutId { get; set; }
    public DateTime Duration { get; set; }
    public virtual Workout Workout { get; set; }
    public virtual Exercise Exercise { get; set; }
}