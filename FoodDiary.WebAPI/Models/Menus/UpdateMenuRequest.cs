using FluentValidation;
using FluentValidation.Results;

namespace FoodDiary.WebAPI.Models;

public class UpdateMenuRequest
{
    #region Model

    public float ProductWeight { get; set; }
    public Guid DailyRationId { get; set; }
    public Guid ProductId { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateMenuRequest>
    {
        public Validator()
        {  }
    }

    #endregion
}

public static class UpdateMenuRequestExtension
{
    public static ValidationResult Validate(this UpdateMenuRequest model)
    {
        return new UpdateMenuRequest.Validator().Validate(model);
    }
}