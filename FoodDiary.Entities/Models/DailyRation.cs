namespace FoodDiary.Entities.Models;

public class DailyRation : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Menu> Menus { get; set; } 
}