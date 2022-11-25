namespace FoodDiary.WebAPI.Models;

public class MenuResponse
{
    public Guid Id { get; set; }
    public float ProductWeight { get; set; }
    public Guid DailyRationId { get; set; }
    public Guid ProductId { get; set; }
}