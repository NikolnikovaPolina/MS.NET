using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class ListOfExercisesService : IListOfExercisesService
{
    private readonly IRepository<ListOfExercises> listsOfExercisesRepository;
    private readonly IMapper mapper;
    public ListOfExercisesService(IRepository<ListOfExercises> listsOfExercisesRepository, IMapper mapper)
    {
        this.listsOfExercisesRepository = listsOfExercisesRepository;
        this.mapper = mapper;
    }

    public void DeleteListOfExercises(Guid id)
    {
        var listOfExercisesToDelete = listsOfExercisesRepository.GetById(id);
        if (listOfExercisesToDelete == null)
        {
            throw new Exception("List of exercises not found");
        }

        listsOfExercisesRepository.Delete(listOfExercisesToDelete);
    }

    public ListOfExercisesModel GetListOfExercises(Guid id)
    {
        var listOfExercises = listsOfExercisesRepository.GetById(id);
        return mapper.Map<ListOfExercisesModel>(listOfExercises);
    }

    public PageModel<ListOfExercisesPreviewModel> GetListsOfExercises(int limit = 20, int offset = 0)
    {
        var listsOfExercises = listsOfExercisesRepository.GetAll();
        int totalCount = listsOfExercises.Count();
        var chunk = listsOfExercises.OrderBy(x => x.WorkoutId).Skip(offset).Take(limit);

        return new PageModel<ListOfExercisesPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ListOfExercisesPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public ListOfExercisesModel UpdateListOfExercises(Guid id, UpdateListOfExercisesModel listOfExercises)
    {
        var existingListOfExercises = listsOfExercisesRepository.GetById(id);
        if (existingListOfExercises == null)
        {
            throw new Exception("List of exercises not found");
        }

        existingListOfExercises.ExerciseId = listOfExercises.ExerciseId;
        existingListOfExercises.WorkoutId = listOfExercises.ExerciseId;
        existingListOfExercises.Duration = listOfExercises.Duration;

        existingListOfExercises = listsOfExercisesRepository.Save(existingListOfExercises);
        return mapper.Map<ListOfExercisesModel>(existingListOfExercises);
    }

     public CreateListOfExercisesModel AddListOfExercises(Guid ExerciseId, Guid WorkoutId, ListOfExercisesModel listOfExercises){

         if(listsOfExercisesRepository.GetAll(x => x.Id == listOfExercises.Id).FirstOrDefault() != null)
        {
            throw new Exception ("Attempt to create a non-unique object!");
        }

        CreateListOfExercisesModel listOfExercisesModel = new CreateListOfExercisesModel();

        listOfExercisesModel.ExerciseId = listOfExercises.ExerciseId;
        listOfExercisesModel.WorkoutId = listOfExercises.WorkoutId;
        listOfExercisesModel.Duration = listOfExercises.Duration;

        listsOfExercisesRepository.Save(mapper.Map<Entities.Models.ListOfExercises>(listOfExercisesModel));
        return listOfExercisesModel;
    }
}