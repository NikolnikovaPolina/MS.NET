namespace FoodDiary.Services.Models;

public  class CreateListOfExercisesModel : BaseModel
{
    public Guid ExerciseId { get; set; }
    public Guid WorkoutId { get; set; }
    public DateTime Duration { get; set; }
}