using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class UserModel : BaseModel
{
    public string FIO { get; set; }
    public string Email { get; set; }
    public DateTime DataOfBirth { get; set; }
    public Gender Gender { get; set; } 
    public float Weight { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
}