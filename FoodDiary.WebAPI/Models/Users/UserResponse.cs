namespace FoodDiary.WebAPI.Models;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FIO { get; set; }
    public string Nik { get; set; }
}