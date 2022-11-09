namespace FoodDiary.Entities.Models;

public class Exercise : BaseEntity
{
    public string NameOfTheExercise { get; set; }
    public string DescriptionOfTheExercise { get; set; }
    public int NumberofCaloriesBurned { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public virtual ICollection<ListOfExercises> ListsOfExercises { get; set; }
}