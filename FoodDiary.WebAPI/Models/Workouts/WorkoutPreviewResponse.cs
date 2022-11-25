using FoodDiary.Entities.Models;

namespace FoodDiary.WebAPI.Models;

public class WorkoutPreviewResponse
{
    public Guid Id { get; set; }
     public string TrainingName { get; set; }
    public DateTime DataOfTheTraining { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string TrainingDescription { get; set; }
}