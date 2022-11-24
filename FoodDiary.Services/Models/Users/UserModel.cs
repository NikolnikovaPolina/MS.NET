using FoodDiary.Entities.Models;

namespace FoodDiary.Services.Models;

public class UserModel : BaseModel
{
   public string FIO { get; set; }
    public string Nik { get; set; }
    public string Email { get; set; }
}