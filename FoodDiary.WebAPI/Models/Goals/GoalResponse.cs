namespace FoodDiary.WebAPI.Models;

public class GoalResponse
{
    public Guid Id { get; set; }
    public string NameOfTheGoal { get; set; }
    public string DescriptionOfTheGoal { get; set; }
    public string Program { get; set; }
    public Guid UserId { get; set; }
    public float DesiresWeight { get; set; }
}