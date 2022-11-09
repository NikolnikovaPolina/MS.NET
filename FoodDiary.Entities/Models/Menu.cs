namespace FoodDiary.Entities.Models;

public class Menu : BaseEntity
{
    public float ProductWeight { get; set; }
    public Guid DailyRationId { get; set; }
    public Guid ProductId { get; set; }
    public virtual DailyRation DailyRation { get; set; }
    public virtual Product Product { get; set; }
}