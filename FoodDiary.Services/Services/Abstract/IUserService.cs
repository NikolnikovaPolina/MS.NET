
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IUserService
{
    UserModel GetUser(Guid id);

    UserModel UpdateUser(Guid id, UpdateUserModel user);

    void DeleteUser(Guid id);

    PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0);
}