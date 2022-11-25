using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class MenuService : IMenuService
{
    private readonly IRepository<Menu> menusRepository;
    private readonly IMapper mapper;
    public MenuService(IRepository<Menu> menusRepository, IMapper mapper)
    {
        this.menusRepository = menusRepository;
        this.mapper = mapper;
    }

    public void DeleteMenu(Guid id)
    {
        var menuToDelete = menusRepository.GetById(id);
        if (menuToDelete == null)
        {
            throw new Exception("Menu not found");
        }

        menusRepository.Delete(menuToDelete);
    }

    public MenuModel GetMenu(Guid id)
    {
        var menu = menusRepository.GetById(id);
        return mapper.Map<MenuModel>(menu);
    }

    public PageModel<MenuPreviewModel> GetMenus(int limit = 20, int offset = 0)
    {
        var menus = menusRepository.GetAll();
        int totalCount = menus.Count();
        var chunk = menus.OrderBy(x => x.DailyRation).Skip(offset).Take(limit);

        return new PageModel<MenuPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<MenuPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public MenuModel UpdateMenu(Guid id, UpdateMenuModel menu)
    {
        var existingMenu = menusRepository.GetById(id);
        if (existingMenu == null)
        {
            throw new Exception("Menu not found");
        }

        existingMenu.DailyRationId = menu.DailyRationId;
        existingMenu.ProductWeight = menu.ProductWeight;
        existingMenu.ProductId = menu.ProductId;

        existingMenu = menusRepository.Save(existingMenu);
        return mapper.Map<MenuModel>(existingMenu);
    }

     public MenuModel AddMenu(MenuModel menuModel){
      menusRepository.Save(mapper.Map<Entities.Models.Menu>(menuModel));
        return menuModel;
    }
}