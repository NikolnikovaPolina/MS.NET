using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IListOfExercisesService
{
    ListOfExercisesModel GetListOfExercises(Guid id);

    ListOfExercisesModel UpdateListOfExercises(Guid id, UpdateListOfExercisesModel listOfExercises);

    void DeleteListOfExercises(Guid id);

    CreateListOfExercisesModel AddListOfExercises(Guid ExerciseId, Guid WorkoutId, ListOfExercisesModel listOfExercisesModel);

    PageModel<ListOfExercisesPreviewModel> GetListsOfExercises(int limit = 20, int offsert = 0);
}