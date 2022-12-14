using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class RegisterUserModel
{
    public string FIO { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DataOfBirth { get; set; }
    public Gender Gender { get; set; } 
    public float Weight { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public virtual Workout Workout { get; set; }
    public virtual DailyRation DailyRation { get; set; }
    public virtual Goal Goal { get; set; }

}