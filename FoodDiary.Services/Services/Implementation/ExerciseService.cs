using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class ExerciseService : IExerciseService
{
    private readonly IRepository<Entities.Models.Exercise> exercisesRepository;
    private readonly IMapper mapper;
    public ExerciseService(IRepository<Entities.Models.Exercise> exercisesRepository, IMapper mapper)
    {
        this.exercisesRepository = exercisesRepository;
        this.mapper = mapper;
    }

    public void DeleteExercise(Guid id)
    {
        var exerciseToDelete = exercisesRepository.GetById(id);
        if (exerciseToDelete == null)
        {
            throw new Exception("Exercise not found");
        }

      exercisesRepository.Delete(exerciseToDelete);
    }

    public ExerciseModel GetExercise(Guid id)
    {
        var exercise = exercisesRepository.GetById(id);
        return mapper.Map<ExerciseModel>(exercise);
    }

    public PageModel<ExercisePreviewModel> GetExercises(int limit = 20, int offset = 0)
    {
        var exercises = exercisesRepository.GetAll();
        int totalCount = exercises.Count();
        var chunk = exercises.OrderBy(x => x.NameOfTheExercise).Skip(offset).Take(limit);

        return new PageModel<ExercisePreviewModel>()
        {
            Items = mapper.Map<IEnumerable<ExercisePreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public ExerciseModel UpdateExercise(Guid id, UpdateExerciseModel exercise)
    {
        var existingExercise = exercisesRepository.GetById(id);
        if (existingExercise == null)
        {
            throw new Exception("Exercise not found");
        }

        existingExercise.NameOfTheExercise = exercise.NameOfTheExercise;
        existingExercise.DescriptionOfTheExercise = exercise.DescriptionOfTheExercise;
        existingExercise.NumberofCaloriesBurned = exercise.NumberofCaloriesBurned;
        existingExercise.DifficultyLevel = exercise.DifficultyLevel;

        existingExercise = exercisesRepository.Save(existingExercise);
        return mapper.Map<ExerciseModel>(existingExercise);
    }


    public CreateExerciseModel AddExercise(ExerciseModel exercise){

         if(exercisesRepository.GetAll(x => x.Id == exercise.Id).FirstOrDefault() != null)
        {
            throw new Exception ("Attempt to create a non-unique object!");
        }

        CreateExerciseModel exerciseModel = new CreateExerciseModel(); 

        exerciseModel.NameOfTheExercise = exercise.NameOfTheExercise;
        exerciseModel.DescriptionOfTheExercise = exercise.DescriptionOfTheExercise;
        exerciseModel.NumberofCaloriesBurned = exercise.NumberofCaloriesBurned;
        exerciseModel.DifficultyLevel = exercise.DifficultyLevel;

        exercisesRepository.Save(mapper.Map<Entities.Models.Exercise>(exerciseModel));
        return exerciseModel;
    }
}