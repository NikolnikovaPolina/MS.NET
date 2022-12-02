namespace FoodDiary.Services.Models;

public class CreateMenuModel : BaseModel
{
    public float ProductWeight { get; set; }
    public Guid DailyRationId { get; set; }
    public Guid ProductId { get; set; }
}