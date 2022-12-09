using Microsoft.AspNetCore.Identity;

namespace FoodDiary.Entities.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string FIO { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime DataOfBirth { get; set; }
    public Gender Gender { get; set; } 
    public float Weight { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public virtual Workout Workout { get; set; }
    public virtual DailyRation DailyRation { get; set; }
    public virtual Goal Goal { get; set; }

    #region BaseEntity

    public DateTime CreatedTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreatedTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }
    
    #endregion
}

public class UserRole : IdentityRole<Guid>
{ }