using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IDailyRationService
{
    DailyRationModel GetDailyRation(Guid id);

    DailyRationModel UpdateDailyRation(Guid id, UpdateDailyRationModel dailyRation);

    void DeleteDailyRation(Guid id);

    CreateDailyRationModel AddDailyRation(Guid UserId, DailyRationModel dailyRation);

    PageModel<DailyRationPreviewModel> GetDailyRations(int limit = 20, int offsert = 0);
}