namespace FoodDiary.WebAPI.Models;

public class DailyRationResponse
{
    public Guid Id { get; set; }
     public Guid UserId { get; set; }
    public DateTime Date { get; set; }
}