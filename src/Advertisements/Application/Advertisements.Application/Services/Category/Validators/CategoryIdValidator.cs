using FluentValidation;

namespace Sev1.Advertisements.AppServices.Services.Category.Validators
{
    /// <summary>
    /// Валидатор Id категории
    /// </summary>
    public class CategoryIdValidator : AbstractValidator<int?>
    {
        public CategoryIdValidator()
        {
            // Проверка Id
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("CategoryId is null!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}