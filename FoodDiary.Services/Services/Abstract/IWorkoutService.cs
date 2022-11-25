using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IWorkoutService
{
    WorkoutModel GetWorkout(Guid id);

    void DeleteWorkout(Guid id);

    WorkoutModel AddWorkout(WorkoutModel workoutModel);

    PageModel<WorkoutPreviewModel> GetWorkouts(int limit = 20, int offsert = 0);
}