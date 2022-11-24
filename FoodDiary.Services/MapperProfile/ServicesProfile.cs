using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();

        #endregion
    }
}