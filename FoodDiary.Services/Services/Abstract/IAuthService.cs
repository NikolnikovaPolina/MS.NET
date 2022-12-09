using FoodDiary.Services.Models;
using IdentityModel.Client;

namespace FoodDiary.Services.Abstract;

public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);   
}