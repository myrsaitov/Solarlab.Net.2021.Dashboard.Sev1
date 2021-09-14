using FluentValidation;
using Sev1.Advertisements.Application.Validators.Base;

namespace Sev1.Advertisements.Application.Validators.Advertisement
{
    public class CategoryIdValidator : AbstractValidator<int>
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
