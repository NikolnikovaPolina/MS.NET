using FluentValidation;
using FluentValidation.Results;
using FoodDiary.Entities.Models;

namespace FoodDiary.WebAPI.Models;

public class UpdateUserRequest
{
    #region Model

    public string FIO { get; set; }
    public float Weight { get; set; }
    public ActivityLevel ActivityLevel { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateUserRequest>
    {//?
        public Validator()
        {
            RuleFor(x => x.FIO)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.Weight);
        }
    }

    #endregion
}

public static class UpdateUserRequestExtension
{
    public static ValidationResult Validate(this UpdateUserRequest model)
    {
        return new UpdateUserRequest.Validator().Validate(model);
    }
}