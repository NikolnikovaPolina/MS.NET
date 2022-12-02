namespace FoodDiary.Services.Models;

public class CreateGoalModel : BaseModel
{
    public string NameOfTheGoal { get; set; }
    public string DescriptionOfTheGoal { get; set; }
    public string Program { get; set; }
    public Guid UserId { get; set; }
    public float DesiresWeight { get; set; }
}