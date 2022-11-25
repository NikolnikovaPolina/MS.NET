using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IDailyRationService
{
    DailyRationModel GetDailyRation(Guid id);

    void DeleteDailyRation(Guid id);

    DailyRationModel AddDailyRation(DailyRationModel dailyRationModel);

    PageModel<DailyRationPreviewModel> GetDailyRations(int limit = 20, int offsert = 0);
}