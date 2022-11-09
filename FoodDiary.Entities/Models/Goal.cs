namespace FoodDiary.Entities.Models;

public class Goal : BaseEntity
{
    public string NameOfTheGoal { get; set; }
    public string DescriptionOfTheGoal { get; set; }
    public string Program { get; set; }
    public Guid UserId { get; set; }
    public DateTime EndDate { get; set; }
    public float DesiresWeight { get; set; }
    public int NumberOfCaloriesConsumed { get; set; }
    public float AmountOfFatConsumed { get; set; }
    public float AmountOfCarbohydratesConsumed { get; set; }
    public float AmountOfProteinConsumed { get; set; }
    public virtual User User { get; set; }
}