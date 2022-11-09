namespace FoodDiary.Entities.Models;

public class Workout : BaseEntity
{
    public string TrainingName { get; set; }
    public Guid UserId { get; set; }
    public DateTime DataOfTheTraining { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string TrainingDescription { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ListOfExercises> ListsOfExercises { get; set; }
}