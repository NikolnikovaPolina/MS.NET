namespace FoodDiary.WebAPI.Models;

public class ProductResponse
{
   public Guid Id { get; set; }
    public string ProductName { get; set; }
    public int CaloricContent { get; set; }
}