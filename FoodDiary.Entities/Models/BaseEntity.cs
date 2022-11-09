namespace FoodDiary.Entities.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
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
}