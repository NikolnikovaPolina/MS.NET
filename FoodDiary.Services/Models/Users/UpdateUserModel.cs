using FoodDiary.Entities.Models; 

namespace FoodDiary.Services.Models;

public class UpdateUserModel
{
    public string FIO { get; set; }
    public float Weight { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
}