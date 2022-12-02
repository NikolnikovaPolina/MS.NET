using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IExerciseService
{
    ExerciseModel GetExercise(Guid id);

    ExerciseModel UpdateExercise(Guid id, UpdateExerciseModel exercise);

    void DeleteExercise(Guid id);

    CreateExerciseModel AddExercise(ExerciseModel exercise);

    PageModel<ExercisePreviewModel> GetExercises(int limit = 20, int offsert = 0);
}