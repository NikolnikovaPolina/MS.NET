namespace FoodDiary.Services.Models;

public class UpdateDailyRationModel
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
}