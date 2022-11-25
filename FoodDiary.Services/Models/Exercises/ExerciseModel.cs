using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class ExerciseModel : BaseModel
{
    public string NameOfTheExercise { get; set; }
    public string DescriptionOfTheExercise { get; set; }
    public int NumberofCaloriesBurned { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
}