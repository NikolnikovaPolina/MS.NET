namespace FoodDiary.Services.Models;

public class DailyRationModel : BaseModel
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
}