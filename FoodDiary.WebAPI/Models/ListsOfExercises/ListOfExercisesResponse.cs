namespace FoodDiary.WebAPI.Models;

public class ListOfExercisesResponse
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public Guid WorkoutId { get; set; }
    public DateTime Duration { get; set; }
}