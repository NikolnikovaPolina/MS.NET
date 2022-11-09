namespace FoodDiary.Entities.Models;

public class Product : BaseEntity
{
    public string ProductName { get; set; }
    public int CaloricContent { get; set; }
    public virtual ICollection<Menu> Menus { get; set; }
}