using FluentValidation;
using FluentValidation.Results;

namespace FoodDiary.WebAPI.Models;

public class UpdateDailyRationRequest
{
    #region Model

    public DateTime Date { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateDailyRationRequest>
    {
        public Validator()
        { }
    }

    #endregion
}

public static class UpdateDailyRationRequestExtension
{
    public static ValidationResult Validate(this UpdateDailyRationRequest model)
    {
        return new UpdateDailyRationRequest.Validator().Validate(model);
    }
}