namespace FoodDiary.Services.Models;

public class CreateDailyRationModel : BaseModel
{
     public Guid UserId { get; set; }
    public DateTime Date { get; set; }
}