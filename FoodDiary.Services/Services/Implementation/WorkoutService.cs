using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class WorkoutService : IWorkoutService
{
    private readonly IRepository<Workout> workoutsRepository;
    private readonly IMapper mapper;
    public WorkoutService(IRepository<Workout> workoutsRepository, IMapper mapper)
    {
        this.workoutsRepository = workoutsRepository;
        this.mapper = mapper;
    }

    public void DeleteWorkout(Guid id)
    {
        var workoutToDelete = workoutsRepository.GetById(id);
        if (workoutToDelete == null)
        {
            throw new Exception("Workout not found");
        }

        workoutsRepository.Delete(workoutToDelete);
    }

    public WorkoutModel GetWorkout(Guid id)
    {
        var workout = workoutsRepository.GetById(id);
        return mapper.Map<WorkoutModel>(workout);
    }

    public PageModel<WorkoutPreviewModel> GetWorkouts(int limit = 20, int offset = 0)
    {
        var workouts = workoutsRepository.GetAll();
        int totalCount = workouts.Count();
        var chunk = workouts.OrderBy(x => x.TrainingName).Skip(offset).Take(limit);

        return new PageModel<WorkoutPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<WorkoutPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public WorkoutModel UpdateWorkout(Guid id, UpdateWorkoutModel workout)
    {
        var existingWorkout = workoutsRepository.GetById(id);
        if (existingWorkout == null)
        {
            throw new Exception("Workout not found");
        }

        existingWorkout.TrainingDescription = workout.TrainingDescription;
        existingWorkout.DifficultyLevel = workout.DifficultyLevel;
        existingWorkout.TrainingName = workout.TrainingName;

        existingWorkout = workoutsRepository.Save(existingWorkout);
        return mapper.Map<WorkoutModel>(existingWorkout);
    }

     public WorkoutModel AddWorkout(WorkoutModel workoutModel){
      workoutsRepository.Save(mapper.Map<Entities.Models.Workout>(workoutModel));
        return workoutModel;
    }
}