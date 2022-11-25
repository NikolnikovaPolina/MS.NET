using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class ExercisePreviewModel
{
    public Guid Id { get; set; }
    public string NameOfTheExercise { get; set; }
    public string DescriptionOfTheExercise { get; set; }
    public int NumberofCaloriesBurned { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
}