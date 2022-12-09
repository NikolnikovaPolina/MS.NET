using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class LoginUserModel
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}