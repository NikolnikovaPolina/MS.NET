using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IListOfExercisesService
{
    ListOfExercisesModel GetListOfExercises(Guid id);

    ListOfExercisesModel UpdateListOfExercises(Guid id, UpdateListOfExercisesModel user);

    void DeleteListOfExercises(Guid id);

    ListOfExercisesModel AddListOfExercises(ListOfExercisesModel listOfExercisesModel);

    PageModel<ListOfExercisesPreviewModel> GetListsOfExercises(int limit = 20, int offsert = 0);
}