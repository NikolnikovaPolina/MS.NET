using FluentValidation;
using FluentValidation.Results;
using FoodDiary.Entities.Models;

namespace FoodDiary.WebAPI.Models;

public class UpdateExerciseRequest
{
    #region Model

    public string NameOfTheExercise { get; set; }
    public string DescriptionOfTheExercise { get; set; }
    public int NumberofCaloriesBurned { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateExerciseRequest>
    {
        public Validator()
        {
            RuleFor(x => x.NameOfTheExercise)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.DescriptionOfTheExercise)
                .MaximumLength(255).WithMessage("Length must be less than 256");    
        }
    }  

    #endregion
}

public static class UpdateExerciseRequestExtension
{
    public static ValidationResult Validate(this UpdateExerciseRequest model)
    {
        return new UpdateExerciseRequest.Validator().Validate(model);
    }
}