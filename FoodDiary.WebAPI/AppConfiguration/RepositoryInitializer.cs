using System;
using FoodDiary.Entities;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_EMAIL = "master@mail.ru";
    public const string MASTER_ADMIN_PASSWORD = "password";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new Services.Models.RegisterUserModel()
        {
            Email = MASTER_ADMIN_EMAIL,
            Password = MASTER_ADMIN_PASSWORD,
        });
    }

   public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            var usersRepository = (IRepository<User>)scope.ServiceProvider.GetRequiredService(typeof(IRepository<User>));
            var user = usersRepository.GetAll().Where(x => x.Email == MASTER_ADMIN_EMAIL).FirstOrDefault();
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}