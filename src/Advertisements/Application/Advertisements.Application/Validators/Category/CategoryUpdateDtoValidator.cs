using FluentValidation;
using Sev1.Advertisements.Application.Validators.Base;
using Sev1.Advertisements.Contracts.Contracts.Category.Requests;

namespace Sev1.Advertisements.Application.Validators.Advertisement
{
    /// <summary>
    /// Валидатор DTO при обновлении категории
    /// </summary>
    public class CategoryUpdateDtoValidator : NullReferenceAbstractValidator<CategoryUpdateRequest>
    {
        public CategoryUpdateDtoValidator()
        {
            // Общая проверка
            RuleFor(x => x)
                .NotNull()
                .NotEmpty().WithMessage("CategoryCreateDto is null!");

            // Id категории
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("Id не заполнен!")
                .InclusiveBetween(1, int.MaxValue);

            // Название категории
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("Name не заполнен!")
                
                // The bracketed characters [a-zA-Z0-9] mean that any letter(regardless of case) or digit will match.
                // The * (asterisk) following the brackets indicates that the bracketed characters occur 0 or more times.
                .Matches("[a-zA-Z0-9]*")
                .MaximumLength(100);

            // ParentCategoryId категории
            RuleFor(x => x.ParentCategoryId)
                .NotNull()
                .NotEmpty().WithMessage("ParentCategoryId не заполнен!")
                .InclusiveBetween(1, int.MaxValue);
        }
    }
}