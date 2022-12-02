using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IWorkoutService
{
    WorkoutModel GetWorkout(Guid id);

    WorkoutModel UpdateWorkout(Guid id, UpdateWorkoutModel workout);

    void DeleteWorkout(Guid id);

    CreateWorkoutModel AddWorkout(Guid UserId, WorkoutModel workoutModel);

    PageModel<WorkoutPreviewModel> GetWorkouts(int limit = 20, int offsert = 0);
}