using AutoMapper;
using FoodDiary.Entities.Models;
using FoodDiary.Repository;
using FoodDiary.Services.Abstract;
using FoodDiary.Services.Models;

namespace FoodDiary.Services.Implementation;

public class GoalService : IGoalService
{
    private readonly IRepository<Goal> goalsRepository;
    private readonly IMapper mapper;
    public GoalService(IRepository<Goal> goalsRepository, IMapper mapper)
    {
        this.goalsRepository = goalsRepository;
        this.mapper = mapper;
    }

    public void DeleteGoal(Guid id)
    {
        var goalToDelete = goalsRepository.GetById(id);
        if (goalToDelete == null)
        {
            throw new Exception("Goal not found");
        }

        goalsRepository.Delete(goalToDelete);
    }

    public GoalModel GetGoal(Guid id)
    {
        var goal = goalsRepository.GetById(id);
        return mapper.Map<GoalModel>(goal);
    }

    public PageModel<GoalPreviewModel> GetGoals(int limit = 20, int offset = 0)
    {
        var goals = goalsRepository.GetAll();
        int totalCount = goals.Count();
        var chunk = goals.OrderBy(x => x.NameOfTheGoal).Skip(offset).Take(limit);

        return new PageModel<GoalPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<GoalPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public GoalModel UpdateGoal(Guid id, UpdateGoalModel goal)
    {
        var existingGoal = goalsRepository.GetById(id);
        if (existingGoal == null)
        {
            throw new Exception("Goal not found");
        }

        existingGoal.NameOfTheGoal = goal.NameOfTheGoal;
        existingGoal.DesiresWeight = goal.DesiresWeight;
        existingGoal.Program = goal.Program;

        existingGoal = goalsRepository.Save(existingGoal);
        return mapper.Map<GoalModel>(existingGoal);
    }

     public GoalModel AddGoal(GoalModel goalModel){
      goalsRepository.Save(mapper.Map<Entities.Models.Goal>(goalModel));
        return goalModel;
    }
}