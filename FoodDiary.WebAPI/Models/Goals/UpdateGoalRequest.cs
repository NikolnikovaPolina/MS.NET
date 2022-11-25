using FluentValidation;
using FluentValidation.Results;

namespace FoodDiary.WebAPI.Models;

public class UpdateGoalRequest
{
    #region Model
    public string NameOfTheGoal { get; set; }
    public string DescriptionOfTheGoal { get; set; }
    public string Program { get; set; }
    public float DesiresWeight { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateGoalRequest>
    {
        public Validator()
        {
            RuleFor(x => x.NameOfTheGoal)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.DescriptionOfTheGoal)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.Program)
                .MaximumLength(255).WithMessage("Length must be less than 256");        
        }
    }

    #endregion
}

public static class UpdateGoalRequestExtension
{
    public static ValidationResult Validate(this UpdateGoalRequest model)
    {
        return new UpdateGoalRequest.Validator().Validate(model);
    }
}