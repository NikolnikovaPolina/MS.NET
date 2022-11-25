namespace FoodDiary.Services.Models;

public class GoalPreviewModel
{
    public Guid Id { get; set; }
    public string NameOfTheGoal { get; set; }
    public string DescriptionOfTheGoal { get; set; }
    public string Program { get; set; }
    public float DesiresWeight { get; set; }
}