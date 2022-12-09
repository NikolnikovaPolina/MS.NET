namespace FoodDiary.Entities.Models;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreatedTime { get; set; }
    DateTime ModificationTime { get; set; }

    bool IsNew();
    void Init();
}