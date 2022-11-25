namespace FoodDiary.WebAPI.Models;

public class ProductPreviewResponse
{
   public Guid Id { get; set; }
    public string ProductName { get; set; }
    public int CaloricContent { get; set; }
}