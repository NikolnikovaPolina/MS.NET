namespace FoodDiary.Services.Models;

public class ListOfExercisesModel : BaseModel
{
    public Guid ExerciseId { get; set; }
    public Guid WorkoutId { get; set; }
    public DateTime Duration { get; set; }
}