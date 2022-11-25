using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IExerciseService
{
    ExerciseModel GetExercise(Guid id);

    void DeleteExercise(Guid id);

    ExerciseModel AddExercise(ExerciseModel exercise);

    PageModel<ExercisePreviewModel> GetExercises(int limit = 20, int offsert = 0);
}