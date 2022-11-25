using FoodDiary.Entities.Models;

namespace FoodDiary.WebAPI.Models;

public class WorkoutResponse
{
   public Guid Id { get; set; }
     public string TrainingName { get; set; }
    public Guid UserId { get; set; }
    public DateTime DataOfTheTraining { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string TrainingDescription { get; set; }
}