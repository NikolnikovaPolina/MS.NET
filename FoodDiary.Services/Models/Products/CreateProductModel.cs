namespace FoodDiary.Services.Models;

public class CreateProductModel : BaseModel
{
    public string ProductName { get; set; }
    public int CaloricContent { get; set; }
}