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

        #region DailyRations

        CreateMap<DailyRation, Models.DailyRationModel>().ReverseMap();
        CreateMap<DailyRation, DailyRationPreviewModel>().ReverseMap();

        #endregion

        #region Exercises

        CreateMap<Entities.Models.Exercise, ExerciseModel>().ReverseMap();
        CreateMap<Entities.Models.Exercise, ExercisePreviewModel>().ReverseMap();

        #endregion

        #region Goals

        CreateMap<Menu, GoalModel>().ReverseMap();
        CreateMap<Menu, GoalPreviewModel>().ReverseMap();
        CreateMap<Menu, UpdateGoalModel>().ReverseMap();

        #endregion

        #region ListsOfExercises

        CreateMap<ListOfExercises, ListOfExercisesModel>().ReverseMap();
        CreateMap<ListOfExercises, ListOfExercisesPreviewModel>().ReverseMap();
        CreateMap<ListOfExercises, UpdateListOfExercisesModel>().ReverseMap();

        #endregion

        #region Menus

        CreateMap<Menu, MenuModel>().ReverseMap();
        CreateMap<Menu, MenuPreviewModel>().ReverseMap();
        CreateMap<Menu, UpdateMenuModel>().ReverseMap();

        #endregion

        #region Products

        CreateMap<Product, ProductModel>().ReverseMap();
        CreateMap<Product, ProductPreviewModel>().ReverseMap();
        CreateMap<Product, UpdateProductModel>().ReverseMap();

        #endregion

        #region Workout

        CreateMap<Workout, WorkoutModel>().ReverseMap();
        CreateMap<Workout, WorkoutPreviewModel>().ReverseMap();

        #endregion
    }
}