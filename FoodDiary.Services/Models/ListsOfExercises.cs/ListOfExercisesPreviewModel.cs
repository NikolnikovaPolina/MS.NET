namespace FoodDiary.Services.Models;

public class ListOfExercisesPreviewModel
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public Guid WorkoutId { get; set; }
    public DateTime Duration { get; set; }
}