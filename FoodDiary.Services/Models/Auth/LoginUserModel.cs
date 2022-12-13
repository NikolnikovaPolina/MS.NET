using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class LoginUserModel
{
  public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}