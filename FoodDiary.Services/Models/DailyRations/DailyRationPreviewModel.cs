namespace FoodDiary.Services.Models;

public class DailyRationPreviewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
}