using FoodDiary.Services.Models;

namespace FoodDiary.Services.Abstract;

public interface IGoalService
{
    GoalModel GetGoal(Guid id);

    GoalModel UpdateGoal(Guid id, UpdateGoalModel user);

    void DeleteGoal(Guid id);

    GoalModel AddGoal(GoalModel goalModel);

    PageModel<GoalPreviewModel> GetGoals(int limit = 20, int offsert = 0);
}