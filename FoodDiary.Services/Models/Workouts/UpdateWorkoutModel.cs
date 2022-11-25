using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class UpdateWorkoutModel
{
    public string TrainingName { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string TrainingDescription { get; set; }
}