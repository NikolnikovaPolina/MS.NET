namespace FoodDiary.Entities.Models;

public class Goal : BaseEntity
{
    public string NameOfTheGoal { get; set; }
    public string DescriptionOfTheGoal { get; set; }
    public string Program { get; set; }
    public Guid UserId { get; set; }
    public float DesiresWeight { get; set; }
    public virtual User User { get; set; }
}