using FluentValidation;
using FluentValidation.Results;
using FoodDiary.Entities.Models;

namespace FoodDiary.WebAPI.Models;

public class UpdateWorkoutRequest
{
    #region Model

    public string TrainingName { get; set; }
    public Guid UserId { get; set; }
    public DateTime DataOfTheTraining { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string TrainingDescription { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateWorkoutRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TrainingDescription)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.TrainingName)
                .MaximumLength(255).WithMessage("Length must be less than 256");    
        }
    }  

    #endregion
}

public static class UpdateWorkoutRequestExtension
{
    public static ValidationResult Validate(this UpdateWorkoutRequest model)
    {
        return new UpdateWorkoutRequest.Validator().Validate(model);
    }
}