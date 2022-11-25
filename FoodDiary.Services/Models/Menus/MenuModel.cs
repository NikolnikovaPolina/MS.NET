namespace FoodDiary.Services.Models;

public class MenuModel : BaseModel
{
    public float ProductWeight { get; set; }
    public Guid DailyRationId { get; set; }
    public Guid ProductId { get; set; }
}