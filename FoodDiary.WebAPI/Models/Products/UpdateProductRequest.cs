using FluentValidation;
using FluentValidation.Results;

namespace FoodDiary.WebAPI.Models;

public class UpdateProductRequest
{
    #region Model

    public string ProductName { get; set; }
    public int CaloricContent { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateProductRequest>
    {
        public Validator()
        {
            RuleFor(x => x.ProductName)
                .MaximumLength(255).WithMessage("Length must be less than 256");        
        }
    }  

    #endregion
}

public static class UpdateProductRequestExtension
{
    public static ValidationResult Validate(this UpdateProductRequest model)
    {
        return new UpdateProductRequest.Validator().Validate(model);
    }
}