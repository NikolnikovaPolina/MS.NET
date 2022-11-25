using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class WorkoutModel : BaseModel
{
    public string TrainingName { get; set; }
    public Guid UserId { get; set; }
    public DateTime DataOfTheTraining { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string TrainingDescription { get; set; }
}