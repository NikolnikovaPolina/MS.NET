namespace FoodDiary.Services.Models;

public class MenuPreviewModel
{
    public Guid Id { get; set; }
    public float ProductWeight { get; set; }
    public Guid DailyRationId { get; set; }
    public Guid ProductId { get; set; }
}