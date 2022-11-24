using FoodDiary.Services.Abstract;
using FoodDiary.Services.Implementation;
using FoodDiary.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDiary.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
    }
}