using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class UserPreviewModel
{
    public Guid Id { get; set; }
    public string FIO { get; set; }
    public string Email { get; set; }
}