using FluentValidation;
using FluentValidation.Results;

namespace FoodDiary.WebAPI.Models;

public class UpdateListOfExercisesRequest
{
    #region Model
    
    public Guid ExerciseId { get; set; }
    public Guid WorkoutId { get; set; }
    public DateTime Duration { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateListOfExercisesRequest>
    {
        public Validator()
        { }
    }

    #endregion
}

public static class UpdateListOfExercisesRequestExtension
{
    public static ValidationResult Validate(this UpdateListOfExercisesRequest model)
    {
        return new UpdateListOfExercisesRequest.Validator().Validate(model);
    }
}