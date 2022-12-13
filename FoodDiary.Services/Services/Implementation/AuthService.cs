using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using FoodDiary.Services.Abstract;
using FoodDiary.Shared.Exceptions;
using FoodDiary.Shared.ResultCodes;

namespace FoodDiary.Services.Implementation;

public class AuthService : IAuthService
{
    #region Fields
    private readonly IRepository<User> usersRepository;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IMapper mapper;
    private readonly string identityUri;

    #endregion
    public AuthService(
        IRepository<User> usersRepository, UserManager<User> userManager, SignInManager<User> signInManager,
        IMapper mapper, IConfiguration configuration)
    {
        this.usersRepository = usersRepository;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
        identityUri = configuration.GetValue<string>("IdentityServer:Uri");
    }
    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        var existingUser = await userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
        {
            throw new LogicException(ResultCode.USER_ALREADY_EXISTS);
        }

        var user = new User()
        {
            Email = model.Email,
            UserName = model.Email,
            FIO = model.FIO ?? "",
            DataOfBirth = model.DataOfBirth,
            Gender = model.Gender,
            Weight = model.Weight,
            ActivityLevel = model.ActivityLevel,
            Workout = model.Workout,
            DailyRation = model.DailyRation,
            Goal = model.Goal,
            PasswordHash = model.Password,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        var createdUser = await userManager.FindByEmailAsync(model.Email);
        return mapper.Map<UserModel>(createdUser);
    }

    public async Task<IdentityModel.Client.TokenResponse> LoginUser(LoginUserModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.EMAIL_OR_PASSWORD_IS_INCORRECT);
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Email,
            Password = model.Password,
            Scope = "api"
        });

        if (tokenResponse.IsError)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        return tokenResponse;
    }
}