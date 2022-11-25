using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IMenuService
{
    MenuModel GetMenu(Guid id);

    MenuModel UpdateMenu(Guid id, UpdateMenuModel user);

    void DeleteMenu(Guid id);

    MenuModel AddMenu(MenuModel menuModel);

    PageModel<MenuPreviewModel> GetMenus(int limit = 20, int offsert = 0);
}