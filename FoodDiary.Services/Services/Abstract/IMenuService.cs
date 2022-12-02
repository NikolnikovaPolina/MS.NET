using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IMenuService
{
    MenuModel GetMenu(Guid id);

    MenuModel UpdateMenu(Guid id, UpdateMenuModel menu);

    void DeleteMenu(Guid id);

    CreateMenuModel AddMenu(Guid DailyRationId, Guid ProductId, MenuModel menu);

    PageModel<MenuPreviewModel> GetMenus(int limit = 20, int offsert = 0);
}