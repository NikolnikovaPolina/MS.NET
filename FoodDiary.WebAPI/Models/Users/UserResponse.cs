using FoodDiary.Entities.Models;

namespace FoodDiary.WebAPI.Models;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FIO { get; set; }
    public DateTime DataOfBirth { get; set; }
    public Gender Gender { get; set; } 
    public float Weight { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
}